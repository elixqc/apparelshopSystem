Imports System.Drawing
Imports System.IO
Imports System.Text
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.pdf.draw
Imports MySql.Data.MySqlClient



Public Class customerProfile
    'load notifications from the database
    Private Sub LoadNotifications()
        FlowLayoutPanel2.Controls.Clear()

        Using conn As New MySqlConnection(connectionString)
            conn.Open()

            Dim query As String = "
            SELECT 
                n.notification_id, 
                n.order_id, 
                o.order_status,
                n.message,
                (
                    SELECT SUM(od.unit_price * od.quantity) 
                    FROM order_details od 
                    WHERE od.order_id = n.order_id
                ) AS total_price
            FROM notifications n
            INNER JOIN orders o ON n.order_id = o.order_id
            WHERE n.customer_id = @uid 
              AND n.is_read = FALSE 
              AND o.order_status IN ('Completed', 'Cancelled')
            ORDER BY n.date_created DESC
        "

            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@uid", loggedInUserID)

            Using reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    Dim orderId As Integer = CInt(reader("order_id"))
                    Dim status As String = reader("order_status").ToString()
                    Dim message As String = reader("message").ToString()
                    Dim totalPrice As Decimal = If(IsDBNull(reader("total_price")), 0D, CDec(reader("total_price")))

                    ' --- Notification Panel ---
                    Dim notifPanel As New Panel With {
                    .Width = 450,
                    .Height = 85,
                    .BackColor = Color.FromArgb(245, 245, 245),
                    .Margin = New Padding(5),
                    .BorderStyle = BorderStyle.FixedSingle,
                    .Cursor = If(status = "Cancelled", Cursors.Hand, Cursors.Default),
                    .Tag = orderId
                }

                    ' Left Border Indicator
                    Dim borderPanel As New Panel With {
                    .Width = 6,
                    .Dock = DockStyle.Left,
                    .BackColor = If(status = "Completed", Color.SeaGreen, Color.IndianRed)
                }
                    notifPanel.Controls.Add(borderPanel)

                    ' Main Notification Text
                    Dim lblMessage As New Label With {
                    .Text = message,
                    .Font = New System.Drawing.Font("Segoe UI", 10, FontStyle.Bold),
                    .Location = New Point(12, 8),
                    .Width = 420,
                    .AutoSize = True,
                    .MaximumSize = New Size(420, 0)
                }


                    notifPanel.Controls.Add(lblMessage)
                    notifPanel.Height = lblMessage.Bottom + 40 ' Extra space for subtext/button


                    ' Subtext with order ID and total
                    Dim lblSub As New Label With {
                    .Text = "Order #" & orderId & " | Total: ₱" & totalPrice.ToString("N2"),
                    .Font = New System.Drawing.Font("Segoe UI", 9, FontStyle.Italic),
                    .ForeColor = Color.Gray,
                    .Location = New Point(12, lblMessage.Bottom + 10),
                    .AutoSize = True
                }

                    notifPanel.Controls.Add(lblSub)

                    ' Button for receipt (Completed only)
                    If status = "Completed" Then
                        Dim btnDownload As New Button With {
                        .Text = "Download Receipt",
                        .Size = New Size(140, 30),
                        .Location = New Point(295, lblMessage.Bottom + 5), ' Dynamically below the message,
                        .Tag = orderId,
                        .BackColor = Color.Black,
                        .ForeColor = Color.White,
                        .FlatStyle = FlatStyle.Flat
                    }
                        btnDownload.FlatAppearance.BorderSize = 0

                        AddHandler btnDownload.Click,
                    Sub(senderBtn As Object, eBtn As EventArgs)
                        Dim oid As Integer = CInt(CType(senderBtn, Button).Tag)

                        Try
                            Using innerConn As New MySqlConnection(connectionString)
                                innerConn.Open()

                                Dim markCmd As New MySqlCommand("
                                    UPDATE notifications 
                                    SET is_read = TRUE 
                                    WHERE customer_id = @uid AND order_id = @oid", innerConn)
                                markCmd.Parameters.AddWithValue("@uid", loggedInUserID)
                                markCmd.Parameters.AddWithValue("@oid", oid)
                                markCmd.ExecuteNonQuery()
                            End Using

                            GenerateReceiptPDF(oid)
                            LoadNotifications()
                        Catch ex As Exception
                            MessageBox.Show("Error: " & ex.Message)
                        End Try
                    End Sub

                        notifPanel.Controls.Add(btnDownload)

                    ElseIf status = "Cancelled" Then
                        ' Entire panel is clickable to mark as read
                        AddHandler notifPanel.Click,
                    Sub(senderPanel As Object, ePanel As EventArgs)
                        Try
                            Using innerConn As New MySqlConnection(connectionString)
                                innerConn.Open()

                                Dim markCmd As New MySqlCommand("
                                    UPDATE notifications 
                                    SET is_read = TRUE 
                                    WHERE customer_id = @uid AND order_id = @oid", innerConn)
                                markCmd.Parameters.AddWithValue("@uid", loggedInUserID)
                                markCmd.Parameters.AddWithValue("@oid", orderId)
                                markCmd.ExecuteNonQuery()
                            End Using

                            LoadNotifications()
                        Catch ex As Exception
                            MessageBox.Show("Error: " & ex.Message)
                        End Try
                    End Sub
                    End If

                    FlowLayoutPanel2.Controls.Add(notifPanel)
                End While
            End Using
        End Using
    End Sub



    ' ' Generate PDF receipt for the order
    Private Sub GenerateReceiptPDF(orderId As Integer)
        Dim connStr As String = connectionString
        Dim desktopPath As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        Dim folderPath As String = Path.Combine(desktopPath, "Prestige Receipts")

        If Not Directory.Exists(folderPath) Then
            Directory.CreateDirectory(folderPath)
        End If

        Dim savePath As String = Path.Combine(folderPath, $"Receipt_Order_{orderId}.pdf")

        Try
            Using fs As New FileStream(savePath, FileMode.Create, FileAccess.Write, FileShare.Read)
                Dim doc As New Document(PageSize.A4, 50, 50, 25, 25)
                Dim writer = PdfWriter.GetInstance(doc, fs)
                doc.Open()

                ' Fonts
                Dim titleFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 18, iTextSharp.text.Font.BOLD)
                Dim subFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12)
                Dim boldFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD)
                Dim bigBoldFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14, iTextSharp.text.Font.BOLD)
                Dim spacer = New Paragraph(Environment.NewLine)
                Dim separator = New Paragraph(New Chunk(New LineSeparator(1.0F, 100.0F, BaseColor.GRAY, Element.ALIGN_CENTER, -1)))

                ' Logo
                Dim logoPath = Path.Combine(Application.StartupPath, "images", "prestigeLogoReceipt.png")
                If File.Exists(logoPath) Then
                    Dim logo = iTextSharp.text.Image.GetInstance(logoPath)
                    logo.ScaleAbsolute(80, 80)
                    logo.Alignment = Element.ALIGN_CENTER
                    doc.Add(logo)
                    doc.Add(spacer)
                End If

                ' Company Header
                doc.Add(New Paragraph("PRESTIGE APPAREL", titleFont) With {.Alignment = Element.ALIGN_CENTER})
                doc.Add(New Paragraph("Official Receipt", subFont) With {.Alignment = Element.ALIGN_CENTER})
                doc.Add(New Paragraph("Timeless fashion for every generation", subFont) With {.Alignment = Element.ALIGN_CENTER})
                doc.Add(spacer)

                doc.Add(New Paragraph($"Order ID: {orderId}", subFont))
                doc.Add(New Paragraph($"Date Issued: {DateTime.Now:MMMM dd, yyyy hh:mm tt}", subFont))
                doc.Add(spacer)

                ' Fetch order summary
                Using conn As New MySqlConnection(connStr)
                    conn.Open()

                    Dim summaryCmd As New MySqlCommand("
                    SELECT o.date_received, o.delivery_address, o.payment_method,
                           c.full_name, c.contact_number
                    FROM orders o
                    JOIN customers c ON o.customer_id = c.customer_id
                    WHERE o.order_id = @oid", conn)

                    summaryCmd.Parameters.AddWithValue("@oid", orderId)

                    Using reader = summaryCmd.ExecuteReader()
                        If reader.Read() Then
                            doc.Add(New Paragraph($"Sold To: {reader("full_name")}", subFont))
                            doc.Add(New Paragraph($"Contact Number: {reader("contact_number")}", subFont))
                            doc.Add(New Paragraph($"Delivery Address: {reader("delivery_address")}", subFont))
                            doc.Add(New Paragraph($"Date Received: {Convert.ToDateTime(reader("date_received")).ToString("MMMM dd, yyyy")}", subFont))
                            doc.Add(New Paragraph($"Payment Method: {reader("payment_method")}", subFont))
                            doc.Add(spacer)
                        End If
                    End Using

                    doc.Add(separator)
                    doc.Add(spacer)

                    ' Table Header
                    Dim table As New PdfPTable(4)
                    table.WidthPercentage = 100
                    table.SetWidths(New Single() {50, 15, 15, 20})
                    Dim headerColor As New BaseColor(240, 240, 240)

                    For Each colTitle In {"Product", "Qty", "Price", "Subtotal"}
                        Dim cell As New PdfPCell(New Phrase(colTitle, boldFont)) With {
                        .BackgroundColor = headerColor,
                        .HorizontalAlignment = Element.ALIGN_CENTER
                    }
                        table.AddCell(cell)
                    Next

                    ' Fetch items
                    Dim itemCmd As New MySqlCommand("
                    SELECT p.product_name, od.quantity, od.unit_price
                    FROM order_details od
                    JOIN products p ON od.product_id = p.product_id
                    WHERE od.order_id = @oid", conn)

                    itemCmd.Parameters.AddWithValue("@oid", orderId)

                    Dim grandTotal As Decimal = 0

                    Using itemReader = itemCmd.ExecuteReader()
                        While itemReader.Read()
                            Dim name = itemReader("product_name").ToString()
                            Dim qty = Convert.ToInt32(itemReader("quantity"))
                            Dim price = Convert.ToDecimal(itemReader("unit_price"))
                            Dim subtotal = qty * price
                            grandTotal += subtotal

                            table.AddCell(New PdfPCell(New Phrase(name)))
                            table.AddCell(New PdfPCell(New Phrase(qty.ToString())))
                            table.AddCell(New PdfPCell(New Phrase("₱" & price.ToString("N2"))))
                            table.AddCell(New PdfPCell(New Phrase("₱" & subtotal.ToString("N2"))))
                        End While
                    End Using

                    doc.Add(table)
                    doc.Add(spacer)
                    doc.Add(separator)
                    doc.Add(spacer)

                    ' Total
                    Dim totalPara = New Paragraph($"GRAND TOTAL: ₱{grandTotal:N2}", bigBoldFont)
                    totalPara.Alignment = Element.ALIGN_RIGHT
                    doc.Add(totalPara)

                    doc.Add(spacer)
                    doc.Add(separator)
                    doc.Add(spacer)

                    doc.Add(New Paragraph("Thank you for shopping with Prestige Apparel!", subFont) With {.Alignment = Element.ALIGN_CENTER})
                    doc.Add(New Paragraph("This serves as your official receipt.", subFont) With {.Alignment = Element.ALIGN_CENTER})
                End Using

                doc.Close()
            End Using

            Process.Start(New ProcessStartInfo With {
            .FileName = savePath,
            .UseShellExecute = True
        })

            MessageBox.Show("Receipt has been saved to your Desktop under 'Prestige Receipts'.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error generating PDF: " & ex.Message, "PDF Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub customerProfile_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        MenuStrip1.Renderer = appthemes.MenuRenderer
        LoadCustomerOrders(FlowLayoutPanel1, loggedInUserID)
        LoadNotifications()

        If adminUserLogin = "" Then
            LoadCustomerContactInfo(loggedInUserID)

        Else
            Exit Sub
        End If



    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click, Label5.Click

    End Sub
    ' ' Load customer contact information into labels
    Public Sub LoadCustomerContactInfo(customerId As Integer)
        Dim query As String = "
        SELECT address, contact_number 
        FROM customers 
        WHERE customer_id = @custID
    "

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@custID", customerId)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            deliveryAddress.Text = "Address: " & reader("address").ToString()
                            contactNumber.Text = "Contact #: " & reader("contact_number").ToString()
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading customer info: " & ex.Message)
        End Try
    End Sub


    '    ' Load customer orders into the FlowLayoutPanel
    Public Sub LoadCustomerOrders(container As FlowLayoutPanel, customerId As Integer, Optional statusFilter As String = "")
        container.Controls.Clear()

        ' Build dynamic query
        Dim query As New StringBuilder("
        SELECT 
            od.order_id,
            p.product_name,
            o.order_date,
            p.image_path,
            od.quantity,
            o.order_status
        FROM order_details od
        INNER JOIN orders o ON od.order_id = o.order_id
        INNER JOIN products p ON od.product_id = p.product_id
        WHERE o.customer_id = @custID
    ")

        Select Case statusFilter
            Case "Completed"
                query.Append(" AND o.order_status = 'Completed'")
            Case "Cancelled"
                query.Append(" AND o.order_status = 'Cancelled'")
            Case Else
                query.Append(" AND o.order_status IN ('Pending', 'Processing')")
        End Select

        query.Append(" ORDER BY o.order_date DESC")

        ' Load and render order items
        Try
            Using conn As New MySqlConnection(connectionString),
              cmd As New MySqlCommand(query.ToString(), conn)

                cmd.Parameters.AddWithValue("@custID", customerId)
                conn.Open()

                Using reader As MySqlDataReader = cmd.ExecuteReader()
                    While reader.Read()
                        ' Create order panel
                        Dim orderPanel As New Panel With {
                        .Size = New Size(450, 165),
                        .BorderStyle = BorderStyle.FixedSingle,
                        .BackColor = Color.White,
                        .Margin = New Padding(10)
                    }

                        ' Product Image
                        Dim imagePath = reader("image_path").ToString()
                        Dim productImage As New PictureBox With {
                        .Size = New Size(120, 120),
                        .SizeMode = PictureBoxSizeMode.Zoom,
                        .Location = New Point(15, 20)
                    }
                        If File.Exists(imagePath) Then
                            productImage.Image = System.Drawing.Image.FromFile(imagePath)
                        End If
                        orderPanel.Controls.Add(productImage)

                        ' Label setup helper
                        Dim CreateLabel = Function(text As String, font As System.Drawing.Font, location As Point, foreColor As Color) As Label
                                              Return New Label With {
                                              .Text = text,
                                              .Font = font,
                                              .Location = location,
                                              .ForeColor = foreColor,
                                              .AutoSize = True
                                          }
                                          End Function

                        ' Product Name
                        orderPanel.Controls.Add(CreateLabel(reader("product_name").ToString(), New System.Drawing.Font("Segoe UI", 10, FontStyle.Bold), New Point(150, 25), Color.Black))

                        ' Quantity
                        orderPanel.Controls.Add(CreateLabel("Qty: " & reader("quantity").ToString(), New System.Drawing.Font("Segoe UI", 10), New Point(150, 50), Color.Black))

                        ' Status
                        Dim orderStatus = reader("order_status").ToString()
                        Dim statusColor As Color = If(orderStatus = "Completed", Color.ForestGreen,
                                             If(orderStatus = "Cancelled", Color.Red, Color.DarkOrange))
                        orderPanel.Controls.Add(CreateLabel("Status: " & orderStatus, New System.Drawing.Font("Segoe UI", 10, FontStyle.Bold), New Point(150, 75), statusColor))

                        ' Date & Time
                        Dim orderDateTime = Convert.ToDateTime(reader("order_date"))
                        orderPanel.Controls.Add(CreateLabel("Ordered on: " & orderDateTime.ToString("MMMM dd, yyyy"), New System.Drawing.Font("Segoe UI", 9, FontStyle.Italic), New Point(150, 100), Color.Gray))
                        orderPanel.Controls.Add(CreateLabel("at " & orderDateTime.ToString("hh:mm tt"), New System.Drawing.Font("Segoe UI", 9, FontStyle.Italic), New Point(150, 120), Color.Gray))

                        container.Controls.Add(orderPanel)
                    End While
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading customer orders: " & ex.Message, "Load Orders", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub toRecieveMenuStrip_Click(sender As Object, e As EventArgs) Handles toRecieveMenuStrip.Click
        ' ' Load orders that are pending or processing
        LoadCustomerOrders(FlowLayoutPanel1, loggedInUserID)

    End Sub

    Private Sub COMPLETEDToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompleteOrdersBtnMenu.Click
        ' ' Load completed orders
        LoadCustomerOrders(FlowLayoutPanel1, loggedInUserID, "Completed")

    End Sub

    Private Sub CANCELLEDToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CANCELLEDToolStripMenuItem.Click
        ' ' Load cancelled orders
        LoadCustomerOrders(FlowLayoutPanel1, loggedInUserID, "Cancelled")

    End Sub

    Private Sub changeAddress_Click(sender As Object, e As EventArgs) Handles changeAddress.Click
        ' Prompt user for new address
        Dim newAddress As String = InputBox("Enter new delivery address:", "Update Address", deliveryAddress.Text.Replace("Address: ", ""))

        If String.IsNullOrWhiteSpace(newAddress) Then
            MessageBox.Show("Address cannot be empty.")
            Return
        End If

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim query As String = "UPDATE customers SET address = @address WHERE customer_id = @custID"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@address", newAddress)
                    cmd.Parameters.AddWithValue("@custID", loggedInUserID)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Address updated successfully.")
            LoadCustomerContactInfo(loggedInUserID) ' Refresh label
        Catch ex As Exception
            MessageBox.Show("Error updating address: " & ex.Message)
        End Try
    End Sub

    Private Sub ChangeContactNum_Click(sender As Object, e As EventArgs) Handles ChangeContactNum.Click
        ' Prompt user for new Contact Number
        Dim newContact As String = InputBox("Enter new contact number:", "Update Contact Number", contactNumber.Text.Replace("Contact #: ", ""))

        If String.IsNullOrWhiteSpace(newContact) Then
            MessageBox.Show("Contact number cannot be empty.")
            Return
        End If

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim query As String = "UPDATE customers SET contact_number = @contact WHERE customer_id = @custID"
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@contact", newContact)
                    cmd.Parameters.AddWithValue("@custID", loggedInUserID)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Contact number updated successfully.")
            LoadCustomerContactInfo(loggedInUserID) ' Refresh label
        Catch ex As Exception
            MessageBox.Show("Error updating contact number: " & ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        loggedInUserID = 0

        adminUserLogin = ""
        Form1.adminPage.Visible = False
        Form1.welcomeName.Hide()
        ' Close this form
        appthemes.FadeOutForm(Me)
    End Sub
End Class