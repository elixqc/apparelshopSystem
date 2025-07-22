Public Class perfumepageMale

    Private Sub perfumepageMale_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadMalePerfumes()
    End Sub

    Private Sub LoadMalePerfumes()
        FlowLayoutPanel1.Controls.Clear()

        ' Load perfumes from supplier 6 (male perfumes)
        Dim malePerfumes = globals.GetMalePerfumeTypes()

        For Each perfumeName In malePerfumes
            globals.CreatePerfumePanel(perfumeName, FlowLayoutPanel1)
        Next
    End Sub

End Class
