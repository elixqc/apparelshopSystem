Public Class perfumepageFemale

    Private Sub perfumepageFemale_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadFemalePerfumes()
    End Sub

    Private Sub LoadFemalePerfumes()
        FlowLayoutPanel1.Controls.Clear()

        ' Load perfumes from supplier 4 and 5 (female perfumes)
        Dim femalePerfumes = globals.GetPerfumeTypesBySupplier(4).Union(globals.GetPerfumeTypesBySupplier(5)).ToList()

        For Each perfumeName In femalePerfumes
            globals.CreatePerfumePanel(perfumeName, FlowLayoutPanel1)
        Next
    End Sub


End Class
