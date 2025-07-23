Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Drawing

Public Class perfumepageMale

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
        LoadMalePerfumes()
    End Sub

    Private Sub LoadMalePerfumes()
        FlowLayoutPanel1.Controls.Clear()

        Dim malePerfumes = globals.GetMalePerfumeTypes()


        For Each perfumeName In malePerfumes
            globals.CreatePerfumePanel(perfumeName, FlowLayoutPanel1, "Male")
        Next
    End Sub

End Class
