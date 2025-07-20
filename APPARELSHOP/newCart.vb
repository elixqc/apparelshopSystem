Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Drawing
Public Class newCart

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
        exitButton.Location = New Point(Me.ClientSize.Width - exitButton.Width - 10, 10) ' 10px margin from right and top
        AddHandler exitButton.Click, Sub()
                                         Me.Close()
                                     End Sub



        CartPanel.Controls.Add(exitButton)
        CartPanel.Controls.Add(titleLabel)


        Dim customerID As Integer = loggedInUserID ' replace with your actual customer ID variable
        Dim cartItems As List(Of CartItem) = GetCartItems(customerID)

        For Each item In cartItems
            CreateCartItemPanel(item.ProductID, item.Name, item.Size, item.Color, item.Brand, item.Quantity, item.ImagePath, CartPanel, Me)
        Next
    End Sub
    Private Sub CartPanel_Paint(sender As Object, e As PaintEventArgs) Handles CartPanel.Paint

    End Sub

    Private Sub newCart_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CartPanel.Controls.Clear()
        LoadCartItems()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub
End Class