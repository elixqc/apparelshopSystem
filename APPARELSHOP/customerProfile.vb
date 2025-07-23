Imports MySql.Data.MySqlClient
Imports System.Drawing
Imports System.IO

Public Class customerProfile
    Private Sub customerProfile_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        MenuStrip1.Renderer = appthemes.MenuRenderer
        LoadCustomerOrders(FlowLayoutPanel1, loggedInUserID)
        LoadCustomerContactInfo(loggedInUserID)


    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

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
                                productImage.Image = Image.FromFile(imagePath)
                            End If
                            panel.Controls.Add(productImage)

                            ' Product Name Label
                            Dim nameLabel As New Label With {
                                .Text = reader("product_name").ToString(),
                                .Font = New Font("Microsoft Sans Serif", 10),
                                .Location = New Point(147, 36),
                                .AutoSize = True
                            }
                            panel.Controls.Add(nameLabel)

                            ' Quantity Label
                            Dim qtyLabel As New Label With {
                                .Text = "Qty: " & reader("quantity").ToString(),
                                .Font = New Font("Microsoft Sans Serif", 10),
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
                            .Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold),
                            .ForeColor = statusColor,
                            .Location = New Point(147, 78),
                            .AutoSize = True
                            }
                            panel.Controls.Add(statusLabel)

                            ' Order Date and Time
                            Dim orderDateTime As DateTime = Convert.ToDateTime(reader("order_date"))

                            Dim dateLabel As New Label With {
                                .Text = "Ordered on: " & orderDateTime.ToString("MMMM dd, yyyy"),
                                .Font = New Font("Microsoft Sans Serif", 9, FontStyle.Italic),
                                .ForeColor = Color.Gray,
                                .Location = New Point(147, 99),
                                .AutoSize = True
                            }
                            panel.Controls.Add(dateLabel)

                            Dim timeLabel As New Label With {
                                .Text = "at " & orderDateTime.ToString("hh:mm tt"),
                                .Font = New Font("Microsoft Sans Serif", 9, FontStyle.Italic),
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



        ' Close this form
        appthemes.FadeOutForm(Me)
    End Sub
End Class