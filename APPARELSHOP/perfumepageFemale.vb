Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Drawing
Public Class perfumepageFemale

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

    Private Sub LoadFemalePerfumes()
        FlowLayoutPanel1.Controls.Clear()

        ' Load perfumes from supplier 4 and 5 (female perfumes)
        Dim FemalePerfumes = GetFemalePerfumeTypes()

        For Each perfumeName In FemalePerfumes
            globals.CreatePerfumePanel(perfumeName, FlowLayoutPanel1)
        Next
    End Sub


End Class
