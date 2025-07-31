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


    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click

        If loggedInUserID <> 0 Then
            If customerProfile.Visible Then
                customerProfile.BringToFront()
                Exit Sub
            End If
            appthemes.SmoothFadeIn(customerProfile)
        Else
            If login.Visible Then
                login.BringToFront()
                Exit Sub
            End If
            appthemes.SmoothFadeIn(login)
        End If

    End Sub


    Private Sub MENewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles streetWearBtn.Click
        appthemes.SmoothFadeIn(apparelPage)
    End Sub


    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click

        If loggedInUserID = 0 Then
            MsgBox("Please Login First")
        Else
            If newCart.Visible Then
                newCart.BringToFront()
                Exit Sub
            End If
            appthemes.SmoothFadeIn(newCart)
        End If


    End Sub


    Private Sub MensToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MensToolStripMenuItem.Click
        appthemes.SmoothFadeIn(perfumePage)
    End Sub

    Private Sub ApparelToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ApparelToolStripMenuItem.Click
        If apparelPageSample.Visible Then
            apparelPageSample.BringToFront()
            Exit Sub
        End If
        appthemes.SmoothFadeIn(apparelPageSample)


    End Sub

    Private Sub MasculineToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MasculineToolStripMenuItem.Click

        If perfumepageMale.Visible Then
            perfumepageMale.BringToFront()
            Exit Sub
        End If
        appthemes.SmoothFadeIn(perfumepageMale)
    End Sub

    Private Sub FeminineToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles FeminineToolStripMenuItem1.Click
        If apparelPageSample.Visible Then
            apparelPageSample.BringToFront()
        End If
        appthemes.SmoothFadeIn(perfumepageFemale)
    End Sub
    Private Sub TestingToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TestingToolStripMenuItem.Click
        If aboutus.Visible Then
            aboutus.BringToFront()
        End If
        appthemes.SmoothFadeIn(aboutus)
    End Sub

    Private Sub adminPage_Click(sender As Object, e As EventArgs) Handles adminPage.Click

        If AdminFormPage.Visible Then
            AdminFormPage.BringToFront()
        Else
            appthemes.SmoothFadeIn(AdminFormPage)
        End If

    End Sub

End Class
