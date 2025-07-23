Imports System.IO
Imports MySql.Data.MySqlClient

Public Class AdminFormPage
    Public Property PendingUploadFilePath As String
    Dim selectedOrderId As Integer = -1


    Public Sub LoadCustomerOrdersToGrid()
        Dim query As String = "
        SELECT 
            o.order_id,
            o.customer_id,
            c.full_name AS customer_name,
            o.order_date,
            o.order_status,
            o.delivery_address
        FROM orders o
        INNER JOIN customers c ON o.customer_id = c.customer_id
        ORDER BY o.order_date DESC
    "

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()

                Dim adapter As New MySqlDataAdapter(query, conn)
                Dim table As New DataTable()
                adapter.Fill(table)

                DataGridView2.DataSource = table
                DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                DataGridView2.ReadOnly = True
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading orders: " & ex.Message)
        End Try
    End Sub


    Private Sub LoadProductDetails(productId As Integer)
        Dim query As String = "
        SELECT 
            product_name, color, size, price, stock_quantity, image_path,
            c.category_id, c.category_name, s.supplier_name, b.brand_name, gender,
            (SELECT supplier_price FROM supply_logs 
             WHERE product_id = p.product_id 
             ORDER BY supply_id DESC LIMIT 1) AS supplier_price
        FROM products p
        LEFT JOIN categories c ON p.category_id = c.category_id
        LEFT JOIN suppliers s ON p.supplier_id = s.supplier_id
        LEFT JOIN brands b ON p.brand_id = b.brand_id
        WHERE p.product_id = @pid
        "

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@pid", productId)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim fullName As String = reader("product_name").ToString()
                            Dim categoryId As Integer = Convert.ToInt32(reader("category_id"))

                            ' Perfume categories: 6 to 12
                            If categoryId >= 6 AndAlso categoryId <= 12 Then
                                ' Perfumes: name is literal
                                productNameTxt.Text = fullName
                                ColorTxt.Text = reader("color").ToString()
                                sizeTxt.Text = reader("size").ToString()
                            Else
                                ' Apparel or others: Name - Color - Size
                                Dim parts() As String = fullName.Split(New String() {" - "}, StringSplitOptions.None)
                                If parts.Length = 3 Then
                                    productNameTxt.Text = parts(0)
                                    ColorTxt.Text = parts(1)
                                    sizeTxt.Text = parts(2)
                                Else
                                    productNameTxt.Text = fullName
                                End If
                            End If

                            ' Fill remaining fields
                            PriceTxt.Text = reader("price").ToString()
                            QuantityList.Text = reader("stock_quantity").ToString()
                            brandTxt.SelectedItem = reader("brand_name").ToString()
                            SupplierLists.SelectedItem = reader("supplier_name").ToString()
                            CategoryLists.SelectedItem = reader("category_name").ToString()
                            genderTxt.SelectedItem = reader("gender").ToString()
                            supplierPriceTxt.Text = reader("supplier_price").ToString()


                            imagePathForDb = reader("image_path").ToString()
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading product details: " & ex.Message)
        End Try
    End Sub


    Public Sub LoadProductsToGrid()
        Dim query As String = "
            SELECT 
                product_id AS 'ID',
                product_name AS 'Product Name',
                stock_quantity AS 'Stock Quantity'
            FROM products
        "

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()

                Dim adapter As New MySqlDataAdapter(query, conn)
                Dim table As New DataTable()
                adapter.Fill(table)

                DataGridView1.DataSource = table

                ' Optional UI settings:
                DataGridView1.ReadOnly = False
                DataGridView1.Columns("ID").ReadOnly = True  ' Don't allow editing product_id
                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading products: " & ex.Message)
        End Try
    End Sub


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
        ' --- Step 1: Validate Required Fields ---
        If String.IsNullOrWhiteSpace(productNameTxt.Text) OrElse
           String.IsNullOrWhiteSpace(ColorTxt.Text) OrElse
           String.IsNullOrWhiteSpace(sizeTxt.Text) OrElse
           String.IsNullOrWhiteSpace(PriceTxt.Text) OrElse
           String.IsNullOrWhiteSpace(QuantityList.Text) Then
            MessageBox.Show("Please fill in all required fields.")
            Return
        End If

        ' --- Step 2: Format Inputs ---
        Dim rawName As String = productNameTxt.Text.Trim()
        Dim rawColor As String = ColorTxt.Text.Trim()
        Dim rawSize As String = sizeTxt.Text.Trim()
        Dim formattedName As String = Char.ToUpper(rawName(0)) & rawName.Substring(1).ToLower()
        Dim formattedColor As String = Char.ToUpper(rawColor(0)) & rawColor.Substring(1).ToLower()
        Dim formattedSize As String = rawSize.ToLower()

        ' --- Step 3: Get Category ID ---
        Dim categoryId As Integer = GetId("SELECT category_id FROM categories WHERE category_name = @name", CategoryLists.SelectedItem?.ToString())
        If categoryId = -1 Then
            MessageBox.Show("Invalid category selected.")
            Return
        End If

        ' --- Step 4: Determine if product is perfume ---
        Dim isPerfume As Boolean = (categoryId >= 6 AndAlso categoryId <= 12)
        Dim productNameForDb As String = If(isPerfume, rawName, $"{formattedName} - {formattedColor} - {formattedSize}")

        ' --- Step 5: Get Other IDs ---
        Dim supplierId As Integer = GetId("SELECT supplier_id FROM suppliers WHERE supplier_name = @name", SupplierLists.SelectedItem?.ToString())
        Dim brandId As Integer = GetId("SELECT brand_id FROM brands WHERE brand_name = @name", brandTxt.SelectedItem?.ToString())
        If supplierId = -1 OrElse brandId = -1 Then
            MessageBox.Show("Please select valid supplier and brand.")
            Return
        End If

        ' --- Step 6: Parse Price & Quantity ---
        Dim priceValue As Decimal
        Dim quantityValue As Integer
        Decimal.TryParse(PriceTxt.Text.Trim(), priceValue)
        Integer.TryParse(QuantityList.Text.Trim(), quantityValue)

        ' --- Step 7: Check for Existing Product ---
        Dim productId As Integer = GetId("SELECT product_id FROM products WHERE product_name = @pname", productNameForDb)
        Dim isUpdate As Boolean = (productId <> -1)

        ' --- Step 8: File Check (only required for new product) ---
        If Not isUpdate Then
            If String.IsNullOrEmpty(selectedFilePath) OrElse Not File.Exists(selectedFilePath) Then
                MessageBox.Show("No file selected or file does not exist.")
                Return
            End If
            imagePathForDb = SaveImageToPath(selectedFilePath)
        End If

        ' --- Step 9: Perform Insert or Update ---
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()

                If isUpdate Then
                    ' UPDATE existing product
                    Dim currentStock As Integer = Convert.ToInt32(ExecuteScalar("SELECT stock_quantity FROM products WHERE product_id = @pid", conn, productId))
                    Dim newStock As Integer = currentStock + quantityValue

                    Dim updateCmd As New MySqlCommand("UPDATE products SET price = @price, stock_quantity = @qty WHERE product_id = @pid", conn)
                    updateCmd.Parameters.AddWithValue("@price", priceValue)
                    updateCmd.Parameters.AddWithValue("@qty", newStock)
                    updateCmd.Parameters.AddWithValue("@pid", productId)
                    updateCmd.ExecuteNonQuery()
                    LoadProductsToGrid()
                    MessageBox.Show("Product updated successfully!")
                Else
                    ' INSERT new product
                    Dim insertCmd As New MySqlCommand("INSERT INTO products (product_name, color, size, category_id, supplier_id, brand_id, price, stock_quantity, image_path, gender) VALUES (@pname, @color, @size, @catid, @supid, @brid, @price, @qty, @imgpath, @gender); SELECT LAST_INSERT_ID();", conn)
                    insertCmd.Parameters.AddWithValue("@pname", productNameForDb)
                    insertCmd.Parameters.AddWithValue("@color", ColorTxt.Text.Trim())
                    insertCmd.Parameters.AddWithValue("@size", sizeTxt.Text.Trim())
                    insertCmd.Parameters.AddWithValue("@catid", categoryId)
                    insertCmd.Parameters.AddWithValue("@supid", supplierId)
                    insertCmd.Parameters.AddWithValue("@brid", brandId)
                    insertCmd.Parameters.AddWithValue("@price", priceValue)
                    insertCmd.Parameters.AddWithValue("@qty", quantityValue)
                    insertCmd.Parameters.AddWithValue("@imgpath", imagePathForDb)
                    insertCmd.Parameters.AddWithValue("@gender", genderTxt.SelectedItem?.ToString())
                    productId = Convert.ToInt32(insertCmd.ExecuteScalar())
                    LoadProductsToGrid()
                    MessageBox.Show("Product added successfully!")
                End If

                ' Insert supply log
                Dim supplierPrice As Decimal
                Decimal.TryParse(supplierPriceTxt.Text.Trim(), supplierPrice)
                Dim remarks As String = remarksTxt.Text.Trim()
                Dim logCmd As New MySqlCommand("INSERT INTO supply_logs (product_id, supplier_id, quantity_added, remarks, supplier_price) VALUES (@pid, @sid, @qty, @remarks, @sprice)", conn)
                logCmd.Parameters.AddWithValue("@pid", productId)
                logCmd.Parameters.AddWithValue("@sid", supplierId)
                logCmd.Parameters.AddWithValue("@qty", quantityValue)
                logCmd.Parameters.AddWithValue("@remarks", remarks)
                logCmd.Parameters.AddWithValue("@sprice", supplierPrice)
                logCmd.ExecuteNonQuery()

            End Using
        Catch ex As Exception
            MessageBox.Show("Error saving product: " & ex.Message)
        End Try

        selectedFilePath = ""
    End Sub
    '' Helper function to get ID from database based on query and value
    Public Function GetId(query As String, value As String) As Integer
        If String.IsNullOrWhiteSpace(value) Then Return -1

        Using conn As New MySqlConnection(connectionString)
            conn.Open()
            Using cmd As New MySqlCommand(query, conn)
                ' Extract the first parameter name from the query using Regex
                Dim match = System.Text.RegularExpressions.Regex.Match(query, "@\w+")
                If match.Success Then
                    Dim paramName = match.Value
                    cmd.Parameters.AddWithValue(paramName, value)
                Else
                    Throw New Exception("Query must contain a parameter starting with '@'")
                End If

                Dim result = cmd.ExecuteScalar()
                If result IsNot Nothing Then Return Convert.ToInt32(result)
            End Using
        End Using

        Return -1
    End Function



    Private Function ExecuteScalar(query As String, conn As MySqlConnection, pid As Integer) As Object
        Using cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@pid", pid)
            Return cmd.ExecuteScalar()
        End Using
    End Function

    Private Function SaveImageToPath(filePath As String) As String
        Dim folder As String = Path.Combine(Application.StartupPath, "images")
        If Not Directory.Exists(folder) Then Directory.CreateDirectory(folder)
        Dim destPath As String = Path.Combine(folder, Path.GetFileName(filePath))
        File.Copy(filePath, destPath, True)
        Return "images\" & Path.GetFileName(filePath)
    End Function




    Private Sub AdminFormPage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        statusDropdown.Items.AddRange(New String() {"Pending", "Processing", "Completed", "Cancelled"})
        LoadProductsToGrid()
        LoadCategories()
        LoadSuppliers()
        LoadBrands()
        LoadCustomerOrdersToGrid()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        ' Prevent error if user clicks header or empty row
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return

        Dim selectedRow As DataGridViewRow = DataGridView1.Rows(e.RowIndex)

        ' Get the product_id of the selected row
        Dim productId As Integer = Convert.ToInt32(selectedRow.Cells("ID").Value)

        ' Load full product details from database
        LoadProductDetails(productId)
    End Sub

    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = DataGridView2.Rows(e.RowIndex)
            selectedOrderId = Convert.ToInt32(row.Cells("order_id").Value)
            statusDropdown.SelectedItem = row.Cells("order_status").Value.ToString()
        End If
    End Sub

    Private Sub btnUpdateStatus_Click(sender As Object, e As EventArgs) Handles btnUpdateStatus.Click
        If selectedOrderId = -1 Then
            MessageBox.Show("Please select an order first.")
            Return
        End If

        If statusDropdown.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a status.")
            Return
        End If

        Dim newStatus As String = statusDropdown.SelectedItem.ToString()

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim cmd As New MySqlCommand("
                    UPDATE orders 
                    SET order_status = @status, 
                        date_recieved = CASE WHEN @status = 'Completed' THEN NOW() ELSE date_recieved END 
                    WHERE order_id = @oid", conn)

                cmd.Parameters.AddWithValue("@status", newStatus)
                cmd.Parameters.AddWithValue("@oid", selectedOrderId)
                cmd.ExecuteNonQuery()
            End Using

            MessageBox.Show("Order status updated.")
            LoadCustomerOrdersToGrid()
        Catch ex As Exception
            MessageBox.Show("Error updating status: " & ex.Message)
        End Try
    End Sub



End Class