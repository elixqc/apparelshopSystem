Public Class perfumePage
    Private Sub perfumePage_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label16_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub Label19_Click(sender As Object, e As EventArgs) Handles Label19.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs)

    End Sub


    Private Sub Label17_Click(sender As Object, e As EventArgs) Handles Label17.Click

    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles DreamPic.Click

        If AddtoCartPanel.Visible Then
            AddtoCartPanel.Close()
        End If

        AddtoCartPanel.perfumePic.Image = My.Resources.dreamFinal
        appthemes.SmoothFadeIn(AddtoCartPanel)
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        appthemes.FadeOutForm(Me)
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

    End Sub

    Private Sub PictureBox3_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox2_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox4_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs)

    End Sub

    Private Sub Label19_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label17_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles infinityPic.Click

        If AddtoCartPanel.Visible Then
            AddtoCartPanel.Close()
        End If

        AddtoCartPanel.perfumePic.Image = My.Resources.Linfinity
        appthemes.SmoothFadeIn(AddtoCartPanel)
    End Sub

    Private Sub PictureBox5_Click_1(sender As Object, e As EventArgs) Handles PictureBox5.Click

        If AddtoCartPanel.Visible Then
            AddtoCartPanel.Close()
        End If

        AddtoCartPanel.perfumePic.Image = My.Resources.originFinal
        appthemes.SmoothFadeIn(AddtoCartPanel)
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click

        If AddtoCartPanel.Visible Then
            AddtoCartPanel.Close()
        End If

        AddtoCartPanel.perfumePic.Image = My.Resources.Aura
        appthemes.SmoothFadeIn(AddtoCartPanel)
    End Sub
End Class