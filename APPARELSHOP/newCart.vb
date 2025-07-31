Imports System.Drawing
Imports System.IO
Imports APPARELSHOP.globals
Imports MySql.Data.MySqlClient

Public Class newCart

    Public Sub UpdateSubtotalLabel(cartPanel As FlowLayoutPanel)
        ' This function calculates the subtotal from the cart items and updates the subtotal label
        Dim subtotal As Decimal = 0

        For Each ctrl As Control In cartPanel.Controls
            If TypeOf ctrl Is Panel Then
                Dim panel As Panel = DirectCast(ctrl, Panel)
                Dim qtyLabel = panel.Controls.OfType(Of Label)().FirstOrDefault(Function(l) l.Name = "qtyLabel")
                Dim priceLabel = panel.Controls.OfType(Of Label)().FirstOrDefault(Function(l) l.Name = "priceLabel")

                If qtyLabel IsNot Nothing AndAlso priceLabel IsNot Nothing Then
                    Dim qty As Integer = 0
                    Dim price As Decimal = 0

                    Integer.TryParse(qtyLabel.Text, qty)
                    Decimal.TryParse(priceLabel.Tag.ToString(), price)

                    subtotal += qty * price
                End If
            End If
        Next

        ' Now find the subtotalLabel inside cartPanel using the helper
        Dim subtotalLbl = TryCast(FindControlByName(cartPanel, "subtotalLabel"), Label)
        If subtotalLbl IsNot Nothing Then
            subtotalLbl.Text = "Subtotal: ₱" & subtotal.ToString("F2")
        End If
    End Sub



    '    ' Helper function to find a control by name in a container
    Public Sub LoadCartItems()
        CartPanel.Controls.Clear() ' Clear old items if any

        Dim titleLabel As New Label With {
        .Text = "SHOPPING CART",
        .Font = New Font("Microsoft Himalaya", 16, FontStyle.Regular),
        .AutoSize = True,
        .Margin = New Padding(5),
        .ForeColor = Color.Black
    }
        titleLabel.Location = New Point((Me.ClientSize.Width - titleLabel.PreferredWidth) \ 2, 10)

        Dim exitButton As New PictureBox With {
        .SizeMode = PictureBoxSizeMode.StretchImage,
        .Width = 25,
        .Height = 25,
        .Anchor = AnchorStyles.Top Or AnchorStyles.Right,
        .Image = Image.FromFile("Images\xbuttfinal.png")
    }
        exitButton.Location = New Point(Me.ClientSize.Width - exitButton.Width - 10, 10)
        AddHandler exitButton.Click, Sub()
                                         Me.Close()
                                     End Sub

        CartPanel.Controls.Add(exitButton)
        CartPanel.Controls.Add(titleLabel)

        Dim customerID As Integer = loggedInUserID
        Dim cartItems As List(Of CartItem) = GetCartItems(customerID)

        Dim subtotal As Decimal = 0D
        For Each item In cartItems
            CreateCartItemPanel(item.ProductID, item.Name, item.Size, item.Color, item.Brand, item.Quantity, item.ImagePath, item.Price, item.MaxStock, CartPanel, Me)


            ' Get price for each item
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim priceCmd As New MySqlCommand("SELECT price FROM products WHERE product_id = @pid", conn)
                priceCmd.Parameters.AddWithValue("@pid", item.ProductID)
                Dim unitPrice As Decimal = Convert.ToDecimal(priceCmd.ExecuteScalar())
                subtotal += unitPrice * item.Quantity
            End Using
        Next

        ' --- Subtotal Label ---
        Dim subtotalLabel As New Label With {
        .Name = "subtotalLabel", ' IMPORTANT!
        .Text = "Subtotal: ₱0.00",
        .Font = New Font("Microsoft Himalaya", 15, FontStyle.Bold),
        .AutoSize = True,
        .ForeColor = Color.Black,
        .Margin = New Padding(10)
    }

        subtotalLabel.Location = New Point((Me.ClientSize.Width - subtotalLabel.PreferredWidth) \ 2, Me.ClientSize.Height - 120)
        CartPanel.Controls.Add(subtotalLabel)


        ' --- Add Checkout Button at the bottom ---
        Dim checkoutBtn As New Button With {
            .Text = "Checkout",
            .Font = New Font("Microsoft Himalaya", 14, FontStyle.Bold),
            .Width = 120,
            .Height = 40,
            .BackColor = Color.FromArgb(74, 80, 66),
            .FlatStyle = FlatStyle.Flat,
            .ForeColor = Color.White,
            .Margin = New Padding(10)
        }
        checkoutBtn.Location = New Point((Me.ClientSize.Width - checkoutBtn.Width) \ 2, Me.ClientSize.Height - checkoutBtn.Height - 20)

        AddHandler checkoutBtn.Click, Sub()
                                          If cartItems.Count = 0 Then
                                              MessageBox.Show("Your cart is empty.")
                                              Return
                                          End If

                                          ' Declare variables to use throughout
                                          Dim deliveryAddress As String = ""
                                          Dim contactNumber As String = ""
                                          Dim paymentMethod As String = ""
                                          Dim paymentReference As String = ""

                                          ' Step 1: Fetch delivery address and contact number
                                          Try
                                              Using conn As New MySqlConnection(connectionString)
                                                  conn.Open()
                                                  Dim getInfoCmd As New MySqlCommand("SELECT address, contact_number FROM customers WHERE customer_id = @cid", conn)
                                                  getInfoCmd.Parameters.AddWithValue("@cid", loggedInUserID)

                                                  Using reader = getInfoCmd.ExecuteReader()
                                                      If reader.Read() Then
                                                          deliveryAddress = reader("address").ToString()
                                                          contactNumber = reader("contact_number").ToString()
                                                      End If
                                                  End Using
                                              End Using
                                          Catch ex As Exception
                                              MessageBox.Show("Failed to fetch customer info: " & ex.Message)
                                              Return
                                          End Try

                                          ' Step 2: Confirm checkout details
                                          Dim confirmResult = MessageBox.Show("Subtotal: ₱" & subtotal.ToString("F2") & vbCrLf &
                                                                              "Delivery Address: " & deliveryAddress & vbCrLf &
                                                                              "Contact Number: " & contactNumber & vbCrLf & vbCrLf &
                                                                              "Do you want to proceed to checkout?",
                                                                              "Confirm Checkout", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                          If confirmResult <> DialogResult.Yes Then Return

                                          ' Step 3: Select payment method
                                          Dim paymentMethodDialog As DialogResult = MessageBox.Show("Select payment method:" & vbCrLf &
                                                                                                    "Yes = Cash on Delivery" & vbCrLf &
                                                                                                    "No = eWallet (Scan QR Code)",
                                                                                                    "Payment Method",
                                                                                                    MessageBoxButtons.YesNoCancel,
                                                                                                    MessageBoxIcon.Question)

                                          If paymentMethodDialog = DialogResult.Cancel Then Return

                                          paymentMethod = If(paymentMethodDialog = DialogResult.Yes, "COD", "eWallet")

                                          ' Step 4: Show QR form and get reference number if eWallet
                                          If paymentMethod = "eWallet" Then
                                              Dim qrForm As New Form With {
                                                  .Text = "Scan QR Code to Pay",
                                                  .Size = New Size(350, 600),
                                                  .StartPosition = FormStartPosition.CenterParent,
                                                  .FormBorderStyle = FormBorderStyle.None,
                                                  .MaximizeBox = False,
                                                  .MinimizeBox = False
                                              }
                                              Dim qrPicture As New PictureBox With {
                                                    .Image = Image.FromFile("Images\qr.png"),
                                                    .SizeMode = PictureBoxSizeMode.StretchImage,
                                                    .Location = New Point(10, 10),
                                                    .Size = New Size(300, 430)
                                                }

                                              Dim refLabel As New Label With {
                                                    .Text = "Enter GCash Reference No.:",
                                                    .Location = New Point(20, 450), ' Below the picture
                                                    .AutoSize = True
                                                }

                                              Dim refTextbox As New TextBox With {
                                                    .Location = New Point(20, 470), ' Just below label
                                                    .Width = 260
                                                }

                                              Dim doneBtn As New Button With {
                                                    .Text = "Done Paying",
                                                    .Size = New Size(120, 40),
                                                    .Location = New Point((qrForm.ClientSize.Width - 120) \ 2, 510), ' Below textbox and centered
                                                    .BackColor = Color.Black,
                                                    .ForeColor = Color.White
                                                }


                                              AddHandler doneBtn.Click, Sub()
                                                                            If String.IsNullOrWhiteSpace(refTextbox.Text) Then
                                                                                MessageBox.Show("Please enter the reference number.")
                                                                                Return
                                                                            End If
                                                                            paymentReference = refTextbox.Text.Trim()
                                                                            qrForm.Close()
                                                                        End Sub

                                              qrForm.Controls.Add(qrPicture)
                                              qrForm.Controls.Add(refLabel)
                                              qrForm.Controls.Add(refTextbox)
                                              qrForm.Controls.Add(doneBtn)
                                              qrForm.ShowDialog()
                                          End If

                                          ' Step 5: Begin TRANSACTION to place the order !!!!
                                          Dim orderId As Integer = -1

                                          Try
                                              Using conn As New MySqlConnection(connectionString)
                                                  conn.Open()
                                                  Dim transaction = conn.BeginTransaction()

                                                  Try
                                                      ' Insert order with payment details
                                                      Dim insertOrderCmd As New MySqlCommand("
                                                INSERT INTO orders (customer_id, order_date, order_status, delivery_address, payment_method, payment_reference)
                                                VALUES (@cid, NOW(), 'Pending', @address, @method, @ref);
                                                SELECT LAST_INSERT_ID();", conn, transaction)
                                                      insertOrderCmd.Parameters.AddWithValue("@cid", loggedInUserID)
                                                      insertOrderCmd.Parameters.AddWithValue("@address", deliveryAddress)
                                                      insertOrderCmd.Parameters.AddWithValue("@method", paymentMethod)
                                                      insertOrderCmd.Parameters.AddWithValue("@ref", If(paymentMethod = "eWallet", paymentReference, DBNull.Value))
                                                      orderId = Convert.ToInt32(insertOrderCmd.ExecuteScalar())

                                                      ' Insert order details
                                                      For Each item In cartItems
                                                          Dim priceCmd As New MySqlCommand("SELECT price FROM products WHERE product_id = @pid", conn, transaction)
                                                          priceCmd.Parameters.AddWithValue("@pid", item.ProductID)
                                                          Dim unitPrice As Decimal = Convert.ToDecimal(priceCmd.ExecuteScalar())

                                                          Dim detailCmd As New MySqlCommand("
                                                INSERT INTO order_details (order_id, product_id, quantity, unit_price)
                                                VALUES (@oid, @pid, @qty, @price)", conn, transaction)
                                                          detailCmd.Parameters.AddWithValue("@oid", orderId)
                                                          detailCmd.Parameters.AddWithValue("@pid", item.ProductID)
                                                          detailCmd.Parameters.AddWithValue("@qty", item.Quantity)
                                                          detailCmd.Parameters.AddWithValue("@price", unitPrice)
                                                          detailCmd.ExecuteNonQuery()
                                                      Next

                                                      ' Clear the cart
                                                      Dim clearCmd As New MySqlCommand("DELETE FROM cart WHERE customer_id = @cid", conn, transaction)
                                                      clearCmd.Parameters.AddWithValue("@cid", loggedInUserID)
                                                      clearCmd.ExecuteNonQuery()

                                                      transaction.Commit()
                                                      MessageBox.Show("Checkout successful! Your order has been placed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                                      CartPanel.Controls.Clear()
                                                      LoadCartItems()
                                                  Catch ex As Exception
                                                      transaction.Rollback()
                                                      MessageBox.Show("Checkout failed: " & ex.Message)
                                                  End Try
                                              End Using
                                          Catch ex As Exception
                                              MessageBox.Show("Unexpected error: " & ex.Message)
                                          End Try
                                      End Sub



        CartPanel.Controls.Add(checkoutBtn)
        UpdateSubtotalLabel(CartPanel)

    End Sub

    Private Sub newCart_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CartPanel.Controls.Clear()
        LoadCartItems()
    End Sub

    Private Sub CartPanel_Paint(sender As Object, e As PaintEventArgs) Handles CartPanel.Paint

    End Sub
End Class