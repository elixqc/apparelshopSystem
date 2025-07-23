Imports System.Drawing
Imports System.IO
Imports APPARELSHOP.globals
Imports MySql.Data.MySqlClient

Public Class newCart


    Public Sub UpdateSubtotalLabel(cartPanel As FlowLayoutPanel)
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
            CreateCartItemPanel(item.ProductID, item.Name, item.Size, item.Color, item.Brand, item.Quantity, item.ImagePath, item.Price, CartPanel, Me)

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
            .BackColor = Color.Black,
            .ForeColor = Color.White,
            .Margin = New Padding(10)
        }
        checkoutBtn.Location = New Point((Me.ClientSize.Width - checkoutBtn.Width) \ 2, Me.ClientSize.Height - checkoutBtn.Height - 20)

        AddHandler checkoutBtn.Click, Sub()
                                          If cartItems.Count = 0 Then
                                              MessageBox.Show("Your cart is empty.")
                                              Return
                                          End If

                                          Dim confirmResult = MessageBox.Show("Your subtotal is ₱" & subtotal.ToString("F2") & vbCrLf & "Do you want to proceed to checkout?", "Confirm Checkout", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                          If confirmResult <> DialogResult.Yes Then
                                              Return
                                          End If

                                          ' 1. Insert new order
                                          Dim orderId As Integer = -1
                                          Dim deliveryAddress As String = ""

                                          ' Get delivery address from customer profile
                                          Using conn1 As New MySqlConnection(connectionString)
                                              conn1.Open()
                                              Dim getAddressCmd As New MySqlCommand("SELECT address FROM customers WHERE customer_id = @cid", conn1)
                                              getAddressCmd.Parameters.AddWithValue("@cid", loggedInUserID)
                                              Dim addrResult = getAddressCmd.ExecuteScalar()
                                              If addrResult IsNot Nothing Then
                                                  deliveryAddress = addrResult.ToString()
                                              End If
                                          End Using

                                          ' Insert order including delivery address
                                          Using conn2 As New MySqlConnection(connectionString)
                                              conn2.Open()
                                              Dim insertOrderCmd As New MySqlCommand("
                                                        INSERT INTO orders (customer_id, order_date, order_status, delivery_address)
                                                        VALUES (@cid, NOW(), 'Pending', @address);
                                                        SELECT LAST_INSERT_ID();", conn2)
                                              insertOrderCmd.Parameters.AddWithValue("@cid", loggedInUserID)
                                              insertOrderCmd.Parameters.AddWithValue("@address", deliveryAddress)
                                              orderId = Convert.ToInt32(insertOrderCmd.ExecuteScalar())
                                          End Using


                                          ' 2. Insert order details
                                          Using conn As New MySqlConnection(connectionString)
                                              conn.Open()
                                              For Each item In cartItems
                                                  Dim priceCmd As New MySqlCommand("SELECT price FROM products WHERE product_id = @pid", conn)
                                                  priceCmd.Parameters.AddWithValue("@pid", item.ProductID)
                                                  Dim unitPrice As Decimal = Convert.ToDecimal(priceCmd.ExecuteScalar())

                                                  Dim detailCmd As New MySqlCommand("INSERT INTO order_details (order_id, product_id, quantity, unit_price) VALUES (@oid, @pid, @qty, @price)", conn)
                                                  detailCmd.Parameters.AddWithValue("@oid", orderId)
                                                  detailCmd.Parameters.AddWithValue("@pid", item.ProductID)
                                                  detailCmd.Parameters.AddWithValue("@qty", item.Quantity)
                                                  detailCmd.Parameters.AddWithValue("@price", unitPrice)
                                                  detailCmd.ExecuteNonQuery()
                                              Next
                                          End Using

                                          ' 3. Clear cart
                                          Using conn As New MySqlConnection(connectionString)
                                              conn.Open()
                                              Dim clearCmd As New MySqlCommand("DELETE FROM cart WHERE customer_id = @cid", conn)
                                              clearCmd.Parameters.AddWithValue("@cid", loggedInUserID)
                                              clearCmd.ExecuteNonQuery()
                                          End Using

                                          MessageBox.Show("Checkout successful! Your order has been placed.")
                                          CartPanel.Controls.Clear()
                                          LoadCartItems()
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