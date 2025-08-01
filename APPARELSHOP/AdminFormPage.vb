Imports System.Drawing
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.pdf.draw
Imports MySql.Data.MySqlClient
Imports Mysqlx.XDevAPI.Relational
Imports System.Xml

Public Class AdminFormPage
    Public Property PendingUploadFilePath As String
    Dim selectedOrderId As Integer = -1
    Dim conn As New MySqlConnection(connectionString)

    Private Sub AddImageToProjectFile(vbprojPath As String, relativeImagePath As String)
        Try
            Dim doc As New System.Xml.XmlDocument()
            doc.Load(vbprojPath)

            Dim nsmgr As New System.Xml.XmlNamespaceManager(doc.NameTable)
            nsmgr.AddNamespace("msb", "http://schemas.microsoft.com/developer/msbuild/2003")

            Dim alreadyExists = doc.SelectSingleNode($"//msb:Content[@Include='{relativeImagePath}']", nsmgr)
            If alreadyExists IsNot Nothing Then Return ' Already added

            ' Create XML nodes
            Dim itemGroup = doc.CreateElement("ItemGroup", doc.DocumentElement.NamespaceURI)
            Dim contentNode = doc.CreateElement("Content", doc.DocumentElement.NamespaceURI)
            contentNode.SetAttribute("Include", relativeImagePath)

            Dim copyNode = doc.CreateElement("CopyToOutputDirectory", doc.DocumentElement.NamespaceURI)
            copyNode.InnerText = "PreserveNewest"

            contentNode.AppendChild(copyNode)
            itemGroup.AppendChild(contentNode)
            doc.DocumentElement.AppendChild(itemGroup)

            doc.Save(vbprojPath)
        Catch ex As Exception
            MessageBox.Show("Failed to update project file: " & ex.Message)
        End Try
    End Sub


    'get total income and products sold
    Private Sub LoadTotalIncomeAndProductsSold()
        Dim totalIncome As Decimal = 0D
        Dim totalProductsSold As Integer = 0
        Dim totalProfit As Decimal = 0D
        Dim conn As New MySqlConnection(connectionString)

        Try
            conn.Open()

            'fetch total products sold, income, and profit from completed orders
            Dim cmd As New MySqlCommand("
            SELECT 
                od.quantity, 
                od.unit_price, 
                (
                    SELECT sl.supplier_price
                    FROM supply_logs sl
                    WHERE sl.product_id = p.product_id
                    ORDER BY sl.supply_date DESC
                    LIMIT 1
                ) AS supplier_price
            FROM orders o
            JOIN order_details od ON o.order_id = od.order_id
            JOIN products p ON od.product_id = p.product_id
            WHERE o.order_status = 'Completed'
            ", conn)

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



    'fetch customer orders and load into DataGridView
    Public Sub LoadCustomerOrdersToGrid()
        Dim query As String = "
        SELECT 
            o.order_id,
            c.full_name AS customer_name,
            o.order_date,
            o.order_status,
            o.delivery_address,
            o.payment_method,
            o.payment_reference
            
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


    'fetch product details by product_id and load into textboxes
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

                            ' Perfume categories: 7 to 8
                            If categoryId >= 7 AndAlso categoryId <= 8 Then
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

    'fetch products and load into DataGridView
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

    'fetch categories and load into ComboBox

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
    ' ' Fetch suppliers into ComboBox
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
    ' ' Fetch brands into ComboBox
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

    '  Handle upload button click to save product details
    Private Sub btnUpload_Click(sender As Object, e As EventArgs) Handles addProductBtn.Click
        ' --- Step 1: Get Category ID ---
        Dim categoryId As Integer = GetId("SELECT category_id FROM categories WHERE category_name = @name", CategoryLists.SelectedItem?.ToString())
        Dim isPerfume As Boolean = (categoryId >= 7 AndAlso categoryId <= 8)  ' Check if selected category is a perfume type


        'Validate Required Fields
        If String.IsNullOrWhiteSpace(productNameTxt.Text) OrElse
           String.IsNullOrWhiteSpace(PriceTxt.Text) OrElse
           String.IsNullOrWhiteSpace(QuantityList.Text) OrElse
           (Not isPerfume AndAlso (String.IsNullOrWhiteSpace(ColorTxt.Text) OrElse String.IsNullOrWhiteSpace(sizeTxt.Text))) Then
            MessageBox.Show("Please fill in all required fields.")
            Return
        End If

        'Format Input
        Dim rawName As String = productNameTxt.Text.Trim()
        Dim rawColor As String = ColorTxt.Text.Trim()
        Dim rawSize As String = sizeTxt.Text.Trim()
        Dim formattedName As String = Char.ToUpper(rawName(0)) & rawName.Substring(1).ToLower()
        Dim formattedColor As String = If(rawColor.Length > 0, Char.ToUpper(rawColor(0)) & rawColor.Substring(1).ToLower(), "")
        Dim formattedSize As String = If(rawSize.Length > 0, rawSize.ToLower(), "")

        Dim categorySelected As String = CategoryLists.SelectedItem?.ToString()?.ToLower()
        MessageBox.Show("Selected category: " & categorySelected) ' For debugging

        ' Determine suffix based on perfume type (e.g., EDP or EDT)
        Dim suffix As String = ""

        If isPerfume AndAlso Not String.IsNullOrWhiteSpace(categorySelected) Then
            If categorySelected.Contains("parfum") Then
                suffix = " EDP"
            ElseIf categorySelected.Contains("toilette") Then
                suffix = " EDT"
            End If
        End If

        '  final product name for database
        Dim productNameForDb As String = If(isPerfume, rawName & suffix, $"{formattedName} - {formattedColor} - {formattedSize}")



        ' Get Other IDs 
        Dim supplierId As Integer = GetId("SELECT supplier_id FROM suppliers WHERE supplier_name = @name", SupplierLists.SelectedItem?.ToString())
        Dim brandId As Integer = GetId("SELECT brand_id FROM brands WHERE brand_name = @name", brandTxt.SelectedItem?.ToString())
        If supplierId = -1 OrElse (Not isPerfume AndAlso brandId = -1) Then
            MessageBox.Show("Please select valid supplier and brand.")
            Return
        End If

        ' Parse Price & Quantity
        Dim priceValue As Decimal
        Dim quantityValue As Integer
        Decimal.TryParse(PriceTxt.Text.Trim(), priceValue)
        Integer.TryParse(QuantityList.Text.Trim(), quantityValue)

        ' Check for Existing Product 
        Dim productId As Integer = GetId("SELECT product_id FROM products WHERE product_name = @pname", productNameForDb)
        Dim isUpdate As Boolean = (productId <> -1)

        ' File Check (only required for new product)
        If Not isUpdate Then
            If String.IsNullOrEmpty(selectedFilePath) OrElse Not File.Exists(selectedFilePath) Then
                MessageBox.Show("No file selected or file does not exist.")
                Return
            End If
            imagePathForDb = SaveImageToPath(selectedFilePath) ' Save image and get relative path
        End If

        ' Step 8
        ' TRANSACTION HANDLING ( ADD PRODCUCT OR UPDATE PRODUCT )
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

                    LoadProductsToGrid() ' Refresh product display
                    MessageBox.Show(If(isUpdate, "Product updated successfully!", "Product added successfully!"))

                Catch exInner As Exception
                    transaction.Rollback() ' Roll back if error occurs
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
    Private Function SaveImageToPath(sourceFilePath As String) As String
        Try
            Dim fileName As String = Path.GetFileName(sourceFilePath)
            Dim projectDir As String = Path.GetFullPath(Path.Combine(Application.StartupPath, "..\.."))
            Dim imageDir As String = Path.Combine(projectDir, "images")

            If Not Directory.Exists(imageDir) Then
                Directory.CreateDirectory(imageDir)
            End If

            Dim destinationPath As String = Path.Combine(imageDir, fileName)

            File.Copy(sourceFilePath, destinationPath, True)

            ' Also copy to bin\Debug\images so the image loads immediately without rebuild
            Dim debugImageDir As String = Path.Combine(Application.StartupPath, "images")
            If Not Directory.Exists(debugImageDir) Then
                Directory.CreateDirectory(debugImageDir)
            End If
            File.Copy(destinationPath, Path.Combine(debugImageDir, fileName), True)


            ' Return relative path: this works with Application.StartupPath + "images\file"
            Return Path.Combine("images", fileName)

        Catch ex As Exception
            MessageBox.Show("Error copying image: " & ex.Message)
            Return ""
        End Try
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
    ' ' Handle DataGridView cell click to fetch product details
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

            Dim query As String = "
            SELECT 
                p.product_name,
                od.quantity,
                od.unit_price,
                (
                    SELECT sl.supplier_price
                    FROM supply_logs sl
                    WHERE sl.product_id = p.product_id
                    ORDER BY sl.supply_date DESC
                    LIMIT 1
                ) AS supplier_price
            FROM order_details od
            INNER JOIN products p ON od.product_id = p.product_id
            WHERE od.order_id = @OrderId"

            Using conn As New MySqlConnection(connectionString)
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@OrderId", selectedOrderId)
                    conn.Open()
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        Dim details As String = "Order Details:" & vbCrLf
                        Dim orderTotal As Decimal = 0D
                        Dim orderProfit As Decimal = 0D

                        While reader.Read()
                            Dim productName As String = reader("product_name").ToString()
                            Dim quantity As Integer = Convert.ToInt32(reader("quantity"))
                            Dim unitPrice As Decimal = Convert.ToDecimal(reader("unit_price"))
                            Dim supplierPrice As Decimal = If(IsDBNull(reader("supplier_price")), 0D, Convert.ToDecimal(reader("supplier_price")))

                            Dim itemTotal As Decimal = quantity * unitPrice
                            Dim itemProfit As Decimal = quantity * (unitPrice - supplierPrice)

                            orderTotal += itemTotal
                            orderProfit += itemProfit

                            details &= $"- {productName}: {quantity} pcs @ ₱{unitPrice:N2} (Profit: ₱{itemProfit:N2})" & vbCrLf
                        End While

                        details &= vbCrLf & $"Total Order Income: ₱{orderTotal:N2}" & vbCrLf
                        details &= $"Total Order Profit: ₱{orderProfit:N2}"

                        MsgBox(details, MsgBoxStyle.Information, "Order Items & Income")
                    End Using
                End Using
            End Using
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

                'TRANSACTION HANDLING (UPDATE ORDER STATUS AND DEDUCT STOCKS IF COMPLETED)

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

                ' Insert a notification to the customer
                If newStatus = "Completed" Then
                    Dim insertNotifCmd As New MySqlCommand("
        INSERT INTO notifications (customer_id, order_id, message)
        SELECT o.customer_id, o.order_id, CONCAT('Your order #', o.order_id, ' has been completed. Click to download your receipt.')
        FROM orders o
        WHERE o.order_id = @oid", conn)

                    insertNotifCmd.Parameters.AddWithValue("@oid", selectedOrderId)
                    insertNotifCmd.ExecuteNonQuery()

                ElseIf newStatus = "Cancelled" Then
                    If String.IsNullOrWhiteSpace(txtCancelReason.Text) Then
                        MessageBox.Show("Please provide a reason for cancellation.")
                        Return
                    End If

                    Dim insertCancelNotifCmd As New MySqlCommand("
        INSERT INTO notifications (customer_id, order_id, message)
        SELECT o.customer_id, o.order_id, CONCAT('Order #', o.order_id, ' cancelled. ', @reason)
        FROM orders o
        WHERE o.order_id = @oid", conn)

                    insertCancelNotifCmd.Parameters.AddWithValue("@oid", selectedOrderId)
                    insertCancelNotifCmd.Parameters.AddWithValue("@reason", txtCancelReason.Text.Trim())
                    insertCancelNotifCmd.ExecuteNonQuery()

                ElseIf newStatus = "Processing" Then
                    ' Get order date and compute ETA (add 2-5 days randomly)
                    Dim etaCmd As New MySqlCommand("SELECT order_date FROM orders WHERE order_id = @oid", conn)
                    etaCmd.Parameters.AddWithValue("@oid", selectedOrderId)
                    Dim orderDate As DateTime = Convert.ToDateTime(etaCmd.ExecuteScalar())

                    Dim rand As New Random()
                    Dim daysToAdd As Integer = rand.Next(2, 6) ' 2 to 5 inclusive
                    Dim etaDate As DateTime = orderDate.AddDays(daysToAdd)

                    Dim insertProcessingNotifCmd As New MySqlCommand("
                    INSERT INTO notifications (customer_id, order_id, message)
                    SELECT o.customer_id, o.order_id, 
                    CONCAT('Your order #', o.order_id, ' has been received and is now processing. Estimated delivery: ', @eta)
                    FROM orders o
                    WHERE o.order_id = @oid", conn)

                    insertProcessingNotifCmd.Parameters.AddWithValue("@oid", selectedOrderId)
                    insertProcessingNotifCmd.Parameters.AddWithValue("@eta", etaDate.ToString("MMMM dd, yyyy"))
                    insertProcessingNotifCmd.ExecuteNonQuery()

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

    ' ' Handle button click to calculate income and profit within date range
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click

        If Not lblResult.Visible Then
            lblResult.Visible = True
        End If

        Dim startDate As Date = dtpStartDate.Value.Date
        Dim endDate As Date = dtpEndDate.Value.Date.AddDays(1).AddSeconds(-1)

        Dim incomeRange As Decimal = 0
        Dim profitRange As Decimal = 0
        Dim totalProductsSold As Integer = 0

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim query As String = "
                SELECT 
                    od.quantity, 
                    od.unit_price, 
                    sl_latest.supplier_price
                FROM orders o
                JOIN order_details od ON o.order_id = od.order_id
                JOIN products p ON od.product_id = p.product_id
                LEFT JOIN (
                    SELECT sl.product_id, sl.supplier_price
                    FROM supply_logs sl
                    WHERE sl.supply_date = (
                        SELECT MAX(supply_date)
                        FROM supply_logs
                        WHERE product_id = sl.product_id
                    )
                ) sl_latest ON p.product_id = sl_latest.product_id
                WHERE o.order_status = 'Completed'
                  AND DATE(o.order_date) BETWEEN @start AND @end
            "

                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@start", startDate)
                    cmd.Parameters.AddWithValue("@end", endDate)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim qty As Integer = Convert.ToInt32(reader("quantity"))
                            Dim sellPrice As Decimal = Convert.ToDecimal(reader("unit_price"))
                            Dim supplierPrice As Decimal = If(IsDBNull(reader("supplier_price")), 0D, Convert.ToDecimal(reader("supplier_price")))

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

    'create new admin user
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

    Private Sub statusDropdown_SelectedIndexChanged(sender As Object, e As EventArgs) Handles statusDropdown.SelectedIndexChanged
        If statusDropdown.SelectedItem.ToString() = "Cancelled" Then
            txtCancelReason.Enabled = True
            txtCancelReason.Text = "Enter reason for cancellation..."
        Else
            txtCancelReason.Enabled = False
            txtCancelReason.Text = ""
        End If
    End Sub

    Private Sub btnUpdateQR_Click(sender As Object, e As EventArgs) Handles btnUpdateQR.Click
        Dim qrForm As New Form With {
        .Text = "QR Code Settings",
        .Size = New Size(370, 550),
        .StartPosition = FormStartPosition.CenterParent,
        .FormBorderStyle = FormBorderStyle.FixedDialog,
        .MaximizeBox = False,
        .MinimizeBox = False
    }


        'show qr code existing
        Dim picQRPreview As New PictureBox With {
        .Size = New Size(300, 430),
        .Location = New Point(30, 20),
        .SizeMode = PictureBoxSizeMode.StretchImage,
        .BorderStyle = BorderStyle.FixedSingle
    }
        Dim btnBrowseQR As New Button With {
    .Text = "Update QR Code",
    .Size = New Size(120, 40),
    .Location = New Point((qrForm.ClientSize.Width - 120) \ 2, 460), ' moved below picture
    .BackColor = Color.FromArgb(74, 80, 66),
    .ForeColor = Color.White,
    .FlatStyle = FlatStyle.Flat
}

        'fetch existing QR
        Dim qrPath As String = Path.Combine(Application.StartupPath, "Images", "qr.png")
        If File.Exists(qrPath) Then
            Using tempImg As System.Drawing.Image = System.Drawing.Image.FromFile(qrPath)
                picQRPreview.Image = New Bitmap(tempImg)
            End Using
        End If


        ' Browse and replace QR code logic
        AddHandler btnBrowseQR.Click,
        Sub()
            Dim ofd As New OpenFileDialog With {
                .Filter = "Image Files|*.png;*.jpg;*.jpeg;*.bmp",
                .Title = "Select New QR Code"
            }

            If ofd.ShowDialog() = DialogResult.OK Then
                Try
                    Directory.CreateDirectory(Path.GetDirectoryName(qrPath)) ' Ensure folder exists
                    File.Copy(ofd.FileName, qrPath, True)

                    picQRPreview.Image = System.Drawing.Image.FromFile(qrPath)
                    MessageBox.Show("QR code updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show("Failed to update QR code: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Sub

        qrForm.Controls.Add(picQRPreview)
        qrForm.Controls.Add(btnBrowseQR)
        qrForm.ShowDialog()

    End Sub


    Private Sub GenerateExpensesReportPDF(startDate As DateTime, endDate As DateTime)
        Dim connStr As String = connectionString
        Dim desktopPath As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        Dim folderPath As String = Path.Combine(desktopPath, "Expenses")

        If Not Directory.Exists(folderPath) Then
            Directory.CreateDirectory(folderPath)
        End If

        Dim fileName As String = $"ExpensesReport_{startDate:yyyyMMdd}_{endDate:yyyyMMdd}.pdf"
        Dim savePath As String = Path.Combine(folderPath, fileName)

        Try
            Using fs As New FileStream(savePath, FileMode.Create, FileAccess.Write, FileShare.Read)
                Dim doc As New Document(PageSize.A4, 40, 40, 50, 50)
                Dim writer = PdfWriter.GetInstance(doc, fs)

                ' Add Page Number Footer
                writer.PageEvent = New PDFPageEvents()

                doc.Open()

                ' Fonts
                Dim titleFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 18, iTextSharp.text.Font.BOLD)
                Dim subFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 11)
                Dim boldFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD)
                Dim cellFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10)
                Dim totalFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD)
                Dim spacer = New Paragraph(" ", subFont)

                ' Logo (Optional - if you have a logo file)
                'Dim logo = iTextSharp.text.Image.GetInstance("logo.png")
                'logo.ScaleToFit(50, 50)
                'logo.Alignment = Image.ALIGN_LEFT
                'doc.Add(logo)

                ' Title Block
                Dim title = New Paragraph("PRESTIGE APPAREL", titleFont)
                title.Alignment = Element.ALIGN_CENTER
                doc.Add(title)

                Dim subTitle = New Paragraph("Expenses Report", subFont)
                subTitle.Alignment = Element.ALIGN_CENTER
                doc.Add(subTitle)

                Dim dateRange = New Paragraph($"From {startDate:MMMM dd, yyyy} to {endDate:MMMM dd, yyyy}", subFont)
                dateRange.Alignment = Element.ALIGN_CENTER
                doc.Add(dateRange)

                doc.Add(spacer)

                ' Table Setup
                Dim table As New PdfPTable(5)
                table.WidthPercentage = 100
                table.SetWidths(New Single() {30, 25, 10, 15, 20})

                Dim headerColor As BaseColor = New BaseColor(230, 230, 230)

                ' Header Row
                Dim headers = {"Product", "Supplier", "Qty", "Supplier Price", "Supply Date"}
                For Each header As String In headers
                    Dim cell = New PdfPCell(New Phrase(header, boldFont)) With {
                    .BackgroundColor = headerColor,
                    .HorizontalAlignment = Element.ALIGN_CENTER,
                    .Padding = 5
                }
                    table.AddCell(cell)
                Next

                Dim totalExpense As Decimal = 0

                Using conn As New MySqlConnection(connStr)
                    conn.Open()
                    Dim cmd As New MySqlCommand("
                    SELECT 
                        p.product_name,
                        s.supplier_name,
                        sl.quantity_added,
                        sl.supplier_price,
                        sl.supply_date
                    FROM supply_logs sl
                    JOIN products p ON sl.product_id = p.product_id
                    JOIN suppliers s ON sl.supplier_id = s.supplier_id
                    WHERE sl.supply_date BETWEEN @start AND @end
                    ORDER BY sl.supply_date", conn)

                    cmd.Parameters.AddWithValue("@start", startDate)
                    cmd.Parameters.AddWithValue("@end", endDate)

                    Using reader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim product = reader("product_name").ToString()
                            Dim supplier = reader("supplier_name").ToString()
                            Dim qty = Convert.ToInt32(reader("quantity_added"))
                            Dim price = Convert.ToDecimal(reader("supplier_price"))
                            Dim dateSupplied = Convert.ToDateTime(reader("supply_date"))
                            Dim subtotal = qty * price
                            totalExpense += subtotal

                            table.AddCell(New PdfPCell(New Phrase(product, cellFont)) With {.Padding = 4})
                            table.AddCell(New PdfPCell(New Phrase(supplier, cellFont)) With {.Padding = 4})
                            table.AddCell(New PdfPCell(New Phrase(qty.ToString(), cellFont)) With {.HorizontalAlignment = Element.ALIGN_CENTER, .Padding = 4})
                            table.AddCell(New PdfPCell(New Phrase("₱" & price.ToString("N2"), cellFont)) With {.HorizontalAlignment = Element.ALIGN_RIGHT, .Padding = 4})
                            table.AddCell(New PdfPCell(New Phrase(dateSupplied.ToString("MM/dd/yyyy"), cellFont)) With {.HorizontalAlignment = Element.ALIGN_CENTER, .Padding = 4})
                        End While
                    End Using
                End Using

                doc.Add(table)

                doc.Add(spacer)

                ' Total Summary
                Dim totalPara = New Paragraph($"TOTAL EXPENSE: ₱{totalExpense:N2}", totalFont)
                totalPara.Alignment = Element.ALIGN_RIGHT
                doc.Add(totalPara)

                doc.Add(spacer)
                doc.Add(New Paragraph("Generated by Prestige System", subFont) With {.Alignment = Element.ALIGN_CENTER})

                doc.Close()
            End Using

            Process.Start(New ProcessStartInfo With {
            .FileName = savePath,
            .UseShellExecute = True
        })

            MessageBox.Show("Expenses report saved to your Desktop under 'Expenses'.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error generating report: " & ex.Message, "PDF Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub calculateExpbtn_Click(sender As Object, e As EventArgs) Handles calculateExpbtn.Click

        Dim startDate As DateTime = DateTimePicker1.Value.Date
        Dim endDate As DateTime = DateTimePicker2.Value.Date.AddDays(1).AddSeconds(-1)


        If endDate <startDate Then
            MessageBox.Show("End date must be on or after start date.", "Invalid Dates", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        GenerateExpensesReportPDF(startDate, endDate)

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    Public Class PDFPageEvents
        Inherits PdfPageEventHelper

        Private bf As BaseFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED)

        Public Overrides Sub OnEndPage(writer As PdfWriter, document As Document)
            Dim cb = writer.DirectContent
            Dim footer = $"Generated on {DateTime.Now:MMMM dd, yyyy}   |   Page {writer.PageNumber}"
            cb.BeginText()
            cb.SetFontAndSize(bf, 9)
            cb.ShowTextAligned(Element.ALIGN_CENTER, footer, (document.Left + document.Right) / 2, document.Bottom - 10, 0)
            cb.EndText()
        End Sub
    End Class

End Class