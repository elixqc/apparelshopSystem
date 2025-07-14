Imports MySql.Data.MySqlClient

Module globals

    Dim conn As New MySqlConnection("server=localhost;userid=root;password=;database=apparelshopdb")


    Public loggedInUserID As Integer = 0
    Public loggedInUserEmail As String = ""
    Public loggedInUserFullName As String = ""
    Public selectedSweatsColor As String = ""
    Public selectedShirtColor As String = ""
    Public selectedHoodieColor As String = ""
    Public selectedSweatpantsColor As String = ""

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





End Module
