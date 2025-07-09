Imports MySql.Data.MySqlClient

Public Class apparelPage

    Dim conn As New MySqlConnection("server=localhost;userid=root;password=;database=apparelshopdb")

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        sweatshirtPic.Image = My.Resources.white_swsh
        selectedSweatsColor = "White"
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        sweatshirtPic.Image = My.Resources.gray_swsh
        selectedSweatsColor = "Gray"
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        sweatshirtPic.Image = My.Resources.black_swsh
        selectedSweatsColor = "Black"
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)
        sweatshirtPic.Image = My.Resources.pink_swsh
        selectedSweatsColor = "Pink"
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)
        sweatshirtPic.Image = My.Resources.yellow_swsh
        selectedSweatsColor = "Yellow"
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs)


        Dim selectedSize As String = sweatshirtSize.SelectedItem?.ToString()
        Dim quantity As Integer = 0

        'check if customers r alr logged in
        If loggedInUserID = 0 Then
            MsgBox("Please Login First")
            Exit Sub
        End If
        'check size
        If String.IsNullOrEmpty(selectedSize) Then
            MessageBox.Show("Please select a size.")
            Exit Sub
        End If
        'check if quantity is valid (numbers)
        If Not Integer.TryParse(sweatshirtQty.Text, quantity) OrElse quantity <= 0 Then
            MessageBox.Show("Please enter a valid quantity.")
            Exit Sub
        Else
            quantity = sweatshirtQty.Text
        End If
        'declare product name
        Dim productName As String = $"Sweatshirt - {selectedSweatsColor} - {sweatshirtSize.SelectedItem}"

        MessageBox.Show(productName)

        Try

            conn.Open()
            Dim getProductCmd As New MySqlCommand("SELECT product_id FROM products WHERE product_name = @pname", conn)
            getProductCmd.Parameters.AddWithValue("@pname", productName)

            Dim productIdObj As Object = getProductCmd.ExecuteScalar()
            Dim productId As Integer = CInt(productIdObj)

            Dim cartCmd As New MySqlCommand("
                                        INSERT INTO cart (customer_id, product_id, quantity, date_added, size)
                                        VALUES (@cid, @pid, @qty, NOW(), @size)
                                        ON DUPLICATE KEY UPDATE quantity = quantity + @qty, date_added = NOW()", conn)

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

    Private Sub sweatshirtQty_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub sweatshirtQty_Enter(sender As Object, e As EventArgs)
        If sweatshirtQty.Text = "Quantity" Then
            sweatshirtQty.Text = ""
            sweatshirtQty.ForeColor = Color.Black ' Change back to normal color
        End If
    End Sub

    Private Sub sweatshirtSize_SelectedIndexChanged(sender As Object, e As EventArgs)
        For Each ctrl As Control In Me.Controls
            ctrl.TabStop = False
        Next
    End Sub

    Private Sub sweatshirtQty_Leave(sender As Object, e As EventArgs)
        If String.IsNullOrWhiteSpace(sweatshirtQty.Text) Then
            sweatshirtQty.Text = "Quantity"
            sweatshirtQty.ForeColor = Color.Gray ' Make it look like a placeholder
        End If
    End Sub

    Private Sub sweatshirtPanel_Click(sender As Object, e As EventArgs)
        For Each ctrl As Control In Me.Controls
            ctrl.TabStop = False
        Next
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs)
        tshirtPic.Image = My.Resources.white_shirt1
        selectedShirtColor = "White"
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs)
        tshirtPic.Image = My.Resources.blue_shirt1
        selectedShirtColor = "Blue"
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs)
        tshirtPic.Image = My.Resources.brown_shirt1
        selectedShirtColor = "Brown"
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs)
        tshirtPic.Image = My.Resources.green_shirt1
        selectedShirtColor = "Green"
    End Sub

    Private Sub shirtQuantity_Enter(sender As Object, e As EventArgs)
        If shirtQty.Text = "Quantity" Then
            shirtQty.Text = ""
            shirtQty.ForeColor = Color.Black ' Change back to normal color
        End If
    End Sub

    Private Sub shirtQty_Leave(sender As Object, e As EventArgs)
        If String.IsNullOrWhiteSpace(shirtQty.Text) Then
            shirtQty.Text = "Quantity"
            shirtQty.ForeColor = Color.Gray ' Make it look like a placeholder
        End If
    End Sub

    Private Sub sweatshirtPanel_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub tshirtAddtocart_Click(sender As Object, e As EventArgs)

        Dim selectedSize As String = shirtSize.SelectedItem?.ToString()
        Dim quantity As Integer = 0

        'check if customers r alr logged in
        If loggedInUserID = 0 Then
            MsgBox("Please Login First")
            Exit Sub
        End If
        'check size
        If String.IsNullOrEmpty(selectedSize) Then
            MessageBox.Show("Please select a size.")
            Exit Sub
        End If
        'check if quantity is valid (numbers)
        If Not Integer.TryParse(shirtQty.Text, quantity) OrElse quantity <= 0 Then
            MessageBox.Show("Please enter a valid quantity.")
            Exit Sub
        Else
            quantity = shirtQty.Text
        End If
        'declare product name
        Dim productName As String = $"T-shirt - {selectedShirtColor} - {shirtSize.SelectedItem}"

        MessageBox.Show(productName)

        Try

            conn.Open()
            Dim getProductCmd As New MySqlCommand("SELECT product_id FROM products WHERE product_name = @pname", conn)

            getProductCmd.Parameters.AddWithValue("@pname", productName)

            Dim productIdObj As Object = getProductCmd.ExecuteScalar()
            Dim productId As Integer = CInt(productIdObj)

            Dim cartCmd As New MySqlCommand("
                                        INSERT INTO cart (customer_id, product_id, quantity, date_added, size)
                                        VALUES (@cid, @pid, @qty, NOW(), @size)
                                        ON DUPLICATE KEY UPDATE quantity = quantity + @qty, date_added = NOW()", conn)

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

    Private Sub Button13_Click(sender As Object, e As EventArgs)
        hoodiePic.Image = My.Resources.red_hoodie1
        selectedHoodieColor = "Red"
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs)
        hoodiePic.Image = My.Resources.blue_hoodie
        selectedHoodieColor = "Blue"
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs)
        hoodiePic.Image = My.Resources.pink_hoodie
        selectedHoodieColor = "Pink"
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs)
        hoodiePic.Image = My.Resources.yellow_hoodie
        selectedHoodieColor = "Yellow"
    End Sub

    Private Sub hoodieQty_Enter(sender As Object, e As EventArgs)
        If hoodieQty.Text = "Quantity" Then
            shirtQty.Text = ""
            shirtQty.ForeColor = Color.Black ' Change back to normal color
        End If
    End Sub

    Private Sub hoodieQty_Leave(sender As Object, e As EventArgs)
        If String.IsNullOrWhiteSpace(hoodieQty.Text) Then
            hoodieQty.Text = "Quantity"
            hoodieQty.ForeColor = Color.Gray ' Make it look like a placeholder
        End If
    End Sub

    Private Sub hoodieAddToCart_Click(sender As Object, e As EventArgs)

        Dim selectedSize As String = hoodieSize.SelectedItem?.ToString()
        Dim quantity As Integer = 0

        'check if customers r alr logged in
        If loggedInUserID = 0 Then
            MsgBox("Please Login First")
            Exit Sub
        End If
        'check size
        If String.IsNullOrEmpty(selectedSize) Then
            MessageBox.Show("Please select a size.")
            Exit Sub
        End If
        'check if quantity is valid (numbers)
        If Not Integer.TryParse(hoodieQty.Text, quantity) OrElse quantity <= 0 Then
            MessageBox.Show("Please enter a valid quantity.")
            Exit Sub
        Else
            quantity = hoodieQty.Text
        End If
        'declare product name
        Dim productName As String = $"overSizedHoodie - {selectedHoodieColor} - {hoodieSize.SelectedItem}"

        MessageBox.Show(productName)

        Try

            conn.Open()
            Dim getProductCmd As New MySqlCommand("SELECT product_id FROM products WHERE product_name = @pname", conn)

            getProductCmd.Parameters.AddWithValue("@pname", productName)

            Dim productIdObj As Object = getProductCmd.ExecuteScalar()
            Dim productId As Integer = CInt(productIdObj)

            Dim cartCmd As New MySqlCommand("
                                        INSERT INTO cart (customer_id, product_id, quantity, date_added, size)
                                        VALUES (@cid, @pid, @qty, NOW(), @size)
                                        ON DUPLICATE KEY UPDATE quantity = quantity + @qty, date_added = NOW()", conn)

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
End Class