Imports System.Drawing
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient



Public Class Form1

    Dim conn As New MySqlConnection("server=localhost;userid=root;password=;database=apparelshopdb")


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        MenuStrip1.Renderer = appthemes.MenuRenderer
        MenuStrip2.Renderer = appthemes.MenuRenderer

        GetType(Panel).InvokeMember("DoubleBuffered",
        Reflection.BindingFlags.SetProperty Or Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic,
        Nothing,
        Panel1,
        New Object() {True})




    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint


    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click

        If loggedInUserID <> 0 Then
            Dim result As DialogResult = MessageBox.Show("You are already logged in as " & loggedInUserFullName & ". Do you want to log out?", "Logout Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result = DialogResult.Yes Then
                ' Reset login session variables
                loggedInUserID = 0
                loggedInUserEmail = ""
                loggedInUserFullName = ""

                ' Optional: Hide welcome label
                welcomeName.Visible = False

                MsgBox("You have been logged out.")
            End If
        Else
            appthemes.SmoothFadeIn(login)
        End If

    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub JEWELRYToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles JEWELRYToolStripMenuItem.Click

    End Sub

    Private Sub MENewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles streetWearBtn.Click
        appthemes.SmoothFadeIn(apparelPage)
    End Sub


    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click

        If loggedInUserID = 0 Then
            MsgBox("Please Login First")
        Else
            appthemes.SmoothFadeIn(newCart)
        End If


    End Sub

    Private Sub WATCHESToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WATCHESToolStripMenuItem.Click

    End Sub

    Private Sub MensToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MensToolStripMenuItem.Click
        appthemes.SmoothFadeIn(perfumePage)
    End Sub

    Private Sub ApparelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApparelToolStripMenuItem.Click
        If apparelPageSample.Visible Then
            apparelPageSample.Close()
        End If
        appthemes.SmoothFadeIn(apparelPageSample)


    End Sub

    Private Sub MasculineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MasculineToolStripMenuItem.Click


    End Sub

    Private Sub FeminineToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FeminineToolStripMenuItem1.Click


    End Sub

    Private Sub TestingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TestingToolStripMenuItem.Click
        appthemes.SmoothFadeIn(apparelPageSample)
    End Sub
End Class
