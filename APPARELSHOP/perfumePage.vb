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

        appthemes.SmoothFadeIn(AddtoCartPanel)
        AddtoCartPanel.perfumePic.Image = My.Resources.dreamFinal


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
        AddtoCartPanel.fragInfo.Text = "L'infinity by Prestige
A fragrance that reflects timeless elegance and boundless depth.

L’infinity is an ode to the eternal. It evokes the warmth of golden hours and the sophistication of quiet confidence. Designed for those who embody poise and grace, this scent unfolds like a story that never ends — smooth, rich, and endlessly captivating.

Key Notes
White Amber
Sandalwood from India
French Vanilla Orchid
Golden Musk
Myrrh Resin
Cashmere Woods
Dried Fig"
        appthemes.SmoothFadeIn(AddtoCartPanel)

    End Sub

    Private Sub PictureBox5_Click_1(sender As Object, e As EventArgs) Handles PictureBox5.Click

        If AddtoCartPanel.Visible Then
            AddtoCartPanel.Close()
        End If

        AddtoCartPanel.perfumePic.Image = My.Resources.originFinal
        AddtoCartPanel.fragInfo.Text = "Origin by Prestige
A fragrance rooted in strength, mystery, and primal elegance.

Origin awakens the core of your being — deep, earthy, and powerful. It's made for individuals who command respect effortlessly and carry the wisdom of experience. This bold composition reveals the raw beauty of nature and the essence of authenticity.

Key Notes
Smoked Leather
Indonesian Patchouli
Roasted Coffee Bean
Oak Moss
Balsam Fir
Haitian Vetiver
Dark Cocoa"

        appthemes.SmoothFadeIn(AddtoCartPanel)
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click

        If AddtoCartPanel.Visible Then
            AddtoCartPanel.Close()
        End If

        AddtoCartPanel.perfumePic.Image = My.Resources.Aura

        AddtoCartPanel.fragInfo.Text = "Pacific Aura by Prestige
A fragrance that captures the calm and energy of coastal winds.

Pacific Aura is like an ocean breeze meeting a tropical sunrise — fresh, aquatic, and invigorating. Ideal for free spirits, adventurers, and lovers of the sea, this scent blends marine freshness with citrus brightness for a truly refreshing experience.

Key Notes
Sea Salt Accord
Japanese Yuzu
Coconut Water
Blue Eucalyptus
Driftwood
White Jasmine
Lime Zest

"

        appthemes.SmoothFadeIn(AddtoCartPanel)
    End Sub
End Class