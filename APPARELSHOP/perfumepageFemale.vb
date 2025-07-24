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
        LoadFemalePerfumes()
    End Sub
    '' LoadFemalePerfumes method to populate the FlowLayoutPanel
    Private Sub LoadFemalePerfumes()
        FlowLayoutPanel1.Controls.Clear()

        Dim FemalePerfumes = GetFemalePerfumeTypes()

        If FemalePerfumes.Count = 0 Then
            MessageBox.Show("No female perfumes found. Check DB for gender='Female' and category_id in (7–12).")
        End If

        For Each perfumeName In FemalePerfumes

            globals.CreatePerfumePanel(perfumeName, FlowLayoutPanel1, "Female")
        Next
    End Sub

End Class
