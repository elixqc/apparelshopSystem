Imports MySql.Data.MySqlClient
Imports System.Drawing
Imports System.IO

Public Class customerProfile
    Private Sub customerProfile_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        MenuStrip1.Renderer = appthemes.MenuRenderer
        LoadCustomerOrders(FlowLayoutPanel1, loggedInUserID)


    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Public Sub LoadCustomerOrders(container As FlowLayoutPanel, customerId As Integer)
        container.Controls.Clear()

        Dim query As String = "
            SELECT 
                od.order_id,
                p.product_name,
                p.image_path,
                od.quantity,
                o.order_status
            FROM order_details od
            INNER JOIN orders o ON od.order_id = o.order_id
            INNER JOIN products p ON od.product_id = p.product_id
            WHERE o.customer_id = @custID
              AND (o.order_status = 'Pending' OR o.order_status = 'Processing')
            ORDER BY o.order_date DESC
        "

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
                            Dim statusLabel As New Label With {
                                .Text = "Status: " & reader("order_status").ToString(),
                                .Font = New Font("Microsoft Sans Serif", 10, FontStyle.Bold),
                                .ForeColor = Color.DarkOrange,
                                .Location = New Point(147, 78),
                                .AutoSize = True
                            }
                            panel.Controls.Add(statusLabel)

                            container.Controls.Add(panel)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading orders: " & ex.Message)
        End Try
    End Sub
End Class