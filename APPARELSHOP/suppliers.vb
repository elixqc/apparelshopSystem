Imports MySql.Data.MySqlClient
Imports System.Drawing

Public Class suppliers

    Private Sub LoadSupplierPanel()

        Dim existingPanel = Me.Controls.OfType(Of FlowLayoutPanel)().FirstOrDefault()
        If existingPanel IsNot Nothing Then
            Me.Controls.Remove(existingPanel)
        End If


        Dim panelContainer As New FlowLayoutPanel With {
        .Dock = DockStyle.Fill,
        .AutoScroll = True,
        .WrapContents = False,
        .FlowDirection = FlowDirection.TopDown,
        .Padding = New Padding(10)
    }
        Me.Controls.Add(panelContainer)

        ' --- Connection setup
        Dim conn As New MySqlConnection(connectionString)
        Dim cmd As New MySqlCommand("SELECT * FROM suppliers", conn)

        Try
            conn.Open()
            Dim reader As MySqlDataReader = cmd.ExecuteReader()

            While reader.Read()
                Dim supplierPanel As New Panel With {
                .Width = 500,
                .Height = 200,
                .BackColor = Color.WhiteSmoke,
                .Padding = New Padding(10),
                .Margin = New Padding(5)
            }

                Dim lblName As New Label With {
                .Text = "Name: " & reader("supplier_name").ToString(),
                .Font = New Font("Microsoft Himalaya", 16, FontStyle.Regular),
                .AutoSize = True
            }

                Dim lblPerson As New Label With {
                .Text = "Contact Person: " & reader("contact_person").ToString(),
                .Font = New Font("Microsoft Himalaya", 16, FontStyle.Regular),
                .AutoSize = True
            }

                Dim lblNumber As New Label With {
                .Text = "Contact No: " & reader("contact_number").ToString(),
                .Font = New Font("Microsoft Himalaya", 16, FontStyle.Regular),
                .AutoSize = True
            }

                Dim lblAddress As New Label With {
                .Text = "Address: " & reader("address").ToString(),
                .Font = New Font("Microsoft Himalaya", 16, FontStyle.Regular),
                .AutoSize = True
            }

                Dim lblStatus As New Label With {
                .Text = "Active: " & If(Convert.ToBoolean(reader("is_active")), "Yes", "No"),
                .Font = New Font("Microsoft Himalaya", 16, FontStyle.Regular),
                .AutoSize = True
            }
                Dim btnToggleStatus As New Button With {
                .Text = If(Convert.ToBoolean(reader("is_active")), "Set Inactive", "Set Active"),
                .Font = New Font("Microsoft Himalaya", 16, FontStyle.Regular),
                .BackColor = Color.FromArgb(74, 80, 66),
                .ForeColor = Color.White,
                .Width = 120,
                .Height = 30
            }

                Dim supplierId As Integer = Convert.ToInt32(reader("supplier_id"))
                AddHandler btnToggleStatus.Click, Sub()
                                                      Try
                                                          Using connToggle As New MySqlConnection(connectionString)
                                                              connToggle.Open()
                                                              Dim toggleQuery As String = "UPDATE suppliers SET is_active = NOT is_active WHERE supplier_id = @id"
                                                              Using cmdToggle As New MySqlCommand(toggleQuery, connToggle)
                                                                  cmdToggle.Parameters.AddWithValue("@id", supplierId)
                                                                  cmdToggle.ExecuteNonQuery()
                                                              End Using
                                                          End Using
                                                          LoadSupplierPanel() ' Refresh the panel after update
                                                      Catch ex As Exception
                                                          MessageBox.Show("Error toggling status: " & ex.Message)
                                                      End Try
                                                  End Sub


                supplierPanel.Controls.Add(lblName)
                supplierPanel.Controls.Add(lblPerson)
                supplierPanel.Controls.Add(lblNumber)
                supplierPanel.Controls.Add(lblAddress)
                supplierPanel.Controls.Add(lblStatus)
                supplierPanel.Controls.Add(btnToggleStatus)


                ' Arrange vertically
                Dim yOffset As Integer = 10
                For Each ctrl As Control In supplierPanel.Controls
                    ctrl.Location = New Point(10, yOffset)
                    yOffset += ctrl.Height + 5
                Next

                panelContainer.Controls.Add(supplierPanel)
            End While
            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error loading suppliers: " & ex.Message)
        Finally
            conn.Close()
        End Try

        ' --- Add supplier form section
        Dim addPanel As New Panel With {
        .Width = 500,
        .Height = 220,
        .BackColor = Color.LightGray,
        .Padding = New Padding(10),
        .Margin = New Padding(5)
    }

        Dim txtName As New TextBox With {.Width = 300, .Text = "Supplier Name", .ForeColor = Color.Gray}
        AddHandler txtName.GotFocus, Sub()
                                         If txtName.Text = "Supplier Name" Then
                                             txtName.Text = ""
                                             txtName.ForeColor = Color.Black
                                         End If
                                     End Sub
        AddHandler txtName.LostFocus, Sub()
                                          If txtName.Text = "" Then
                                              txtName.Text = "Supplier Name"
                                              txtName.ForeColor = Color.Gray
                                          End If
                                      End Sub

        Dim txtPerson As New TextBox With {.Width = 300, .Text = "Contact Person", .ForeColor = Color.Gray}
        AddHandler txtPerson.GotFocus, Sub()
                                           If txtPerson.Text = "Contact Person" Then
                                               txtPerson.Text = ""
                                               txtPerson.ForeColor = Color.Black
                                           End If
                                       End Sub
        AddHandler txtPerson.LostFocus, Sub()
                                            If txtPerson.Text = "" Then
                                                txtPerson.Text = "Contact Person"
                                                txtPerson.ForeColor = Color.Gray
                                            End If
                                        End Sub

        Dim txtNumber As New TextBox With {.Width = 300, .Text = "Contact Number", .ForeColor = Color.Gray}
        AddHandler txtNumber.GotFocus, Sub()
                                           If txtNumber.Text = "Contact Number" Then
                                               txtNumber.Text = ""
                                               txtNumber.ForeColor = Color.Black
                                           End If
                                       End Sub
        AddHandler txtNumber.LostFocus, Sub()
                                            If txtNumber.Text = "" Then
                                                txtNumber.Text = "Contact Number"
                                                txtNumber.ForeColor = Color.Gray
                                            End If
                                        End Sub

        Dim txtAddress As New TextBox With {.Width = 300, .Text = "Address", .ForeColor = Color.Gray}
        AddHandler txtAddress.GotFocus, Sub()
                                            If txtAddress.Text = "Address" Then
                                                txtAddress.Text = ""
                                                txtAddress.ForeColor = Color.Black
                                            End If
                                        End Sub
        AddHandler txtAddress.LostFocus, Sub()
                                             If txtAddress.Text = "" Then
                                                 txtAddress.Text = "Address"
                                                 txtAddress.ForeColor = Color.Gray
                                             End If
                                         End Sub

        Dim txtBrand As New TextBox With {.Width = 300, .Text = "Brand Name", .ForeColor = Color.Gray}
        AddHandler txtBrand.GotFocus, Sub()
                                          If txtAddress.Text = "Brand Name" Then
                                              txtAddress.Text = ""
                                              txtAddress.ForeColor = Color.Black
                                          End If
                                      End Sub
        AddHandler txtBrand.LostFocus, Sub()
                                           If txtAddress.Text = "" Then
                                               txtAddress.Text = "Brand Name"
                                               txtAddress.ForeColor = Color.Gray
                                           End If
                                       End Sub

        Dim chkActive As New CheckBox With {.Text = "Active", .Checked = True}
        Dim btnAdd As New Button With {
            .Text = "Add Supplier", .Font = New Font("Microsoft Himalaya", 16, FontStyle.Regular),
                .BackColor = Color.FromArgb(74, 80, 66)}

        ' Positioning controls
        txtName.Location = New Point(10, 10)
        txtPerson.Location = New Point(10, 40)
        txtNumber.Location = New Point(10, 70)
        txtAddress.Location = New Point(10, 100)
        txtBrand.Location = New Point(10, 130)
        chkActive.Location = New Point(10, 160)
        btnAdd.Location = New Point(10, 190)

        addPanel.Controls.AddRange({txtName, txtPerson, txtNumber, txtAddress, txtBrand, chkActive, btnAdd})

        panelContainer.Controls.Add(addPanel)

        ' --- Add button functionality
        AddHandler btnAdd.Click, Sub()
                                     If txtName.Text = "" Or txtPerson.Text = "" Or txtNumber.Text = "" Or txtAddress.Text = "" Or txtBrand.Text = "" Then
                                         MessageBox.Show("Please fill in all fields.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                         Return
                                     End If

                                     Using conn2 As New MySqlConnection(connectionString)
                                         conn2.Open()

                                         Dim transaction As MySqlTransaction = conn2.BeginTransaction()

                                         Try
                                             ' Insert into suppliers
                                             Dim insertSupplierQuery As String = "INSERT INTO suppliers (supplier_name, contact_person, contact_number, address, is_active) VALUES (@name, @person, @number, @address, @active)"
                                             Dim cmdInsertSupplier As New MySqlCommand(insertSupplierQuery, conn2, transaction)
                                             cmdInsertSupplier.Parameters.AddWithValue("@name", txtName.Text)
                                             cmdInsertSupplier.Parameters.AddWithValue("@person", txtPerson.Text)
                                             cmdInsertSupplier.Parameters.AddWithValue("@number", txtNumber.Text)
                                             cmdInsertSupplier.Parameters.AddWithValue("@address", txtAddress.Text)
                                             cmdInsertSupplier.Parameters.AddWithValue("@active", If(chkActive.Checked, 1, 0))
                                             cmdInsertSupplier.ExecuteNonQuery()

                                             ' Get the inserted supplier_id
                                             Dim supplierId As Integer = CInt(cmdInsertSupplier.LastInsertedId)

                                             ' Insert into brands
                                             Dim insertBrandQuery As String = "INSERT INTO brands (brand_name, supplier_id) VALUES (@brandName, @supplierId)"
                                             Dim cmdInsertBrand As New MySqlCommand(insertBrandQuery, conn2, transaction)
                                             cmdInsertBrand.Parameters.AddWithValue("@brandName", txtBrand.Text)
                                             cmdInsertBrand.Parameters.AddWithValue("@supplierId", supplierId)
                                             cmdInsertBrand.ExecuteNonQuery()

                                             ' Commit both inserts
                                             transaction.Commit()

                                             MessageBox.Show("Supplier and brand added successfully!")
                                             panelContainer.Controls.Clear()
                                             LoadSupplierPanel() ' Reload panel

                                         Catch ex As Exception
                                             transaction.Rollback()
                                             MessageBox.Show("Failed to add supplier and brand: " & ex.Message)
                                         End Try
                                     End Using
                                     AdminFormPage.LoadSuppliers()
                                     AdminFormPage.LoadBrands()
                                 End Sub


    End Sub


    Private Sub suppliers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSupplierPanel()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LoadSupplierPanel()
    End Sub
End Class