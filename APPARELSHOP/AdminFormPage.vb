Imports System.IO
Imports MySql.Data.MySqlClient
Imports Mysqlx.XDevAPI.Relational

Public Class AdminFormPage
    Public Property PendingUploadFilePath As String
    Dim selectedOrderId As Integer = -1
    Dim conn As New MySqlConnection("server=localhost;userid=root;password=;database=apparelshopdb")

    'get total income and products sold
    Private Sub LoadTotalIncomeAndProductsSold()
        Dim totalIncome As Decimal = 0D
        Dim totalProductsSold As Integer = 0
        Dim totalProfit As Decimal = 0D
        Dim conn As New MySqlConnection("server=localhost;userid=root;password=;database=apparelshopdb")

        Try
            conn.Open()
            Dim cmd As New MySqlCommand("
            SELECT od.quantity, od.unit_price, sl.supplier_price
            FROM orders o
            INNER JOIN order_details od ON o.order_id = od.order_id
            INNER JOIN products p ON od.product_id = p.product_id
            LEFT JOIN supply_logs sl ON p.product_id = sl.product_id
            WHERE o.order_status = 'Completed'", conn)

            Dim reader As MySqlDataReader = cmd.ExecuteReader()
            While reader.Read()
                Dim qty As Integer = Convert.ToInt32(reader("quantity"))
                Dim price As Decimal = Convert.ToDecimal(reader("unit_price"))
                Dim supplierPrice As Decimal = If(IsDBNull(reader("supplier_price")), 0D, Convert.ToDecimal(reader("supplier_price")))

                totalProductsSold += qty
                totalIncome += qty * price
                totalProfit += qty * (price - supplierPrice)
            End While
            reader.Close()

            lblTotalProductsSold.Text = "Total Products Sold: " & totalProductsSold.ToString()
            lblTotalStoreIncome.Text = "Total Store Income: ₱" & totalIncome.ToString("N2")
            lblTotalStoreProfit.Text = "Total Store Profit: ₱" & totalProfit.ToString("N2")

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub



    '    ' Load customer orders into DataGridView
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

    ' ' Load product details into text fields based on selected product_id
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

    ' ' Load products into DataGridView
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

    ' ' Load categories, suppliers, and brands into respective ComboBoxes

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
    ' ' Load suppliers into ComboBox
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
    ' ' Load brands into ComboBox
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
    ' ' Handle file upload button click
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles FileUploadButton.Click

        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "All Files (*.*)|*.*"
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            ' Store the file path for later upload
            selectedFilePath = openFileDialog.FileName


        End If
    End Sub

    ' ' Handle upload button click to save product details
    Private Sub btnUpload_Click(sender As Object, e As EventArgs) Handles addProductBtn.Click
        ' --- Step 1: Get Category ID ---
        Dim categoryId As Integer = GetId("SELECT category_id FROM categories WHERE category_name = @name", CategoryLists.SelectedItem?.ToString())
        Dim isPerfume As Boolean = (categoryId >= 6 AndAlso categoryId <= 12)

        ' --- Step 2: Validate Required Fields ---
        If String.IsNullOrWhiteSpace(productNameTxt.Text) OrElse
           String.IsNullOrWhiteSpace(PriceTxt.Text) OrElse
           String.IsNullOrWhiteSpace(QuantityList.Text) OrElse
           (Not isPerfume AndAlso (String.IsNullOrWhiteSpace(ColorTxt.Text) OrElse String.IsNullOrWhiteSpace(sizeTxt.Text))) Then
            MessageBox.Show("Please fill in all required fields.")
            Return
        End If

        ' --- Step 3: Format Inputs ---
        Dim rawName As String = productNameTxt.Text.Trim()
        Dim rawColor As String = ColorTxt.Text.Trim()
        Dim rawSize As String = sizeTxt.Text.Trim()
        Dim formattedName As String = Char.ToUpper(rawName(0)) & rawName.Substring(1).ToLower()
        Dim formattedColor As String = If(rawColor.Length > 0, Char.ToUpper(rawColor(0)) & rawColor.Substring(1).ToLower(), "")
        Dim formattedSize As String = If(rawSize.Length > 0, rawSize.ToLower(), "")

        Dim categorySelected As String = CategoryLists.SelectedItem?.ToString()?.ToLower()
        MessageBox.Show("Selected category: " & categorySelected) ' <-- For debugging

        Dim suffix As String = ""

        If isPerfume AndAlso Not String.IsNullOrWhiteSpace(categorySelected) Then
            If categorySelected.Contains("parfum") Then
                suffix = " EDP"
            ElseIf categorySelected.Contains("toilette") Then
                suffix = " EDT"
            End If
        End If

        Dim productNameForDb As String = If(isPerfume, rawName & suffix, $"{formattedName} - {formattedColor} - {formattedSize}")



        ' --- Step 4: Get Other IDs ---
        Dim supplierId As Integer = GetId("SELECT supplier_id FROM suppliers WHERE supplier_name = @name", SupplierLists.SelectedItem?.ToString())
        Dim brandId As Integer = GetId("SELECT brand_id FROM brands WHERE brand_name = @name", brandTxt.SelectedItem?.ToString())
        If supplierId = -1 OrElse (Not isPerfume AndAlso brandId = -1) Then
            MessageBox.Show("Please select valid supplier and brand.")
            Return
        End If

        ' --- Step 5: Parse Price & Quantity ---
        Dim priceValue As Decimal
        Dim quantityValue As Integer
        Decimal.TryParse(PriceTxt.Text.Trim(), priceValue)
        Integer.TryParse(QuantityList.Text.Trim(), quantityValue)

        ' --- Step 6: Check for Existing Product ---
        Dim productId As Integer = GetId("SELECT product_id FROM products WHERE product_name = @pname", productNameForDb)
        Dim isUpdate As Boolean = (productId <> -1)

        ' --- Step 7: File Check (only required for new product) ---
        If Not isUpdate Then
            If String.IsNullOrEmpty(selectedFilePath) OrElse Not File.Exists(selectedFilePath) Then
                MessageBox.Show("No file selected or file does not exist.")
                Return
            End If
            imagePathForDb = SaveImageToPath(selectedFilePath)
        End If

        ' --- Step 8: Perform Insert or Update ---
        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim transaction = conn.BeginTransaction()

                Try
                    If isUpdate Then
                        ' --- Update existing product ---
                        Dim currentStock As Integer = Convert.ToInt32(ExecuteScalar("SELECT stock_quantity FROM products WHERE product_id = @pid", conn, productId))
                        Dim newStock As Integer = currentStock + quantityValue

                        Dim updateCmd As New MySqlCommand("UPDATE products SET price = @price, stock_quantity = @qty WHERE product_id = @pid", conn, transaction)
                        updateCmd.Parameters.AddWithValue("@price", priceValue)
                        updateCmd.Parameters.AddWithValue("@qty", newStock)
                        updateCmd.Parameters.AddWithValue("@pid", productId)
                        updateCmd.ExecuteNonQuery()

                    Else
                        ' --- Insert new product ---
                        If String.IsNullOrEmpty(selectedFilePath) OrElse Not File.Exists(selectedFilePath) Then
                            MessageBox.Show("No file selected or file does not exist.")
                            transaction.Rollback()
                            Return
                        End If

                        imagePathForDb = SaveImageToPath(selectedFilePath)

                        Dim insertCmd As New MySqlCommand("
                    INSERT INTO products 
                        (product_name, color, size, category_id, supplier_id, brand_id, price, stock_quantity, image_path, gender)
                    VALUES 
                        (@pname, @color, @size, @catid, @supid, @brid, @price, @qty, @imgpath, @gender);
                    SELECT LAST_INSERT_ID();", conn, transaction)

                        insertCmd.Parameters.AddWithValue("@pname", productNameForDb)
                        insertCmd.Parameters.AddWithValue("@color", If(isPerfume, DBNull.Value, ColorTxt.Text.Trim()))
                        insertCmd.Parameters.AddWithValue("@size", If(isPerfume, DBNull.Value, sizeTxt.Text.Trim()))
                        insertCmd.Parameters.AddWithValue("@catid", categoryId)
                        insertCmd.Parameters.AddWithValue("@supid", supplierId)
                        insertCmd.Parameters.AddWithValue("@brid", If(isPerfume, DBNull.Value, brandId))
                        insertCmd.Parameters.AddWithValue("@price", priceValue)
                        insertCmd.Parameters.AddWithValue("@qty", quantityValue)
                        insertCmd.Parameters.AddWithValue("@imgpath", imagePathForDb)
                        Dim genderValue As Object = If(String.IsNullOrWhiteSpace(genderTxt.Text), DBNull.Value, genderTxt.SelectedItem.ToString())
                        insertCmd.Parameters.AddWithValue("@gender", genderValue)

                        productId = Convert.ToInt32(insertCmd.ExecuteScalar())
                    End If

                    ' --- Insert into supply_logs ---
                    Dim supplierPrice As Decimal
                    Decimal.TryParse(supplierPriceTxt.Text.Trim(), supplierPrice)
                    Dim remarks As String = remarksTxt.Text.Trim()

                    Dim logCmd As New MySqlCommand("
                INSERT INTO supply_logs 
                    (product_id, supplier_id, quantity_added, remarks, supplier_price)
                VALUES 
                    (@pid, @sid, @qty, @remarks, @sprice)", conn, transaction)

                    logCmd.Parameters.AddWithValue("@pid", productId)
                    logCmd.Parameters.AddWithValue("@sid", supplierId)
                    logCmd.Parameters.AddWithValue("@qty", quantityValue)
                    logCmd.Parameters.AddWithValue("@remarks", remarks)
                    logCmd.Parameters.AddWithValue("@sprice", supplierPrice)
                    logCmd.ExecuteNonQuery()

                    ' --- All successful: Commit ---
                    transaction.Commit()

                    LoadProductsToGrid()
                    MessageBox.Show(If(isUpdate, "Product updated successfully!", "Product added successfully!"))

                Catch exInner As Exception
                    transaction.Rollback()
                    MessageBox.Show("Error saving product: " & exInner.Message)
                End Try
            End Using
        Catch exOuter As Exception
            MessageBox.Show("Unexpected error: " & exOuter.Message)
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


    '' Helper function to execute a scalar query with a parameter
    Private Function ExecuteScalar(query As String, conn As MySqlConnection, pid As Integer) As Object
        Using cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@pid", pid)
            Return cmd.ExecuteScalar()
        End Using
    End Function
    '' Helper function to save image file to a specific path
    Private Function SaveImageToPath(filePath As String) As String
        Dim folder As String = Path.Combine(Application.StartupPath, "images")
        If Not Directory.Exists(folder) Then Directory.CreateDirectory(folder)

        Dim destPath As String = Path.Combine(folder, Path.GetFileName(filePath))

        ' ✅ Prevent copying file onto itself
        If Not filePath.Equals(destPath, StringComparison.OrdinalIgnoreCase) Then
            ' Try to copy safely
            Try
                File.Copy(filePath, destPath, True)
            Catch ex As IOException
                MessageBox.Show("Error copying image file: " & ex.Message)
                Return ""
            End Try
        End If

        Return "images\" & Path.GetFileName(filePath)
    End Function




    Private Sub AdminFormPage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        statusDropdown.Items.AddRange(New String() {"Pending", "Processing", "Completed", "Cancelled"})
        LoadProductsToGrid()
        LoadCategories()
        LoadSuppliers()
        LoadBrands()
        LoadCustomerOrdersToGrid()
        LoadTotalIncomeAndProductsSold()
    End Sub
    ' ' Handle DataGridView cell click to load product details
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick

        ' Prevent error if user clicks header or empty row
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Return

        Dim selectedRow As DataGridViewRow = DataGridView1.Rows(e.RowIndex)

        ' Get the product_id of the selected row
        Dim productId As Integer = Convert.ToInt32(selectedRow.Cells("ID").Value)

        ' Load full product details from database
        LoadProductDetails(productId)
    End Sub
    ' ' Handle DataGridView2 cell click to select an order
    Private Sub DataGridView2_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = DataGridView2.Rows(e.RowIndex)
            selectedOrderId = Convert.ToInt32(row.Cells("order_id").Value)
            statusDropdown.SelectedItem = row.Cells("order_status").Value.ToString()
        End If
    End Sub
    ' ' Handle Update Status button click to change order status
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

                ' Get current status of the order
                Dim checkStatusCmd As New MySqlCommand("SELECT order_status FROM orders WHERE order_id = @oid", conn)
                checkStatusCmd.Parameters.AddWithValue("@oid", selectedOrderId)
                Dim currentStatus As String = Convert.ToString(checkStatusCmd.ExecuteScalar())

                If currentStatus = "Completed" OrElse currentStatus = "Cancelled" Then
                    MessageBox.Show("You cannot change the status of an order that is already 'Completed' or 'Cancelled'.")
                    Return
                End If

                ' Begin transaction
                Dim transaction As MySqlTransaction = conn.BeginTransaction()

                ' Update order status
                Dim updateCmd As New MySqlCommand("
                UPDATE orders 
                SET order_status = @status, 
                    date_received = CASE WHEN @status = 'Completed' THEN NOW() ELSE date_received END 
                WHERE order_id = @oid", conn, transaction)

                updateCmd.Parameters.AddWithValue("@status", newStatus)
                updateCmd.Parameters.AddWithValue("@oid", selectedOrderId)
                updateCmd.ExecuteNonQuery()

                ' If Completed, deduct stocks
                If newStatus = "Completed" Then
                    ' Get order details
                    Dim getDetailsCmd As New MySqlCommand("
                    SELECT product_id, quantity 
                    FROM order_details 
                    WHERE order_id = @oid", conn, transaction)
                    getDetailsCmd.Parameters.AddWithValue("@oid", selectedOrderId)

                    Using reader As MySqlDataReader = getDetailsCmd.ExecuteReader()
                        Dim items As New List(Of Tuple(Of Integer, Integer)) ' product_id, quantity

                        While reader.Read()
                            items.Add(New Tuple(Of Integer, Integer)(
                            Convert.ToInt32(reader("product_id")),
                            Convert.ToInt32(reader("quantity"))
                        ))
                        End While
                        reader.Close()

                        ' Deduct stock for each product
                        For Each item In items
                            Dim updateStockCmd As New MySqlCommand("
                            UPDATE products 
                            SET stock_quantity = stock_quantity - @qty 
                            WHERE product_id = @pid", conn, transaction)

                            updateStockCmd.Parameters.AddWithValue("@qty", item.Item2)
                            updateStockCmd.Parameters.AddWithValue("@pid", item.Item1)
                            updateStockCmd.ExecuteNonQuery()
                        Next
                    End Using
                End If

                transaction.Commit()

                ' Insert a notification to the customer if status is Completed
                If newStatus = "Completed" Then
                    Dim insertNotifCmd As New MySqlCommand("
                        INSERT INTO notifications (customer_id, order_id, message)
                        SELECT o.customer_id, o.order_id, CONCAT('Your order #', o.order_id, ' has been completed. Click to download your receipt.')
                        FROM orders o
                        WHERE o.order_id = @oid", conn)

                    insertNotifCmd.Parameters.AddWithValue("@oid", selectedOrderId)
                    insertNotifCmd.ExecuteNonQuery()
                End If




            End Using

            MessageBox.Show("Order status updated.")
            LoadCustomerOrdersToGrid()

        Catch ex As Exception
            MessageBox.Show("Error updating status: " & ex.Message)
        End Try
    End Sub
    ' ' Handle ComboBox selection change to enable/disable fields

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        Dim selectedType As String = ComboBox3.SelectedItem?.ToString()

        If selectedType = "PERFUME" Then
            ' Disable fields not needed for perfumes

            sizeTxt.Enabled = False
            brandTxt.Enabled = False

            ColorTxt.Text = ""
            sizeTxt.Text = ""
            brandTxt.SelectedIndex = -1
        Else
            ' Enable for apparel or other products
            sizeTxt.Enabled = True
            brandTxt.Enabled = True
        End If
    End Sub


    Private Sub brandTxt_SelectedIndexChanged(sender As Object, e As EventArgs) Handles brandTxt.SelectedIndexChanged

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles dtpStartDate.ValueChanged

    End Sub
    ' ' Handle button click to calculate income and profit within date range
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim startDate As Date = dtpStartDate.Value.Date
        Dim endDate As Date = dtpEndDate.Value.Date

        Dim incomeRange As Decimal = 0
        Dim profitRange As Decimal = 0
        Dim totalProductsSold As Integer = 0

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim query As String = "
                SELECT od.quantity, p.price, sl.supplier_price
                FROM orders o
                JOIN order_details od ON o.order_id = od.order_id
                JOIN products p ON od.product_id = p.product_id
                LEFT JOIN supply_logs sl ON p.product_id = sl.product_id
                WHERE o.order_status = 'Completed'
                AND o.order_date BETWEEN @start AND @end
            "

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@start", startDate)
                    cmd.Parameters.AddWithValue("@end", endDate)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim qty = Convert.ToInt32(reader("quantity"))
                            Dim sellPrice = Convert.ToDecimal(reader("price"))
                            Dim supplierPrice = If(IsDBNull(reader("supplier_price")), 0, Convert.ToDecimal(reader("supplier_price")))

                            incomeRange += qty * sellPrice
                            profitRange += qty * (sellPrice - supplierPrice)
                            totalProductsSold += qty
                        End While
                    End Using
                End Using
            End Using

            lblResult.Text = "Result:" & vbCrLf &
                             "Products Sold: " & totalProductsSold.ToString() & vbCrLf &
                             "Income: ₱" & incomeRange.ToString("N2") & vbCrLf &
                             "Profit: ₱" & profitRange.ToString("N2") & vbCrLf &
                             "From " & startDate.ToShortDateString() & " to " & endDate.ToShortDateString()
        Catch ex As Exception
            MessageBox.Show("Error calculating: " & ex.Message)
        End Try

    End Sub

    Private Sub createBtn_Click(sender As Object, e As EventArgs) Handles createBtn.Click
        Dim username As String = usernameTxt.Text.Trim()
        Dim password As String = passwordTxt.Text.Trim()

        If String.IsNullOrWhiteSpace(username) OrElse String.IsNullOrWhiteSpace(password) Then
            MessageBox.Show("Please enter both username and password.")
            Return
        End If

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()

                ' Optional: Check if username already exists
                Dim checkCmd As New MySqlCommand("SELECT COUNT(*) FROM users WHERE username = @uname", conn)
                checkCmd.Parameters.AddWithValue("@uname", username)
                Dim exists As Integer = Convert.ToInt32(checkCmd.ExecuteScalar())

                If exists > 0 Then
                    MessageBox.Show("Username already exists. Please choose a different one.")
                    Return
                End If

                ' Insert new user with SHA2 hashed password
                Dim insertCmd As New MySqlCommand("
                INSERT INTO users (username, password)
                VALUES (@uname, SHA2(@pass, 256))", conn)

                insertCmd.Parameters.AddWithValue("@uname", username)
                insertCmd.Parameters.AddWithValue("@pass", password)
                insertCmd.ExecuteNonQuery()

                MessageBox.Show("User created successfully!")
                usernameTxt.Clear()
                passwordTxt.Clear()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error creating user: " & ex.Message)
        End Try
    End Sub
End Class