Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Drawing

Public Class perfumepageMale
    'get male perfume types from the database
    Public Function GetMalePerfumeTypes() As List(Of String)
        Dim types As New HashSet(Of String)

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim cmd As New MySqlCommand("
                    SELECT DISTINCT product_name 
                    FROM products 
                    WHERE gender = 'Male' 
                      AND category_id IN (7, 8, 9, 10, 11, 12)", conn)

                Dim reader As MySqlDataReader = cmd.ExecuteReader()

                While reader.Read()
                    Dim fullName As String = reader("product_name").ToString()

                    If fullName.EndsWith(" EDT") OrElse fullName.EndsWith(" EDP") Then
                        types.Add(fullName.Substring(0, fullName.Length - 4))
                    Else
                        types.Add(fullName)
                    End If
                End While
            End Using
        Catch ex As Exception
            MessageBox.Show("Error fetching male perfume types: " & ex.Message)
        End Try

        Return types.ToList()
    End Function

    Private Sub perfumepageMale_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        LoadMalePerfumes()

        ' Add click handler for search button
        AddHandler searchBtn.Click, Sub(senderBtn, args)
                                        Dim keyword = searchBox.Text.Trim()
                                        LoadMalePerfumes(keyword)
                                    End Sub
    End Sub

    Private Sub LoadMalePerfumes(Optional keyword As String = "")
        FlowLayoutPanel1.Controls.Clear()

        Dim malePerfumes = globals.GetMalePerfumeTypes()

        If keyword <> "" Then
            ' Filter by keyword (case insensitive)
            malePerfumes = malePerfumes.Where(Function(name) name.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0).ToList()
        End If

        If malePerfumes.Count = 0 Then
            MessageBox.Show("No male perfumes found matching your search.")
            Return
        End If

        For Each perfumeName In malePerfumes
            globals.CreatePerfumePanel(perfumeName, FlowLayoutPanel1, "Male")
        Next
    End Sub


End Class
