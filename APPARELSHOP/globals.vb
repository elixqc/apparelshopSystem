Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Drawing

Module globals

    Public ReadOnly connectionString As String = "server=localhost;userid=root;password=;database=apparelshopdb"

    Public loggedInUserID As Integer = 0
    Public adminUserLogin As String = ""
    Public loggedInUserEmail As String = ""
    Public loggedInUserFullName As String = ""
    Public selectedSweatsColor As String = ""
    Public selectedShirtColor As String = ""
    Public selectedHoodieColor As String = ""
    Public selectedSweatpantsColor As String = ""
    Public selectedShirtSize As String = ""
    Public selectedFilePath As String = ""
    Public imagePathForDb As String = ""

    'FETCH products table transfer into frontend table
    Public Class CartItem
        Public Property ProductID As Integer
        Public Property Name As String
        Public Property Size As String
        Public Property Color As String
        Public Property Brand As String
        Public Property Quantity As Integer
        Public Property ImagePath As String
        Public Property Price As Decimal ' 👈 Added Price
        Public Property MaxStock As Integer

    End Class

    Public Function GetFemalePerfumeTypes() As List(Of String)
        Return GetPerfumeTypesByGender("Female")
    End Function

    Public Function GetMalePerfumeTypes() As List(Of String)
        Return GetPerfumeTypesByGender("Male")
    End Function

    ' Function to find a control by name recursively
    Public Function FindControlByName(parent As Control, name As String) As Control
        For Each ctrl As Control In parent.Controls
            If ctrl.Name = name Then
                Return ctrl
            ElseIf ctrl.HasChildren Then
                Dim found = FindControlByName(ctrl, name)
                If found IsNot Nothing Then Return found
            End If
        Next
        Return Nothing
    End Function





    ' Shared function used internally
    Private Function GetPerfumeTypesByGender(gender As String) As List(Of String)
        Dim types As New HashSet(Of String)

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()

                ' Only use category_id 7 and 8 (EDP and EDT)
                Dim query As String = "
                SELECT DISTINCT product_name 
                FROM products 
                WHERE category_id IN (7, 8) 
                  AND gender = @gender"

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@gender", gender)

                    Dim reader = cmd.ExecuteReader()

                    While reader.Read()
                        Dim fullName As String = reader("product_name").ToString()

                        ' Removee " EDP"/" EDT" suffix if present
                        If fullName.EndsWith(" EDT") Or fullName.EndsWith(" EDP") Then
                            types.Add(fullName.Substring(0, fullName.Length - 4))
                        Else
                            types.Add(fullName)
                        End If
                    End While

                    reader.Close()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error fetching perfume types by gender: " & ex.Message)
        End Try

        Return types.ToList()
    End Function
    ' Function to add perfumes to cart
    Public Sub AddToPerfumeCart(productName As String, quantity As Integer)
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()

                ' Get product_id
                Dim getProductCmd As New MySqlCommand("SELECT product_id FROM products WHERE product_name = @pname", conn)
                getProductCmd.Parameters.AddWithValue("@pname", productName)

                Dim productIdObj As Object = getProductCmd.ExecuteScalar()

                If loggedInUserID <= 0 Then
                    MessageBox.Show("Please log in before adding to cart.")
                    Exit Sub
                End If


                If productIdObj Is Nothing Then
                    MessageBox.Show("Product not found.")
                    Exit Sub
                End If

                Dim productId As Integer = CInt(productIdObj)

                ' Insert or update cart (perfumes don't have sizes, so size is NULL)
                Dim cartCmd As New MySqlCommand("
                    INSERT INTO cart (customer_id, product_id, quantity, date_added, size)
                    VALUES (@cid, @pid, @qty, NOW(), NULL)
                    ON DUPLICATE KEY UPDATE 
                        quantity = quantity + @qty, 
                        date_added = NOW();", conn)

                cartCmd.Parameters.AddWithValue("@cid", loggedInUserID)
                cartCmd.Parameters.AddWithValue("@pid", productId)
                cartCmd.Parameters.AddWithValue("@qty", quantity)

                cartCmd.ExecuteNonQuery()

                MessageBox.Show("Perfume added to cart!")

            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    ' Function to update cart quantity for apparel
    Public Sub UpdateCartQuantity(customerID As Integer, productID As Integer, size As String, newQuantity As Integer)
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim query As String = "UPDATE cart SET quantity = @qty WHERE customer_id = @custID AND product_id = @prodID AND (size = @size OR (size IS NULL AND @size IS NULL))"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@qty", newQuantity)
                    cmd.Parameters.AddWithValue("@custID", customerID)
                    cmd.Parameters.AddWithValue("@prodID", productID)
                    cmd.Parameters.AddWithValue("@size", If(String.IsNullOrEmpty(size), DBNull.Value, size))
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Could not update cart quantity. Please try again.")
        End Try
    End Sub
    ' ' Function to delete item from cart for apparel
    Public Sub DeleteFromCart(customerID As Integer, productID As Integer, size As String)
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim query As String = "DELETE FROM cart WHERE customer_id = @customerID AND product_id = @productID AND (size = @size OR (size IS NULL AND @size IS NULL))"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@customerID", customerID)
                    cmd.Parameters.AddWithValue("@productID", productID)
                    cmd.Parameters.AddWithValue("@size", If(String.IsNullOrEmpty(size), DBNull.Value, size))
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Could not delete item from cart. Please try again.")
        End Try
    End Sub

    'ADD TO CART FUNCTION (original for apparel)
    Public Sub AddToCart(productName As String, quantity As Integer, selectedSize As String, selectedColor As String)
        Try
            If loggedInUserID <= 0 Then
                MessageBox.Show("Please log in before adding to cart.")
                Exit Sub
            End If

            Using conn As New MySqlConnection(connectionString)
                conn.Open()

                ' Get the correct product_id and current stock based on full product name, size, and color
                Dim checkCmd As New MySqlCommand("
                SELECT product_id, stock_quantity 
                FROM products 
                WHERE product_name = @pname AND size = @size AND color = @color", conn)

                checkCmd.Parameters.AddWithValue("@pname", productName)
                checkCmd.Parameters.AddWithValue("@size", selectedSize)
                checkCmd.Parameters.AddWithValue("@color", selectedColor)

                Using reader = checkCmd.ExecuteReader()
                    If reader.Read() Then
                        Dim productId As Integer = Convert.ToInt32(reader("product_id"))
                        Dim currentStock As Integer = Convert.ToInt32(reader("stock_quantity"))

                        If quantity > currentStock Then
                            MessageBox.Show("Not enough stock available.")
                            Exit Sub
                        End If

                        reader.Close() ' Must close before executing another command on same connection

                        ' Insert or update cart entry
                        Dim cartCmd As New MySqlCommand("
                        INSERT INTO cart (customer_id, product_id, quantity, date_added, size)
                        VALUES (@cid, @pid, @qty, NOW(), @size)
                        ON DUPLICATE KEY UPDATE 
                            quantity = quantity + @qty,
                            date_added = NOW(),
                            size = @size", conn)

                        cartCmd.Parameters.AddWithValue("@cid", loggedInUserID)
                        cartCmd.Parameters.AddWithValue("@pid", productId)
                        cartCmd.Parameters.AddWithValue("@qty", quantity)
                        cartCmd.Parameters.AddWithValue("@size", selectedSize)

                        cartCmd.ExecuteNonQuery()
                        MessageBox.Show("Product added to cart!")
                    Else
                        MessageBox.Show("Product not found with the selected size and color.")
                    End If
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub


    '' Function to create a product panel for apparel
    Public Sub CreateProductPanel(productType As String, container As FlowLayoutPanel)



        Dim panel As New Panel With {
        .Width = 318,
        .Height = 479,
        .BorderStyle = BorderStyle.FixedSingle,
        .Margin = New Padding(15, 15, 15, 15)'left top right bottom
    }

        Dim productData As New Dictionary(Of String, Object)
        productData("SelectedColor") = Nothing
        productData("SelectedSize") = Nothing
        productData("Quantity") = 0
        panel.Tag = productData ' Attach data to the panel


        Dim productImage As New PictureBox With {
        .SizeMode = PictureBoxSizeMode.StretchImage,
        .Width = 286,
        .Height = 318,
        .Top = 15,
        .Left = 14
    }

        Dim colorImageMap As New Dictionary(Of String, String)()
        Dim sizes As New HashSet(Of String)
        Dim totalStock As Integer = 0
        Dim priceValue As Decimal = 0
        Dim firstPriceCaptured As Boolean = False


        ' Connecting to database
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim cmd As New MySqlCommand("SELECT product_name, size, color, image_path, price, stock_quantity FROM products WHERE product_name LIKE @type", conn)

                cmd.Parameters.AddWithValue("@type", productType & "%")
                Dim reader = cmd.ExecuteReader()

                While reader.Read()
                    Dim stockQty As Integer = Convert.ToInt32(reader("stock_quantity"))
                    If stockQty <= 0 Then Continue While

                    Dim fullName As String = reader("product_name").ToString()
                    Dim size As String = reader("size").ToString()
                    Dim imagePath As String = reader("image_path").ToString()
                    Dim color As String = reader("color").ToString()
                    Dim price As Decimal = Convert.ToDecimal(reader("price"))

                    totalStock += stockQty
                    sizes.Add(size)

                    If Not firstPriceCaptured Then
                        priceValue = price
                        firstPriceCaptured = True
                    End If

                    If Not colorImageMap.ContainsKey(color) Then
                        colorImageMap.Add(color, imagePath)
                    End If
                End While
                If totalStock <= 0 Then
                    Exit Sub ' Don't display panel if all variants are out of stock
                End If
                reader.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("DB Error: " & ex.Message)
            Exit Sub
        End Try

        ' Default image
        If colorImageMap.Count > 0 Then
            Dim defaultImagePath = Path.Combine(Application.StartupPath, colorImageMap.Values.First())
            If File.Exists(defaultImagePath) Then
                productImage.Image = Image.FromFile(defaultImagePath)
            End If
        End If
        panel.Controls.Add(productImage)

        ' Extract base name (without size and color)
        Dim baseName As String = "Prestige " & productType.Trim()

        ' Product Name Label
        Dim nameLabel As New Label With {
            .Text = baseName,
            .Font = New Font("Microsoft Himalaya", 15),
            .AutoSize = True,
            .Left = 11,
            .Top = 397
        }
        panel.Controls.Add(nameLabel)

        ' Stock Label (you can replace 23 with dynamic stock if available)
        Dim stockLabel As New Label With {
            .Name = "stockLabel",
            .Text = "Stock: " & totalStock.ToString(),
            .Font = New Font("Microsoft Himalaya", 15),
            .AutoSize = True,
            .Left = 11,
            .Top = 418
        }
        panel.Controls.Add(stockLabel)

        ' Price Label (replace with actual price if available)
        Dim priceLabel As New Label With {
            .Text = "Price: ₱" & priceValue.ToString("F2"),
            .Font = New Font("Microsoft Himalaya", 15),
            .AutoSize = True,
            .Left = 11,
            .Top = 439
        }
        panel.Controls.Add(priceLabel)





        ' Size ComboBox
        Dim sizeCombo As New ComboBox With {
        .Top = 337,
        .Left = 180,
        .Width = 121,
        .Height = 27,
        .Font = New Font("Microsoft Himalaya", 14.25),
        .DropDownStyle = ComboBoxStyle.DropDownList
    }
        sizeCombo.Items.Insert(0, "Select Size")
        sizeCombo.SelectedIndex = 0
        sizeCombo.Items.AddRange(sizes.ToArray())

        panel.Controls.Add(sizeCombo)

        Dim UpdateStockLabel As Action = Sub()
                                             Dim data = DirectCast(panel.Tag, Dictionary(Of String, Object))
                                             Dim selectedColor = TryCast(data("SelectedColor"), String)
                                             Dim selectedSize = TryCast(data("SelectedSize"), String)

                                             If String.IsNullOrEmpty(selectedColor) OrElse selectedSize = "Select Size" OrElse String.IsNullOrEmpty(selectedSize) Then
                                                 stockLabel.Text = "Stock: -"
                                                 Return
                                             End If

                                             Using conn As New MySqlConnection(connectionString)
                                                 conn.Open()
                                                 Dim cmd As New MySqlCommand("SELECT stock_quantity FROM products WHERE product_name LIKE @type AND color = @color AND size = @size", conn)
                                                 cmd.Parameters.AddWithValue("@type", productType & "%")
                                                 cmd.Parameters.AddWithValue("@color", selectedColor)
                                                 cmd.Parameters.AddWithValue("@size", selectedSize)
                                                 Dim stockObj = cmd.ExecuteScalar()
                                                 If stockObj IsNot Nothing Then
                                                     stockLabel.Text = "Stock: " & Convert.ToInt32(stockObj).ToString()
                                                 Else
                                                     stockLabel.Text = "Stock: 0"
                                                 End If
                                             End Using
                                         End Sub
        AddHandler sizeCombo.SelectedIndexChanged, Sub(sender, e)
                                                       Dim data = DirectCast(panel.Tag, Dictionary(Of String, Object))
                                                       data("SelectedSize") = sizeCombo.SelectedItem?.ToString()
                                                       UpdateStockLabel()
                                                   End Sub





        ' Quantity TextBox
        Dim qtyBox As New TextBox With {
        .Top = 389,
        .Left = 202,
        .Width = 100,
        .Height = 23,
        .TextAlign = HorizontalAlignment.Right,
        .Text = "Quantity",
        .ForeColor = Color.Gray
    }

        AddHandler qtyBox.Enter, Sub(sender, e)
                                     If qtyBox.Text = "Quantity" Then
                                         qtyBox.Text = ""
                                         qtyBox.ForeColor = Color.Black
                                     End If
                                 End Sub

        AddHandler qtyBox.Leave, Sub(sender, e)
                                     If String.IsNullOrWhiteSpace(qtyBox.Text) Then
                                         qtyBox.Text = "Quantity"
                                         qtyBox.ForeColor = Color.Gray
                                     End If
                                 End Sub

        panel.Controls.Add(qtyBox)

        ' Color Buttons
        Dim xOffset As Integer = 10
        For Each colorName In colorImageMap.Keys
            Dim clrBtn As New Button With {
        .Width = 20,
        .Height = 20,
        .Left = xOffset,
        .Top = productImage.Bottom + 5,
        .Tag = colorName,
        .BackColor = Color.FromName(colorName), ' ← this is now correct
        .FlatStyle = FlatStyle.Flat
    }

            clrBtn.FlatAppearance.BorderColor = Color.Black
            clrBtn.FlatAppearance.BorderSize = 2



            AddHandler clrBtn.Click, Sub(senderBtn, eBtn)
                                         Dim clickedColor = DirectCast(senderBtn, Button).Tag.ToString()

                                         If colorImageMap.ContainsKey(clickedColor) Then
                                             Dim imgPath = Path.Combine(Application.StartupPath, colorImageMap(clickedColor))
                                             If File.Exists(imgPath) Then
                                                 productImage.Image = Image.FromFile(imgPath)
                                             End If
                                         End If

                                         ' Update the selected color in the panel's Tag
                                         Dim data = DirectCast(panel.Tag, Dictionary(Of String, Object))
                                         data("SelectedColor") = clickedColor
                                         UpdateStockLabel()


                                     End Sub

            panel.Controls.Add(clrBtn)
            xOffset += 25
        Next

        ' Add to Cart Button
        Dim addToCartBtn As New Button With {
            .Text = "ADD TO CART",
            .Font = New Font("Microsoft Himalaya", 14.25),
            .ForeColor = Color.White, ' font color
            .BackColor = Color.FromArgb(74, 80, 66), ' background color
            .Top = 418,
            .Left = 202,
            .Width = 100,
            .Height = 40,
        .FlatStyle = FlatStyle.Flat
        }



        AddHandler addToCartBtn.Click, Sub(senderBtn, eBtn)

                                           Dim selectedSize = sizeCombo.SelectedItem?.ToString()
                                           Dim qty As Integer = 0

                                           If Not Integer.TryParse(qtyBox.Text, qty) OrElse qty <= 0 Then
                                               MessageBox.Show("Enter valid quantity")
                                               Return
                                           End If

                                           If String.IsNullOrEmpty(selectedSize) OrElse selectedSize = "Select Size" Then
                                               MessageBox.Show("Select a size")
                                               Return
                                           End If

                                           ' Get selected color from panel
                                           Dim data = DirectCast(panel.Tag, Dictionary(Of String, Object))
                                           Dim selectedColor = TryCast(data("SelectedColor"), String)

                                           If String.IsNullOrEmpty(selectedColor) Then
                                               MessageBox.Show("Please select a color.")
                                               Return
                                           End If

                                           Dim fullProductName = $"{productType} - {selectedColor} - {selectedSize}"
                                           AddToCart(fullProductName, qty, selectedSize, selectedColor)


                                       End Sub
        panel.Controls.Add(addToCartBtn)

        container.Controls.Add(panel)



    End Sub
    ' ' Function to FETCH all product types (apparel)
    Public Function GetAllProductTypes() As List(Of String)
        Dim types As New HashSet(Of String)

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim cmd As New MySqlCommand("SELECT DISTINCT product_name FROM products WHERE category_id NOT IN (7,8)", conn)
                Dim reader = cmd.ExecuteReader()

                While reader.Read()
                    Dim fullName As String = reader("product_name").ToString()

                    Dim lastDash1 = fullName.LastIndexOf("-")
                    Dim lastDash2 = If(lastDash1 > 0, fullName.LastIndexOf("-", lastDash1 - 1), -1)

                    If lastDash2 >= 0 Then
                        Dim baseType As String = fullName.Substring(0, lastDash2).Trim()
                        types.Add(baseType)
                    Else
                        MessageBox.Show("Skipping (bad format): " & fullName)
                    End If

                End While

                reader.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error fetching product types: " & ex.Message)
        End Try

        Return types.ToList()
    End Function
    ' ' Function to create a cart item panel

    Public Sub CreateCartItemPanel(productID As Integer, productName As String, size As String, color As String, brand As String, quantity As Integer, imagePath As String, price As Decimal, maxStock As Integer, container As FlowLayoutPanel, newCartForm As newCart)

        Dim panel As New Panel With {
        .Width = 471,
        .Height = 165,
        .BackColor = System.Drawing.Color.FromArgb(245, 245, 245),
        .BorderStyle = BorderStyle.FixedSingle,
        .Margin = New Padding(5)
    }

        ' Brand label
        Dim brandLabel As New Label With {
        .Text = brand,
        .Font = New Font("Segoe UI", 9, FontStyle.Bold),
        .ForeColor = System.Drawing.Color.Gray,
        .AutoSize = True,
        .Location = New Point(10, 5)
    }
        panel.Controls.Add(brandLabel)

        ' Product Image
        Dim productImage As New PictureBox With {
        .Size = New Size(110, 110),
        .SizeMode = PictureBoxSizeMode.Zoom,
        .Location = New Point(20, 35),
        .BackColor = System.Drawing.Color.WhiteSmoke,
        .BorderStyle = BorderStyle.FixedSingle
    }
        If File.Exists(imagePath) Then
            productImage.Image = Image.FromFile(imagePath)
        End If
        panel.Controls.Add(productImage)

        ' Product Name
        Dim nameLabel As New Label With {
        .Text = productName,
        .Font = New Font("Segoe UI", 10, FontStyle.Bold),
        .AutoSize = True,
        .Location = New Point(140, 35)
    }
        panel.Controls.Add(nameLabel)

        ' Size Label
        If Not String.IsNullOrEmpty(size) Then
            Dim sizeLabel As New Label With {
            .Text = "Size: " & size,
            .Font = New Font("Segoe UI", 9),
            .Location = New Point(140, 60),
            .AutoSize = True
        }
            panel.Controls.Add(sizeLabel)
        End If

        ' Color Label
        Dim colorLabel As New Label With {
        .Text = "Color: " & color,
        .Font = New Font("Segoe UI", 9),
        .Location = New Point(140, If(String.IsNullOrEmpty(size), 60, 80)),
        .AutoSize = True
    }
        panel.Controls.Add(colorLabel)

        ' Price
        Dim priceLabel As New Label With {
        .Name = "priceLabel",
        .Text = "Price: ₱" & price.ToString("F2"),
        .Font = New Font("Segoe UI", 9),
        .ForeColor = System.Drawing.Color.DarkGreen,
        .Tag = price,
        .Location = New Point(140, 100),
        .AutoSize = True
    }
        panel.Controls.Add(priceLabel)

        ' Quantity Label
        Dim qtyLabel As New Label With {
        .Name = "qtyLabel",
        .Text = quantity.ToString(),
        .Font = New Font("Segoe UI", 9, FontStyle.Bold),
        .Location = New Point(405, 115),
        .Size = New Size(30, 25),
        .TextAlign = ContentAlignment.MiddleCenter
    }
        panel.Controls.Add(qtyLabel)

        ' Minus Button
        Dim minusBtn As New Button With {
        .Text = "-",
        .Width = 25,
        .Height = 25,
        .Location = New Point(375, 115),
        .BackColor = System.Drawing.Color.LightGray
    }
        AddHandler minusBtn.Click, Sub()
                                       If quantity > 1 Then
                                           quantity -= 1
                                           qtyLabel.Text = quantity.ToString()
                                           newCartForm.UpdateSubtotalLabel(container)
                                           UpdateCartQuantity(loggedInUserID, productID, size, quantity)
                                       ElseIf quantity = 1 Then
                                           DeleteFromCart(loggedInUserID, productID, size)
                                           newCartForm.CartPanel.Controls.Clear()
                                           newCartForm.LoadCartItems()
                                       End If
                                   End Sub
        panel.Controls.Add(minusBtn)

        ' Plus Button
        Dim plusBtn As New Button With {
        .Text = "+",
        .Width = 25,
        .Height = 25,
        .Location = New Point(440, 115),
        .BackColor = System.Drawing.Color.LightGray
    }
        AddHandler plusBtn.Click, Sub()
                                      If quantity < maxStock Then
                                          quantity += 1
                                          qtyLabel.Text = quantity.ToString()
                                          newCartForm.UpdateSubtotalLabel(container)
                                          UpdateCartQuantity(loggedInUserID, productID, size, quantity)
                                      Else
                                          MessageBox.Show("You've reached the maximum available stock for this item.")
                                      End If
                                  End Sub
        panel.Controls.Add(plusBtn)


        container.Controls.Add(panel)
    End Sub

    ' ' Function to get cart items for the logged-in user
    Public Function GetCartItems(customerID As Integer) As List(Of CartItem)
        Dim cartItems As New List(Of CartItem)()

        Dim query As String = "
            SELECT 
                c.product_id,
                p.product_name,
                p.color,
                COALESCE(b.brand_name, 'PERFUMERIES') AS brand_name,
                c.size,
                c.quantity,
                p.image_path,
                p.price,
                p.stock_quantity AS max_stock
            FROM cart c
            INNER JOIN products p ON c.product_id = p.product_id
            LEFT JOIN brands b ON p.brand_id = b.brand_id
            WHERE c.customer_id = @custID
            "


        Try
            Using conn As New MySqlConnection("server=localhost;userid=root;password=;database=apparelshopdb")
                conn.Open()

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@custID", customerID)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim item As New CartItem With {
                            .ProductID = Convert.ToInt32(reader("product_id")),
                            .Name = reader("product_name").ToString(),
                            .Color = reader("color").ToString(),
                            .Brand = reader("brand_name").ToString(),
                            .Size = If(reader("size") Is DBNull.Value, "", reader("size").ToString()),
                            .Quantity = Convert.ToInt32(reader("quantity")),
                            .ImagePath = reader("image_path").ToString(),
                            .Price = Convert.ToDecimal(reader("price")), ' 👈 Assign price
                            .MaxStock = Convert.ToInt32(reader("max_stock"))
                        }

                            cartItems.Add(item)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error fetching cart items: " & ex.Message)
        End Try

        Return cartItems
    End Function



    ' ' Function to create a perfume panel
    Public Sub CreatePerfumePanel(productName As String, container As FlowLayoutPanel, gender As String)

        Dim panel As New Panel With {
            .Width = 340,
            .Height = 520,
            .BorderStyle = BorderStyle.FixedSingle,
            .Margin = New Padding(15, 15, 15, 15)
}

        Dim productData As New Dictionary(Of String, Object)
        productData("SelectedVariant") = Nothing
        productData("Quantity") = 0
        panel.Tag = productData

        Dim productImage As New PictureBox With {
    .SizeMode = PictureBoxSizeMode.StretchImage,
    .Width = 286,
    .Height = 350,
    .Top = 20,
    .Left = 20
}

        Dim perfumeVariants As New Dictionary(Of String, Object)()
        Dim totalStock As Integer = 0
        Dim firstImageSet As Boolean = False

        ' Get perfume variants (both EDP and EDT versions)
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim cmd As New MySqlCommand("
    SELECT product_name, color, image_path, price, stock_quantity, category_id 
    FROM products 
    WHERE product_name IN (@nameEDP, @nameEDT)
      AND gender = @gender
", conn)

                cmd.Parameters.AddWithValue("@gender", gender)

                cmd.Parameters.AddWithValue("@nameEDP", productName & " EDP")
                cmd.Parameters.AddWithValue("@nameEDT", productName & " EDT")

                Using reader = cmd.ExecuteReader()
                    Dim foundAny As Boolean = False

                    While reader.Read()
                        Dim stock As Integer = If(IsDBNull(reader("stock_quantity")), 0, Convert.ToInt32(reader("stock_quantity")))

                        If stock <= 0 Then Continue While ' 🛑 SKIP if out of stock

                        foundAny = True

                        Dim fullName As String = If(IsDBNull(reader("product_name")), "", reader("product_name").ToString())
                        Dim color As String = If(IsDBNull(reader("color")), "", reader("color").ToString())
                        Dim imagePath As String = If(IsDBNull(reader("image_path")), "", reader("image_path").ToString())
                        Dim price As Decimal = If(IsDBNull(reader("price")), 0D, Convert.ToDecimal(reader("price")))

                        totalStock += stock

                        Dim variantType As String = If(fullName.EndsWith(" EDT"), "EDT", "EDP")
                        Dim variantKey As String = $"{variantType} - ₱{price:F2}"

                        perfumeVariants(variantKey) = New Dictionary(Of String, Object) From {
        {"FullName", fullName},
        {"Color", color},
        {"ImagePath", imagePath},
        {"Price", price},
        {"Stock", stock}
    }

                        ' Set default image
                        If Not firstImageSet Then
                            Dim defaultImagePath = Path.Combine(Application.StartupPath, imagePath)
                            If File.Exists(defaultImagePath) Then
                                productImage.Image = Image.FromFile(defaultImagePath)
                            End If
                            firstImageSet = True
                        End If
                    End While


                    If Not foundAny Then

                        Exit Sub
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("DB Error: " & ex.Message)
            Exit Sub
        End Try

        panel.Controls.Add(productImage)

        ' Product Name Label
        Dim nameLabel As New Label With {
            .Text = productName,
            .Font = New Font("Microsoft Himalaya", 16, FontStyle.Bold),
            .AutoSize = True,
            .Left = 11,
            .Top = productImage.Bottom + 5
        }
        panel.Controls.Add(nameLabel)

        ' Stock Label
        Dim stockLabel As New Label With {
            .Text = "Stock: " & totalStock.ToString(),
            .Font = New Font("Microsoft Himalaya", 14),
            .AutoSize = True,
            .Left = 11,
            .Top = 405
        }
        panel.Controls.Add(stockLabel)

        ' Variant ComboBox (EDP/EDT)
        Dim variantCombo As New ComboBox With {
            .Top = 430,
            .Left = 11,
            .Width = 150,
            .Height = 27,
            .Font = New Font("Microsoft Himalaya", 12),
            .DropDownStyle = ComboBoxStyle.DropDownList
        }
        variantCombo.Items.Insert(0, "Select Type")
        variantCombo.SelectedIndex = 0

        For Each variantKey In perfumeVariants.Keys
            variantCombo.Items.Add(variantKey)
        Next

        ' Handle variant selection change
        AddHandler variantCombo.SelectedIndexChanged, Sub(sender, e)
                                                          If variantCombo.SelectedIndex > 0 Then
                                                              Dim selectedVariant = variantCombo.SelectedItem.ToString()
                                                              If perfumeVariants.ContainsKey(selectedVariant) Then
                                                                  Dim variantData = DirectCast(perfumeVariants(selectedVariant), Dictionary(Of String, Object))
                                                                  Dim imgPath = Path.Combine(Application.StartupPath, variantData("ImagePath").ToString())
                                                                  If File.Exists(imgPath) Then
                                                                      productImage.Image = Image.FromFile(imgPath)
                                                                  End If

                                                                  ' Update selected variant in panel data
                                                                  Dim data = DirectCast(panel.Tag, Dictionary(Of String, Object))
                                                                  data("SelectedVariant") = selectedVariant
                                                              End If
                                                          End If
                                                      End Sub

        panel.Controls.Add(variantCombo)

        ' Quantity TextBox
        Dim qtyBox As New TextBox With {
            .Top = productImage.Bottom + 5,
            .Left = 250,
            .Width = 60,
            .Height = 23,
            .TextAlign = HorizontalAlignment.Center,
            .Text = "1"
        }
        panel.Controls.Add(qtyBox)

        ' Add to Cart Button
        Dim addToCartBtn As New Button With {
            .Text = "ADD TO CART",
            .Font = New Font("Microsoft Himalaya", 12),
            .ForeColor = Color.White,
            .BackColor = Color.FromArgb(74, 80, 66),
            .FlatStyle = FlatStyle.Flat,
            .Top = 475,
            .Left = 30,
            .Width = 280,
            .Height = 30
        }

        AddHandler addToCartBtn.Click, Sub(senderBtn, eBtn)
                                           Dim qty As Integer = 0
                                           If Not Integer.TryParse(qtyBox.Text, qty) OrElse qty <= 0 Then
                                               MessageBox.Show("Enter a valid quantity.")
                                               Return
                                           End If

                                           Dim data = DirectCast(panel.Tag, Dictionary(Of String, Object))
                                           Dim selectedVariant = TryCast(data("SelectedVariant"), String)

                                           If String.IsNullOrEmpty(selectedVariant) OrElse variantCombo.SelectedIndex = 0 Then
                                               MessageBox.Show("Please select a perfume type.")
                                               Return
                                           End If

                                           If perfumeVariants.ContainsKey(selectedVariant) Then
                                               Dim variantData = DirectCast(perfumeVariants(selectedVariant), Dictionary(Of String, Object))
                                               Dim fullProductName = variantData("FullName").ToString()
                                               Dim availableStock As Integer = Convert.ToInt32(variantData("Stock"))

                                               If qty > availableStock Then
                                                   MessageBox.Show("Only " & availableStock & " item(s) left in stock for this variant.")
                                                   Return
                                               End If

                                               ' Proceed to add to cart
                                               AddToPerfumeCart(fullProductName, qty)
                                               MessageBox.Show("Selected: " & selectedVariant & vbCrLf &
                                                               "FullName: " & fullProductName & vbCrLf &
                                                               "Qty: " & qty.ToString())
                                           End If

                                       End Sub

        panel.Controls.Add(addToCartBtn)
        container.Controls.Add(panel)
    End Sub




End Module