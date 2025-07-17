Imports MySql.Data.MySqlClient
Imports System.IO

Public Class apparelPageSample

    Dim conn As New MySqlConnection("server=localhost;userid=root;password=;database=apparelshopdb")

    Private Sub LoadAllProductPanels()
        Dim productTypes = GetAllProductTypes()
        For Each type In productTypes
            CreateProductPanel(type, Flowproductpanel)
        Next
    End Sub
    Private Sub FlowLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles Flowproductpanel.Paint

    End Sub

    Private Sub btnLoadProducts_Click(sender As Object, e As EventArgs) Handles btnLoadProducts.Click
        Flowproductpanel.Controls.Clear()
        LoadAllProductPanels()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub
End Class