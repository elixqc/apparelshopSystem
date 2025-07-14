Public Class PerfumePageFem
    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles AfternoonvibePic.Click

        If AddtoCartPanel.Visible Then
            AddtoCartPanel.Close()
        End If


        AddtoCartPanel.perfumePic.Image = My.Resources.AfternoonVibe
        AddtoCartPanel.fragInfo.Text = "Afternoon Vibe by Prestige
A breezy and playful fragrance perfect for carefree afternoons.

Afternoon Vibe is crisp, clean, and effortlessly chic. It feels like sunlight through linen curtains, paired with laughter and lazy moments. This is the go-to scent for women who want to feel refreshed, calm, and stylish from brunch to twilight.

Key Notes
Blue Freesia
Water Lily
Green Apple
Cotton Musk
Ocean Breeze Accord
Aloe Vera
Soft Amber"

        appthemes.SmoothFadeIn(AddtoCartPanel)

    End Sub

    Private Sub infinityPic_Click(sender As Object, e As EventArgs) Handles SunsetPic.Click

        If AddtoCartPanel.Visible Then
            AddtoCartPanel.Close()
        End If


        AddtoCartPanel.perfumePic.Image = My.Resources.Sunset
        AddtoCartPanel.fragInfo.Text = "Sun Set by Prestige
A golden fragrance that radiates warmth, optimism, and bold femininity.

Sun Set captures the magic of golden hour — radiant, glowing, and full of energy. With a citrusy floral bouquet and a creamy dry-down, it’s made for vibrant women who embrace their inner light and chase sunsets with confidence.

Key Notes
Blood Orange
Mango Sorbet
Frangipani Blossom
Solar Amber
Coconut Cream
Honeyed Musk
Pink Grapefruit

"
        appthemes.SmoothFadeIn(AddtoCartPanel)

    End Sub

    Private Sub DreamPic_Click(sender As Object, e As EventArgs) Handles LovespellPic.Click

        If AddtoCartPanel.Visible Then
            AddtoCartPanel.Close()
        End If


        AddtoCartPanel.perfumePic.Image = My.Resources.Lovespell
        AddtoCartPanel.fragInfo.Text = "Love Spell by Prestige
A romantic fragrance woven with charm and delicate allure.

Love Spell evokes the flutter of first love and the warmth of gentle affection. Sweet, floral, and irresistibly feminine, this fragrance enchants the senses like a whispered promise. It’s perfect for those who live with an open heart and dream in pink hues.

Key Notes
Japanese Cherry Blossom
Wild Peony
Soft Vanilla
Red Apple
White Musk
Jasmine Petals
Raspberry Nectar
"
        appthemes.SmoothFadeIn(AddtoCartPanel)


    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles coeurPic.Click

        If AddtoCartPanel.Visible Then
            AddtoCartPanel.Close()
        End If


        AddtoCartPanel.perfumePic.Image = My.Resources.CoeurDeRose
        AddtoCartPanel.fragInfo.Text = "Coeur De Rose by Prestige
A timeless floral signature of grace and inner strength.

Coeur De Rose (Heart of Rose) is a celebration of classic femininity — elegant, soft, and deeply captivating. Inspired by the enduring beauty of roses, this fragrance is for those who walk with grace and leave a lasting impression of sophistication.

Key Notes
Bulgarian Rose
Pear Blossom
Rose de Mai
White Tea
Cashmere Woods
Iris
Vanilla Bean"

        appthemes.SmoothFadeIn(AddtoCartPanel)


    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs)
        appthemes.FadeOutForm(Me)
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs)
        appthemes.FadeOutForm(Me)
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs)
        appthemes.FadeOutForm(Me)
    End Sub

    Private Sub PictureBox1_Click_1(sender As Object, e As EventArgs) Handles PictureBox1.Click
        appthemes.FadeOutForm(Me)
    End Sub
End Class