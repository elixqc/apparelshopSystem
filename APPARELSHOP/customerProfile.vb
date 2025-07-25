Imports System.Drawing
Imports System.IO
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports iTextSharp.text.pdf.draw
Imports MySql.Data.MySqlClient



Public Class customerProfile

    Private Sub LoadNotifications()
        FlowLayoutPanel2.Controls.Clear()

        Using conn As New MySqlConnection(connectionString)
            conn.Open()

            Dim query As String = "
            SELECT 
                n.notification_id, 
                n.order_id, 
                (
                    SELECT SUM(od.unit_price * od.quantity) 
                    FROM order_details od 
                    WHERE od.order_id = n.order_id
                ) AS total_price
            FROM notifications n
            INNER JOIN orders o ON n.order_id = o.order_id
            WHERE n.customer_id = @uid 
              AND n.is_read = FALSE 
              AND o.order_status = 'Completed'
            ORDER BY n.date_created DESC
        "

            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@uid", loggedInUserID)

            Using reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    Dim notifPanel As New Panel With {
                    .Width = 450,
                    .Height = 70,
                    .BackColor = Color.White,
                    .Margin = New Padding(5)
                }

                    Dim lblNotif As New Label With {
                    .Text = "Your order #" & reader("order_id").ToString() &
                            " (₱" & Format(CDec(reader("total_price")), "N2") &
                            ") has been completed.",
                    .AutoSize = True,
                    .Location = New Point(10, 10),
                    .Font = New System.Drawing.Font("Segoe UI", 10, FontStyle.Regular)
                }

                    Dim btnDownload As New Button With {
                    .Text = "Download Receipt",
                    .Size = New Size(140, 30),
                    .Location = New Point(10, 35),
                    .Tag = reader("order_id")
                }

                    AddHandler btnDownload.Click,
                Sub(senderBtn As Object, eBtn As EventArgs)
                    Dim orderId As Integer = CInt(CType(senderBtn, Button).Tag)

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

                        GenerateReceiptPDF(orderId)
                        LoadNotifications()

                    Catch ex As Exception
                        MessageBox.Show("Error: " & ex.Message)
                    End Try
                End Sub

                    notifPanel.Controls.Add(lblNotif)
                    notifPanel.Controls.Add(btnDownload)
                    FlowLayoutPanel2.Controls.Add(notifPanel)
                End While
            End Using
        End Using
    End Sub


    Private Sub GenerateReceiptPDF(orderId As Integer)
        Dim connStr As String = connectionString
        Dim folderPath As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Downloads")
        If Not Directory.Exists(folderPath) Then
            Directory.CreateDirectory(folderPath)
        End If

        Dim savePath As String = Path.Combine(folderPath, $"Receipt_Order_{orderId}.pdf")

        Try
            ' Prepare the PDF document
            Dim doc As New Document(PageSize.A4, 50, 50, 25, 25)
            Dim fs As New FileStream(savePath, FileMode.Create, FileAccess.Write, FileShare.Read)

            Dim writer As PdfWriter = PdfWriter.GetInstance(doc, fs)
            doc.Open()

            ' Fonts
            Dim titleFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 18, iTextSharp.text.Font.BOLD)
            Dim subFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12)
            Dim boldFont As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.BOLD)

            Dim separator As New Paragraph(New Chunk(New LineSeparator(1.0F, 100.0F, BaseColor.GRAY, Element.ALIGN_CENTER, -1)))
            Dim spacer As New Paragraph(Environment.NewLine)

            ' Header
            doc.Add(New Paragraph("PRESTIGE APPAREL", titleFont))
            doc.Add(New Paragraph("Official Receipt", subFont))
            doc.Add(New Paragraph($"Order ID: {orderId}", subFont))
            doc.Add(New Paragraph($"Date: {DateTime.Now:MMMM dd, yyyy hh:mm tt}", subFont))
            doc.Add(New Paragraph(Environment.NewLine))

            ' DB Connection
            Using conn As New MySqlConnection(connStr)
                conn.Open()

                ' Customer Info
                Dim summaryCmd As New MySqlCommand("
                SELECT o.date_received, c.full_name
                FROM orders o
                JOIN customers c ON o.customer_id = c.customer_id
                WHERE o.order_id = @oid", conn)
                summaryCmd.Parameters.AddWithValue("@oid", orderId)

                Using reader = summaryCmd.ExecuteReader()
                    If reader.Read() Then
                        doc.Add(New Paragraph($"Customer: {reader("full_name")}"))
                        doc.Add(New Paragraph($"Date Received: {Convert.ToDateTime(reader("date_received")).ToString("MMMM dd, yyyy")}"))
                        doc.Add(New Paragraph(Environment.NewLine))
                    End If
                End Using

                ' Table Setup
                Dim table As New PdfPTable(4)
                table.WidthPercentage = 100
                table.SetWidths(New Single() {50, 15, 15, 20})
                ' Optional: Light gray background for header
                Dim headerBackground As New BaseColor(240, 240, 240) ' Light gray

                Dim cell1 As New PdfPCell(New Phrase("Product", boldFont))
                cell1.BackgroundColor = headerBackground
                table.AddCell(cell1)

                Dim cell2 As New PdfPCell(New Phrase("Qty", boldFont))
                cell2.BackgroundColor = headerBackground
                table.AddCell(cell2)

                Dim cell3 As New PdfPCell(New Phrase("Price", boldFont))
                cell3.BackgroundColor = headerBackground
                table.AddCell(cell3)

                Dim cell4 As New PdfPCell(New Phrase("Subtotal", boldFont))
                cell4.BackgroundColor = headerBackground
                table.AddCell(cell4)

                doc.Add(spacer)
                doc.Add(separator)
                doc.Add(spacer)





                ' Order Items
                Dim itemCmd As New MySqlCommand("
                SELECT p.product_name, od.quantity, od.unit_price AS price
                FROM order_details od
                JOIN products p ON od.product_id = p.product_id
                WHERE od.order_id = @oid", conn)
                itemCmd.Parameters.AddWithValue("@oid", orderId)

                Dim grandTotal As Decimal = 0

                Using itemReader = itemCmd.ExecuteReader()
                    While itemReader.Read()
                        Dim name = itemReader("product_name").ToString()
                        Dim qty = Convert.ToInt32(itemReader("quantity"))
                        Dim price = Convert.ToDecimal(itemReader("price"))
                        Dim subtotal = qty * price
                        grandTotal += subtotal

                        table.AddCell(name)
                        table.AddCell(qty.ToString())
                        table.AddCell("₱" & price.ToString("N2"))
                        table.AddCell("₱" & subtotal.ToString("N2"))
                    End While
                End Using

                doc.Add(table)

                doc.Add(spacer)
                doc.Add(separator)
                doc.Add(spacer)

                doc.Add(New Paragraph($"Total: ₱{grandTotal:N2}", boldFont))


                doc.Add(spacer)
                doc.Add(separator)
                doc.Add(spacer)

                doc.Add(New Paragraph("Thank you for your purchase!", subFont))
            End Using

            ' Close and clean up
            doc.Close()
            fs.Close()

            ' ✅ Open the file after saving
            Process.Start(New ProcessStartInfo With {
            .FileName = savePath,
            .UseShellExecute = True
        })

            MessageBox.Show("Receipt downloaded to your Downloads folder.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error generating PDF: " & ex.Message)
        End Try
    End Sub





    Private Sub DownloadReceipt(sender As Object, e As EventArgs)
        Dim btn As Button = CType(sender, Button)
        Dim orderId As Integer = CInt(btn.Tag)

        Using conn As New MySqlConnection(connectionString)
            conn.Open()

            ' Get order and customer info
            Dim cmd As New MySqlCommand("
            SELECT o.order_id, o.date_ordered, o.date_received, u.username
            FROM orders o
            JOIN users u ON o.user_id = u.user_id
            WHERE o.order_id = @oid", conn)
            cmd.Parameters.AddWithValue("@oid", orderId)

            Dim orderInfo = cmd.ExecuteReader()
            If Not orderInfo.Read() Then Return

            Dim username = orderInfo("username").ToString()
            Dim dateOrdered = Convert.ToDateTime(orderInfo("date_ordered")).ToShortDateString()
            Dim dateReceived = Convert.ToDateTime(orderInfo("date_received")).ToShortDateString()
            orderInfo.Close()

            ' Get order items
            Dim itemsCmd As New MySqlCommand("
            SELECT p.product_name, od.quantity, od.unit_price
            FROM order_details od
            JOIN products p ON od.product_id = p.product_id
            WHERE od.order_id = @oid", conn)
            itemsCmd.Parameters.AddWithValue("@oid", orderId)

            Dim items = itemsCmd.ExecuteReader()

            ' Generate PDF
            Dim savePath = $"Receipt_Order_{orderId}.pdf"
            Dim doc As New Document()
            PdfWriter.GetInstance(doc, New FileStream(savePath, FileMode.Create))
            doc.Open()

            doc.Add(New Paragraph("SHOP NAME"))
            doc.Add(New Paragraph("Official Receipt"))
            doc.Add(New Paragraph("Order ID: " & orderId))
            doc.Add(New Paragraph("Customer: " & username))
            doc.Add(New Paragraph("Date Ordered: " & dateOrdered))
            doc.Add(New Paragraph("Date Received: " & dateReceived))
            doc.Add(New Paragraph(" "))
            doc.Add(New Paragraph("Items:"))

            Dim table As New PdfPTable(4)
            table.AddCell("Product")
            table.AddCell("Quantity")
            table.AddCell("Unit Price")
            table.AddCell("Subtotal")

            Dim total As Decimal = 0
            While items.Read()
                Dim pname = items("product_name").ToString()
                Dim qty = CInt(items("quantity"))
                Dim price = CDec(items("unit_price"))
                Dim subtotal = qty * price

                table.AddCell(pname)
                table.AddCell(qty.ToString())
                table.AddCell(price.ToString("C"))
                table.AddCell(subtotal.ToString("C"))

                total += subtotal
            End While
            doc.Add(table)
            doc.Add(New Paragraph(" "))
            doc.Add(New Paragraph("Total: " & total.ToString("C")))
            doc.Add(New Paragraph("Thank you for shopping!"))
            doc.Close()
            items.Close()
        End Using

        MessageBox.Show("Receipt downloaded.")
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

        Dim query As String = "
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
        "

        If statusFilter = "Completed" Then
            query &= " AND o.order_status = 'Completed'"
        ElseIf statusFilter = "Cancelled" Then
            query &= " AND o.order_status = 'Cancelled'"
        Else
            query &= " AND (o.order_status = 'Pending' OR o.order_status = 'Processing')"
        End If

        query &= " ORDER BY o.order_date DESC"

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@custID", customerId)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            ' Create panel for each order item
                            Dim panel As New Panel With {
                                .Width = 450,
                                .Height = 165,
                                .BorderStyle = BorderStyle.None,
                                .Margin = New Padding(10)
                            }

                            ' Product Image
                            Dim imagePath As String = reader("image_path").ToString()
                            Dim productImage As New PictureBox With {
                                .Size = New Size(120, 120),
                                .SizeMode = PictureBoxSizeMode.StretchImage,
                                .Location = New Point(19, 30)
                            }
                            If File.Exists(imagePath) Then
                                productImage.Image = System.Drawing.Image.FromFile(imagePath)
                            End If
                            panel.Controls.Add(productImage)

                            ' Product Name Label
                            Dim nameLabel As New Label With {
                                .Text = reader("product_name").ToString(),
                                .Font = New System.Drawing.Font("Microsoft Sans Serif", 10),
                                .Location = New Point(147, 36),
                                .AutoSize = True
                            }
                            panel.Controls.Add(nameLabel)

                            ' Quantity Label
                            Dim qtyLabel As New Label With {
                                .Text = "Qty: " & reader("quantity").ToString(),
                                .Font = New System.Drawing.Font("Microsoft Sans Serif", 10),
                                .Location = New Point(147, 57),
                                .AutoSize = True
                            }
                            panel.Controls.Add(qtyLabel)

                            ' Order Status Label
                            Dim orderStatus As String = reader("order_status").ToString()
                            Dim statusColor As Color

                            Select Case orderStatus
                                Case "Completed"
                                    statusColor = Color.ForestGreen
                                Case "Cancelled"
                                    statusColor = Color.Red
                                Case Else
                                    statusColor = Color.DarkOrange ' For Pending, Processing, etc.
                            End Select

                            Dim statusLabel As New Label With {
                            .Text = "Status: " & orderStatus,
                            .Font = New System.Drawing.Font("Microsoft Sans Serif", 10, FontStyle.Bold),
                            .ForeColor = statusColor,
                            .Location = New Point(147, 78),
                            .AutoSize = True
                            }
                            panel.Controls.Add(statusLabel)

                            ' Order Date and Time
                            Dim orderDateTime As DateTime = Convert.ToDateTime(reader("order_date"))

                            Dim dateLabel As New Label With {
                                .Text = "Ordered on: " & orderDateTime.ToString("MMMM dd, yyyy"),
                                .Font = New System.Drawing.Font("Microsoft Sans Serif", 9, FontStyle.Italic),
                                .ForeColor = Color.Gray,
                                .Location = New Point(147, 99),
                                .AutoSize = True
                            }
                            panel.Controls.Add(dateLabel)

                            Dim timeLabel As New Label With {
                                .Text = "at " & orderDateTime.ToString("hh:mm tt"),
                                .Font = New System.Drawing.Font("Microsoft Sans Serif", 9, FontStyle.Italic),
                                .ForeColor = Color.Gray,
                                .Location = New Point(147, 117),
                                .AutoSize = True
                            }
                            panel.Controls.Add(timeLabel)

                            container.Controls.Add(panel)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading orders: " & ex.Message)
        End Try
    End Sub

    Private Sub toRecieveMenuStrip_Click(sender As Object, e As EventArgs) Handles toRecieveMenuStrip.Click
        LoadCustomerOrders(FlowLayoutPanel1, loggedInUserID)
    End Sub

    Private Sub COMPLETEDToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CompleteOrdersBtnMenu.Click
        LoadCustomerOrders(FlowLayoutPanel1, loggedInUserID, "Completed")
    End Sub

    Private Sub CANCELLEDToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CANCELLEDToolStripMenuItem.Click
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

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub
End Class