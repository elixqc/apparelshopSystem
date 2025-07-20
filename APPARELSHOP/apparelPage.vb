Imports MySql.Data.MySqlClient

Public Class apparelPage

    Dim conn As New MySqlConnection("server=localhost;userid=root;password=;database=apparelshopdb")

    Private Sub apparelPage_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Reset values
        selectedSweatsColor = ""
        selectedShirtColor = ""
        selectedHoodieColor = ""
        selectedSweatpantsColor = ""

        ' Reset combo boxes and quantities
        sweatshirtSize.SelectedIndex = -1
        shirtSize.SelectedIndex = -1
        hoodieSize.SelectedIndex = -1
        sweatpantSize.SelectedIndex = -1

        sweatshirtQty.Text = "Quantity"
        shirtQty.Text = "Quantity"
        hoodieQty.Text = "Quantity"
        sweatpantQty.Text = "Quantity"

        'show total stocks for each product



        ' You can also set placeholder text or reset inputs here
        sweatshirtQty.Text = "Quantity"
        sweatshirtQty.ForeColor = Color.Gray
        shirtQty.Text = "Quantity"
        shirtQty.ForeColor = Color.Gray
        hoodieQty.Text = "Quantity"
        hoodieQty.ForeColor = Color.Gray
        sweatpantQty.Text = "Quantity"
        sweatpantQty.ForeColor = Color.Gray

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        appthemes.FadeOutForm(Me)
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



    Private Sub sweatshirtAddToCart_Click(sender As Object, e As EventArgs) Handles sweatshirtAddToCart.Click









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

    Private Sub tshirtAddtocart_Click_1(sender As Object, e As EventArgs) Handles tshirtAddtocart.Click




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

    Private Sub hoodieAddToCart_Click_1(sender As Object, e As EventArgs) Handles hoodieAddToCart.Click




    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click


    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles sweatWhite.Click









    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click


    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click


    End Sub

    Private Sub Button6_Click_1(sender As Object, e As EventArgs) Handles Button6.Click


    End Sub

    Private Sub Button10_Click_1(sender As Object, e As EventArgs) Handles Button10.Click


    End Sub

    Private Sub Button9_Click_1(sender As Object, e As EventArgs) Handles Button9.Click


    End Sub

    Private Sub Button8_Click_1(sender As Object, e As EventArgs) Handles Button8.Click


    End Sub

    Private Sub Button7_Click_1(sender As Object, e As EventArgs) Handles Button7.Click


    End Sub




    Private Sub Button11_Click_1(sender As Object, e As EventArgs) Handles Button11.Click


    End Sub

    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles Button1.Click


    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        sweatpantsPic.Image = My.Resources.black_Sweatpants
        selectedSweatpantsColor = "Black"
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        sweatpantsPic.Image = My.Resources.white_sweatpants
        selectedSweatpantsColor = "White"
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        sweatpantsPic.Image = My.Resources.gray_Sweatpants
        selectedSweatpantsColor = "Gray"
    End Sub

    Private Sub sweatpantAddToCart_Click(sender As Object, e As EventArgs) Handles sweatpantAddToCart.Click



    End Sub


    Private Sub sweatshirtQty_Enter_1(sender As Object, e As EventArgs) Handles sweatshirtQty.Enter
        If sweatshirtQty.Text = "Quantity" Then
            sweatshirtQty.Text = ""
            sweatshirtQty.ForeColor = Color.Black
        End If
    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint

    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

    End Sub

    Private Sub hoodiePic_Click(sender As Object, e As EventArgs) Handles hoodiePic.Click

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub shirtQty_MouseEnter(sender As Object, e As EventArgs) Handles shirtQty.MouseEnter

    End Sub

    Private Sub shirtQty_Enter(sender As Object, e As EventArgs) Handles shirtQty.Enter
        If shirtQty.Text = "Quantity" Then
            shirtQty.Text = ""
            shirtQty.ForeColor = Color.Black
        End If
    End Sub

    Private Sub hoodieQty_Enter_1(sender As Object, e As EventArgs) Handles hoodieQty.Enter
        If hoodieQty.Text = "Quantity" Then
            hoodieQty.Text = ""
            hoodieQty.ForeColor = Color.Black
        End If
    End Sub

    Private Sub sweatpantQty_TextChanged(sender As Object, e As EventArgs) Handles sweatpantQty.TextChanged
        sweatpantQty.Text = ""
    End Sub

    Private Sub sweatpantQty_Enter(sender As Object, e As EventArgs) Handles sweatpantQty.Enter
        If sweatpantQty.Text = "Quantity" Then
            sweatpantQty.Text = ""
            sweatpantQty.ForeColor = Color.Black
        End If

    End Sub

    Private Sub sweatshirtQty_Leave_1(sender As Object, e As EventArgs) Handles sweatshirtQty.Leave
        If sweatshirtQty.Text = "" Then
            sweatshirtQty.Text = "Quantity"
            sweatshirtQty.ForeColor = Color.Gray
        End If


    End Sub

    Private Sub shirtQty_Leave_1(sender As Object, e As EventArgs) Handles shirtQty.Leave
        If shirtQty.Text = "" Then
            shirtQty.Text = "Quantity"
            shirtQty.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub hoodieQty_Leave_1(sender As Object, e As EventArgs) Handles hoodieQty.Leave
        If hoodieQty.Text = "" Then
            hoodieQty.Text = "Quantity"
            hoodieQty.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub sweatpantQty_Leave(sender As Object, e As EventArgs) Handles sweatpantQty.Leave
        If sweatpantQty.Text = "" Then
            sweatpantQty.Text = "Quantity"
            sweatpantQty.ForeColor = Color.Gray
        End If
    End Sub


End Class