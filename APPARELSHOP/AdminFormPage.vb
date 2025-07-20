Imports MySql.Data.MySqlClient

Public Class AdminFormPage
    Public Property PendingUploadFilePath As String

    Private Sub LoadCategories()
        CategoryLists.Items.Clear()
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim cmd As New MySqlCommand("SELECT category_id, category_name FROM categories", conn)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        ' You can use just the name, or both id and name
                        CategoryLists.Items.Add(reader("category_name").ToString())
                    End While
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading categories: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadSuppliers()
        SupplierLists.Items.Clear()
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim cmd As New MySqlCommand("SELECT supplier_id, supplier_name FROM suppliers", conn)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        SupplierLists.Items.Add(reader("supplier_name").ToString())
                    End While
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading suppliers: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadBrands()
        brandTxt.Items.Clear()
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim cmd As New MySqlCommand("SELECT brand_name FROM brands", conn)
                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        brandTxt.Items.Add(reader("brand_name").ToString())
                    End While
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading brands: " & ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles FileUploadButton.Click

        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "All Files (*.*)|*.*"
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            ' Store the file path for later upload
            selectedFilePath = openFileDialog.FileName


        End If
    End Sub

    Private Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        ' Get values from controls
        Dim rawName As String = productNameTxt.Text.Trim()
        Dim rawColor As String = ColorTxt.Text.Trim()
        Dim rawSize As String = sizeTxt.Text.Trim()

        ' Format: first letter uppercase, rest lowercase for name and color; size all lowercase
        Dim formattedName As String = If(rawName.Length > 0, Char.ToUpper(rawName(0)) & rawName.Substring(1).ToLower(), "")
        Dim formattedColor As String = If(rawColor.Length > 0, Char.ToUpper(rawColor(0)) & rawColor.Substring(1).ToLower(), "")
        Dim formattedSize As String = rawSize.ToLower()

        ' Build product_name string
        Dim productNameForDb As String = $"{formattedName} - {formattedColor} - {formattedSize}"




        ' Get selected category_id
        Dim categoryId As Integer = -1
        Using conn As New MySqlConnection(connectionString)
            conn.Open()
            Dim catCmd As New MySqlCommand("SELECT category_id FROM categories WHERE category_name = @name", conn)
            catCmd.Parameters.AddWithValue("@name", CategoryLists.SelectedItem?.ToString())
            Dim catObj = catCmd.ExecuteScalar()
            If catObj IsNot Nothing Then categoryId = Convert.ToInt32(catObj)
        End Using

        ' Get selected supplier_id
        Dim supplierId As Integer = -1
        Using conn As New MySqlConnection(connectionString)
            conn.Open()
            Dim supCmd As New MySqlCommand("SELECT supplier_id FROM suppliers WHERE supplier_name = @name", conn)
            supCmd.Parameters.AddWithValue("@name", SupplierLists.SelectedItem?.ToString())
            Dim supObj = supCmd.ExecuteScalar()
            If supObj IsNot Nothing Then supplierId = Convert.ToInt32(supObj)
        End Using

        ' Get selected brand_id
        Dim brandId As Integer = -1
        Using conn As New MySqlConnection(connectionString)
            conn.Open()
            Dim brandCmd As New MySqlCommand("SELECT brand_id FROM brands WHERE brand_name = @name", conn)
            brandCmd.Parameters.AddWithValue("@name", brandTxt.SelectedItem?.ToString())
            Dim brandObj = brandCmd.ExecuteScalar()
            If brandObj IsNot Nothing Then brandId = Convert.ToInt32(brandObj)
        End Using

        ' Get price and quantity
        Dim priceValue As Decimal = 0
        Decimal.TryParse(PriceTxt.Text.Trim(), priceValue)
        Dim quantityValue As Integer = 0
        Integer.TryParse(QuantityList.Text.Trim(), quantityValue)

        ' Check if product already exists
        Dim productExists As Boolean = False
        Dim existingProductId As Integer = -1




        Using conn As New MySqlConnection(connectionString)
            conn.Open()
            Dim checkCmd As New MySqlCommand("SELECT product_id, stock_quantity FROM products WHERE product_name = @pname", conn)
            checkCmd.Parameters.AddWithValue("@pname", productNameForDb)
            Using reader As MySqlDataReader = checkCmd.ExecuteReader()
                If reader.Read() Then
                    productExists = True
                    existingProductId = Convert.ToInt32(reader("product_id"))
                End If
            End Using
        End Using

        If productExists Then
            ' Fetch current stock quantity
            Dim currentStock As Integer = 0
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim stockCmd As New MySqlCommand("SELECT stock_quantity FROM products WHERE product_id = @pid", conn)
                stockCmd.Parameters.AddWithValue("@pid", existingProductId)
                Dim result = stockCmd.ExecuteScalar()
                If result IsNot Nothing Then currentStock = Convert.ToInt32(result)
            End Using

            ' Add the new quantity to the current stock
            Dim newStock As Integer = currentStock + quantityValue

            ' Update price and stock quantity
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim updateCmd As New MySqlCommand("UPDATE products SET price = @price, stock_quantity = @qty WHERE product_id = @pid", conn)
                updateCmd.Parameters.AddWithValue("@price", priceValue)
                updateCmd.Parameters.AddWithValue("@qty", newStock)
                updateCmd.Parameters.AddWithValue("@pid", existingProductId)
                updateCmd.ExecuteNonQuery()
                MessageBox.Show("Product updated successfully!")
            End Using
            Exit Sub
        End If

        ' If product does not exist, require image upload
        If String.IsNullOrEmpty(selectedFilePath) OrElse Not System.IO.File.Exists(selectedFilePath) Then
            MessageBox.Show("No file selected or file does not exist.")
            Return
        End If

        Dim imagesFolder As String = System.IO.Path.Combine(Application.StartupPath, "images")
        If Not System.IO.Directory.Exists(imagesFolder) Then
            System.IO.Directory.CreateDirectory(imagesFolder)
        End If
        Dim destPath As String = System.IO.Path.Combine(imagesFolder, System.IO.Path.GetFileName(selectedFilePath))
        System.IO.File.Copy(selectedFilePath, destPath, True)
        imagePathForDb = "images\" & System.IO.Path.GetFileName(selectedFilePath)

        ' Insert new product (same as before)
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim insertCmd As New MySqlCommand("
                INSERT INTO products 
                (product_name, color, size, category_id, supplier_id, brand_id, price, stock_quantity, image_path)
                VALUES
                (@pname, @color, @size, @catid, @supid, @brid, @price, @qty, @imgpath)
            ", conn)
                insertCmd.Parameters.AddWithValue("@pname", productNameForDb)
                insertCmd.Parameters.AddWithValue("@color", ColorTxt.Text.Trim())
                insertCmd.Parameters.AddWithValue("@size", sizeTxt.Text.Trim())
                insertCmd.Parameters.AddWithValue("@catid", categoryId)
                insertCmd.Parameters.AddWithValue("@supid", supplierId)
                insertCmd.Parameters.AddWithValue("@brid", brandId)
                insertCmd.Parameters.AddWithValue("@price", priceValue)
                insertCmd.Parameters.AddWithValue("@qty", quantityValue)
                insertCmd.Parameters.AddWithValue("@imgpath", imagePathForDb)
                insertCmd.ExecuteNonQuery()
                MessageBox.Show("Product added successfully!")
            End Using
        Catch ex As Exception
            MessageBox.Show("Error adding product: " & ex.Message)
        End Try

        selectedFilePath = "" ' Clear after upload
    End Sub

    Private Sub btnUpload_Click_1(sender As Object, e As EventArgs) Handles btnUpload.Click

    End Sub

    Private Sub AdminFormPage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCategories()
        LoadSuppliers()
        LoadBrands()
    End Sub

    Private Sub addProductPanel_Paint(sender As Object, e As PaintEventArgs) Handles addProductPanel.Paint

    End Sub

    Private Sub brandTxt_SelectedIndexChanged(sender As Object, e As EventArgs) Handles brandTxt.SelectedIndexChanged

    End Sub

    Private Sub SupplierLists_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SupplierLists.SelectedIndexChanged

    End Sub

    Private Sub CategoryLists_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CategoryLists.SelectedIndexChanged

    End Sub

    Private Sub QuantityList_TextChanged(sender As Object, e As EventArgs) Handles QuantityList.TextChanged

    End Sub

    Private Sub PriceTxt_TextChanged(sender As Object, e As EventArgs) Handles PriceTxt.TextChanged

    End Sub

    Private Sub ColorTxt_TextChanged(sender As Object, e As EventArgs) Handles ColorTxt.TextChanged

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk

    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged

    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub

    Private Sub FileSystemWatcher1_Changed(sender As Object, e As IO.FileSystemEventArgs) Handles FileSystemWatcher1.Changed

    End Sub

    Private Sub productNameTxt_TextChanged(sender As Object, e As EventArgs) Handles productNameTxt.TextChanged

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub

    Private Sub sizeTxt_SelectedIndexChanged(sender As Object, e As EventArgs) Handles sizeTxt.SelectedIndexChanged

    End Sub
End Class