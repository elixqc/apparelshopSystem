Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Drawing



Module globals

    Dim conn As New MySqlConnection("server=localhost;userid=root;password=;database=apparelshopdb")


    Public loggedInUserID As Integer = 0
    Public loggedInUserEmail As String = ""
    Public loggedInUserFullName As String = ""
    Public selectedSweatsColor As String = ""
    Public selectedShirtColor As String = ""
    Public selectedHoodieColor As String = ""
    Public selectedSweatpantsColor As String = ""
    Dim selectedColor As String = ""

    Public Sub ShowStock(productName As String, stockLabel As Label)
        Try
            conn.Open()
            Dim cmd As New MySqlCommand("SELECT stock_quantity FROM products WHERE product_name = @pname", conn)
            cmd.Parameters.AddWithValue("@pname", productName)

            Dim stockObj As Object = cmd.ExecuteScalar()

            If stockObj IsNot Nothing Then
                stockLabel.Text = "Stock: " & stockObj.ToString()
            Else
                stockLabel.Text = "Stock: N/A"
            End If
        Catch ex As Exception
            MessageBox.Show("Error fetching stock: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Public Sub ShowStockSpecificColor(productPrefix As String, stockLabel As Label)
        Try
            conn.Open()
            Dim cmd As New MySqlCommand("SELECT SUM(stock_quantity) FROM products WHERE product_name LIKE @pname", conn)
            cmd.Parameters.AddWithValue("@pname", productPrefix & " - %") ' Match all sizes

            Dim totalStockObj As Object = cmd.ExecuteScalar()

            If totalStockObj IsNot Nothing AndAlso Not IsDBNull(totalStockObj) Then
                stockLabel.Text = "Stock: " & totalStockObj.ToString()
            Else
                stockLabel.Text = "Stock: 0"
            End If
        Catch ex As Exception
            MessageBox.Show("Error fetching stock: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Public Sub ShowStockTotal(productType As String, stockLabel As Label)
        Try
            conn.Open()
            Dim cmd As New MySqlCommand("SELECT SUM(stock_quantity) FROM products WHERE product_name LIKE @pname", conn)
            cmd.Parameters.AddWithValue("@pname", productType & "%") ' No dash, so it matches all colors/sizes

            Dim totalStockObj As Object = cmd.ExecuteScalar()

            If totalStockObj IsNot Nothing AndAlso Not IsDBNull(totalStockObj) Then
                stockLabel.Text = "Stock: " & totalStockObj.ToString()
            Else
                stockLabel.Text = "Stock: 0"
            End If
        Catch ex As Exception
            MessageBox.Show("Error fetching stock: " & ex.Message)
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


        ' Connect to DB
        Try
            conn.Open()
            Dim cmd As New MySqlCommand("SELECT product_name, size, image_path, price, stock_quantity FROM products WHERE product_name LIKE @type", conn)

            cmd.Parameters.AddWithValue("@type", productType & "%")
            Dim reader = cmd.ExecuteReader()

            While reader.Read()
                Dim fullName As String = reader("product_name").ToString()
                Dim size As String = reader("size").ToString()
                Dim imagePath As String = reader("image_path").ToString()
                totalStock += Convert.ToInt32(reader("stock_quantity"))
                If Not firstPriceCaptured Then
                    priceValue = Convert.ToDecimal(reader("price"))
                    firstPriceCaptured = True
                End If


                sizes.Add(size)

                Dim lastDash1 = fullName.LastIndexOf("-")
                Dim lastDash2 = If(lastDash1 > 0, fullName.LastIndexOf("-", lastDash1 - 1), -1)

                If lastDash2 >= 0 AndAlso lastDash1 > lastDash2 Then
                    Dim color = fullName.Substring(lastDash2 + 1, lastDash1 - lastDash2 - 1).Trim()
                    If Not colorImageMap.ContainsKey(color) Then
                        colorImageMap.Add(color, imagePath)
                    End If
                Else
                    MessageBox.Show("Skipping color parse: " & fullName)
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
        Dim baseName As String = productType.Trim()

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
                                         selectedColor = clickedColor ' ← Save the selected color here
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
                                           If String.IsNullOrEmpty(selectedSize) Then
                                               MessageBox.Show("Select a size")
                                               Return
                                           End If
                                           If loggedInUserID = 0 Then
                                               MsgBox("Please Login First")
                                               Return
                                           End If









                                           Dim fullProductName = $"{productType} - {selectedColor} - {selectedSize}"

                                           AddToCart(fullProductName, qty, selectedSize)

                                           MsgBox("product quantity:" & qty)
                                           MsgBox("size: " & selectedSize)
                                           MsgBox(fullProductName)


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










End Module
