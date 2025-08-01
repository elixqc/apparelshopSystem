Imports MySql.Data.MySqlClient
Imports System.IO

Public Class apparelPageSample

    Dim conn As New MySqlConnection("server=localhost;userid=root;password=;database=apparelshopdb")

    Private Sub LoadAllProductPanels(Optional searchKeyword As String = "")
        Flowproductpanel.Controls.Clear()

        Dim productTypes = GetAllProductTypes(searchKeyword)
        For Each type In productTypes
            CreateProductPanel(type, Flowproductpanel)
        Next
    End Sub

    Private Sub FlowLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles Flowproductpanel.Paint

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub apparelPageSample_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Flowproductpanel.Controls.Clear()
        LoadAllProductPanels()

        ' panel for search function
        Dim headerPanel As New Panel With {
                .Height = 50,
                .Dock = DockStyle.Top,
                .BackColor = Color.White
            }
        Me.Controls.Add(headerPanel)

        ' Create search textbox
        Dim searchBox As New TextBox With {
                .Width = 200,
                .Font = New Font("Microsoft Himalaya", 14.25),
                .Left = headerPanel.Width - 300,
                .Top = 12,
                .Anchor = AnchorStyles.Top Or AnchorStyles.Right
            }
        headerPanel.Controls.Add(searchBox)

        ' Create search button
        Dim searchBtn As New Button With {
                .Text = "Search",
                .Font = New Font("Microsoft Himalaya", 14.25),
                .ForeColor = Color.White, ' font color
                .BackColor = Color.FromArgb(74, 80, 66), ' background color
                .FlatStyle = FlatStyle.Flat,
                .Width = 80,
                .Left = headerPanel.Width - 90,
                .Top = 12,
                .Anchor = AnchorStyles.Top Or AnchorStyles.Right
            }
        headerPanel.Controls.Add(searchBtn)

        ' Update control positions on resize
        AddHandler headerPanel.Resize, Sub()
                                           searchBox.Left = headerPanel.Width - 300
                                           searchBtn.Left = headerPanel.Width - 90
                                       End Sub
        AddHandler searchBtn.Click, Sub(senderBtn, args)
                                        Dim keyword = searchBox.Text.Trim()
                                        LoadAllProductPanels(keyword)
                                    End Sub
        Flowproductpanel.Dock = DockStyle.Fill




    End Sub

    Private Sub btnLoadProducts_Click(sender As Object, e As EventArgs) Handles btnLoadProducts.Click

    End Sub
End Class