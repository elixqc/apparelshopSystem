Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Drawing
Public Class perfumepageFemale

    'get female perfume types from the database
    Public Function GetFemalePerfumeTypes() As List(Of String)
        Dim types As New HashSet(Of String)

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim cmd As New MySqlCommand("
                SELECT DISTINCT product_name 
                FROM products 
                WHERE gender = 'Female' 
                  AND category_id IN (7, 8, 9, 10, 11, 12)
            ", conn)

                Dim reader As MySqlDataReader = cmd.ExecuteReader()

                While reader.Read()
                    Dim fullName As String = reader("product_name").ToString()
                    ' Remove trailing " EDT" if present
                    If fullName.EndsWith(" EDT") Or fullName.EndsWith(" EDP") Then
                        types.Add(fullName.Substring(0, fullName.Length - 4))
                    Else
                        types.Add(fullName)
                    End If
                End While
            End Using
        Catch ex As Exception
            MessageBox.Show("Error fetching Female perfume types: " & ex.Message)
        End Try

        Return types.ToList()
    End Function

    Private Sub perfumepageFemale_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'HAndles Search Function
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
        .ForeColor = Color.White,
        .BackColor = Color.FromArgb(74, 80, 66),
        .FlatStyle = FlatStyle.Flat,
        .Width = 80,
        .Left = headerPanel.Width - 90,
        .Top = 12,
        .Anchor = AnchorStyles.Top Or AnchorStyles.Right
    }
        headerPanel.Controls.Add(searchBtn)

        ' Dock the FlowLayoutPanel to fill the remaining space
        FlowLayoutPanel1.Dock = DockStyle.Fill

        ' Update control positions on resize
        AddHandler headerPanel.Resize, Sub()
                                           searchBox.Left = headerPanel.Width - 300
                                           searchBtn.Left = headerPanel.Width - 90
                                       End Sub

        ' Load perfumes initially (no filter)
        LoadFemalePerfumes()

        ' search btn handler
        AddHandler searchBtn.Click, Sub(senderBtn, args)
                                        Dim keyword = searchBox.Text.Trim()
                                        LoadFemalePerfumes(keyword)
                                    End Sub
    End Sub
    '' LoadFemalePerfumes method to populate the FlowLayoutPanel
    Private Sub LoadFemalePerfumes(Optional keyword As String = "")
        FlowLayoutPanel1.Controls.Clear()

        ' Get all female perfume types (you can filter here)
        Dim FemalePerfumes = GetFemalePerfumeTypes()

        If keyword <> "" Then
            ' Filter the perfume list by keyword (case insensitive)
            FemalePerfumes = FemalePerfumes.Where(Function(name) name.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0).ToList()
        End If

        If FemalePerfumes.Count = 0 Then
            MessageBox.Show("No female perfumes found matching your search.")
            Return
        End If

        For Each perfumeName In FemalePerfumes
            globals.CreatePerfumePanel(perfumeName, FlowLayoutPanel1, "Female")
        Next
    End Sub

    Private Sub FlowLayoutPanel1_Paint(sender As Object, e As PaintEventArgs) Handles FlowLayoutPanel1.Paint

    End Sub
End Class
