Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Drawing



Module globals

    Dim conn As New MySqlConnection("server=localhost;userid=root;password=;database=apparelshopdb")


    Public loggedInUserID As Integer = 0
    Public adminUserLogin As String = ""
    Public loggedInUserEmail As String = ""
    Public loggedInUserFullName As String = ""
    Public selectedSweatsColor As String = ""
    Public selectedShirtColor As String = ""
    Public selectedHoodieColor As String = ""
    Public selectedSweatpantsColor As String = ""
    Dim selectedColor As String = ""

    Public Class CartItem
        Public Property ProductID As Integer
        Public Property Name As String
        Public Property Size As String
        Public Property Color As String
        Public Property Brand As String
        Public Property Quantity As Integer
        Public Property ImagePath As String
    End Class



    Public Sub UpdateCartQuantity(customerID As Integer, productID As Integer, size As String, newQuantity As Integer)
        Try
            Using conn As New MySqlConnection("server=localhost;userid=root;password=;database=apparelshopdb")
                conn.Open()
                Dim query As String = "UPDATE cart SET quantity = @qty WHERE customer_id = @custID AND product_id = @prodID AND size = @size"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@qty", newQuantity)
                    cmd.Parameters.AddWithValue("@custID", customerID)
                    cmd.Parameters.AddWithValue("@prodID", productID) ' ← this must be an Integer
                    cmd.Parameters.AddWithValue("@size", size)

                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error updating quantity: " & ex.Message)
        End Try
    End Sub

    Public Sub DeleteFromCart(customerID As Integer, productID As Integer, size As String)
        Try

            conn.Open()
            Dim query As String = "DELETE FROM cart WHERE customer_id = @customerID AND product_id = @productID AND size = @size"
            Dim cmd As New MySqlCommand(query, conn)

            cmd.Parameters.AddWithValue("@customerID", customerID)
            cmd.Parameters.AddWithValue("@productID", productID)
            cmd.Parameters.AddWithValue("@size", size)

            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("Error deleting from cart: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub





    'ADD TO CART FUNCTIONNNN
    Public Sub AddToCart(productName As String, quantity As Integer, selectedSize As String)
        Try
            conn.Open()

            ' Get product_id
            Dim getProductCmd As New MySqlCommand("SELECT product_id FROM products WHERE product_name = @pname", conn)
            getProductCmd.Parameters.AddWithValue("@pname", productName)

            Dim productIdObj As Object = getProductCmd.ExecuteScalar()

            If productIdObj Is Nothing Then
                MessageBox.Show("Product not found.")
                Exit Sub
            End If

            Dim productId As Integer = CInt(productIdObj)

            ' Insert or update cart using composite PK (customer_id + product_id)
            Dim cartCmd As New MySqlCommand("
            INSERT INTO cart (customer_id, product_id, quantity, date_added, size)
            VALUES (@cid, @pid, @qty, NOW(), @size)
            ON DUPLICATE KEY UPDATE 
                quantity = quantity + @qty, 
                date_added = NOW(),
                size = @size;", conn)

            cartCmd.Parameters.AddWithValue("@cid", loggedInUserID)
            cartCmd.Parameters.AddWithValue("@pid", productId)
            cartCmd.Parameters.AddWithValue("@qty", quantity)
            cartCmd.Parameters.AddWithValue("@size", selectedSize)

            cartCmd.ExecuteNonQuery()

            MessageBox.Show("Product added to cart!")

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub



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
            conn.Open()
            Dim cmd As New MySqlCommand("SELECT product_name, size, color, image_path, price, stock_quantity FROM products WHERE product_name LIKE @type", conn)

            cmd.Parameters.AddWithValue("@type", productType & "%")
            Dim reader = cmd.ExecuteReader()

            While reader.Read()
                Dim fullName As String = reader("product_name").ToString()
                Dim size As String = reader("size").ToString()
                Dim imagePath As String = reader("image_path").ToString()
                Dim color As String = reader("color").ToString()
                totalStock += Convert.ToInt32(reader("stock_quantity"))
                If Not firstPriceCaptured Then
                    priceValue = Convert.ToDecimal(reader("price"))
                    firstPriceCaptured = True
                End If


                sizes.Add(size)

                If Not colorImageMap.ContainsKey(color) Then
                    colorImageMap.Add(color, imagePath)
                End If

            End While
            reader.Close()

        Catch ex As Exception
            MessageBox.Show("DB Error: " & ex.Message)
            Exit Sub
        Finally
            conn.Close()
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
                                     End Sub

            panel.Controls.Add(clrBtn)
            xOffset += 25
        Next

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

        ' Add to Cart Button
        Dim addToCartBtn As New Button With {
            .Text = "ADD TO CART",
            .Font = New Font("Microsoft Himalaya", 14.25),
            .ForeColor = Color.White, ' ← Sets the font color
            .BackColor = Color.Black, ' Optional: background color
            .Top = 418,
            .Left = 202,
            .Width = 100,
            .Height = 40
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
                                           AddToCart(fullProductName, qty, selectedSize)


                                       End Sub
        panel.Controls.Add(addToCartBtn)

        container.Controls.Add(panel)
    End Sub

    Public Function GetAllProductTypes() As List(Of String)
        Dim types As New HashSet(Of String)

        Try
            conn.Open()
            Dim cmd As New MySqlCommand("SELECT DISTINCT product_name FROM products", conn)
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
        Catch ex As Exception
            MessageBox.Show("Error fetching product types: " & ex.Message)
        Finally
            conn.Close()
        End Try

        Return types.ToList()
    End Function


    Public Sub CreateCartItemPanel(productID As Integer, productName As String, size As String, color As String, brand As String, quantity As Integer, imagePath As String, container As FlowLayoutPanel, newCartForm As newCart)

        Dim panel As New Panel With {
        .Width = 471,
        .Height = 165,
        .BorderStyle = BorderStyle.FixedSingle
    }

        ' Brand label
        Dim brandLabel As New Label With {
        .Text = brand.ToLower(),
        .Font = New Font("Microsoft Sans Serif", 9, FontStyle.Bold),
        .AutoSize = True,
        .Location = New Point(4, 3)
    }
        panel.Controls.Add(brandLabel)

        ' Product Image
        Dim productImage As New PictureBox With {
        .Size = New Size(120, 120),
        .SizeMode = PictureBoxSizeMode.StretchImage,
        .Location = New Point(19, 30)
    }
        If File.Exists(imagePath) Then
            productImage.Image = Image.FromFile(imagePath)
        End If
        panel.Controls.Add(productImage)

        ' Product Name Label
        Dim nameLabel As New Label With {
        .Text = productName,
        .Font = New Font("Microsoft Sans Serif", 10),
        .Location = New Point(147, 36),
        .AutoSize = True
    }
        panel.Controls.Add(nameLabel)

        ' Size Label
        Dim sizeLabel As New Label With {
        .Text = "Size: " & size,
        .Font = New Font("Microsoft Sans Serif", 9),
        .Location = New Point(147, 57),
        .AutoSize = True
    }
        panel.Controls.Add(sizeLabel)

        ' Color Label
        Dim colorLabel As New Label With {
        .Text = "Color: " & color,
        .Font = New Font("Microsoft Sans Serif", 9),
        .Location = New Point(147, 76),
        .AutoSize = True
    }
        panel.Controls.Add(colorLabel)

        ' Quantity Label
        Dim qtyLabel As New Label With {
        .Text = quantity.ToString(),
        .Font = New Font("Microsoft Sans Serif", 10),
        .Location = New Point(408, 114),
        .AutoSize = True
    }
        panel.Controls.Add(qtyLabel)

        ' Decrease Quantity Button
        Dim minusBtn As New Button With {
        .Text = "-",
        .Width = 25,
        .Height = 25,
        .Location = New Point(374, 114)
    }
        AddHandler minusBtn.Click, Sub()
                                       If quantity > 1 Then
                                           quantity -= 1
                                           qtyLabel.Text = quantity.ToString()

                                           ' 🔄 Update in database
                                           UpdateCartQuantity(loggedInUserID, productID, size, quantity)

                                       ElseIf quantity = 1 Then
                                           ' ❌ Delete from cart in database
                                           DeleteFromCart(loggedInUserID, productID, size)
                                           newCartForm.CartPanel.Controls.Clear()
                                           newCartForm.LoadCartItems()


                                       End If
                                   End Sub
        panel.Controls.Add(minusBtn)

        ' Increase Quantity Button
        Dim plusBtn As New Button With {
        .Text = "+",
        .Width = 25,
        .Height = 25,
        .Location = New Point(443, 114)
    }
        AddHandler plusBtn.Click, Sub()
                                      quantity += 1
                                      qtyLabel.Text = quantity.ToString()

                                      ' 🔄 Update in database
                                      UpdateCartQuantity(loggedInUserID, productID, size, quantity)

                                  End Sub
        panel.Controls.Add(plusBtn)

        ' Checkout Selection Radio Button
        Dim selectRadio As New RadioButton With {
        .Location = New Point(19, 84),
        .Width = 20,
        .Height = 20
    }
        panel.Controls.Add(selectRadio)

        container.Controls.Add(panel)
    End Sub

    Public Function GetCartItems(customerID As Integer) As List(Of CartItem)
        Dim cartItems As New List(Of CartItem)()

        Dim query As String = "
        SELECT 
            c.product_id,
            p.product_name,
            p.color,
            b.brand_name,
            c.size,
            c.quantity,
            p.image_path
        FROM cart c
        INNER JOIN products p ON c.product_id = p.product_id
        INNER JOIN brands b ON p.brand_id = b.brand_id
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
                                .Size = reader("size").ToString(),
                                .Quantity = Convert.ToInt32(reader("quantity")),
                                .ImagePath = reader("image_path").ToString()
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











End Module
