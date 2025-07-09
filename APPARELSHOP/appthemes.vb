Imports System.Threading.Tasks
Imports System.Runtime.InteropServices
Public Class appthemes

    Private Const AW_HIDE As Integer = &H10000
    Private Const AW_BLEND As Integer = &H80000
    Private Const AW_ACTIVATE As Integer = &H20000

    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function AnimateWindow(hwnd As IntPtr, dwTime As Integer, dwFlags As Integer) As Boolean
    End Function

    ' Fade-out animation
    Public Shared Sub FadeOutForm(form As Form, Optional duration As Integer = 150)
        AnimateWindow(form.Handle, duration, AW_HIDE Or AW_BLEND)
        form.Close()
    End Sub

    ' Fade-in animation (for completeness)
    Public Shared Sub FastFadeIn(form As Form, Optional steps As Integer = 10)
        form.Opacity = 0
        form.Show()

        ' Immediate jump to 30% opacity
        form.Opacity = 0.3

        ' Then animate the remaining 70% quickly
        For i As Integer = 1 To steps
            form.Opacity += 0.07
            Application.DoEvents()
            Threading.Thread.Sleep(10) ' Very short delay
        Next
    End Sub

    Public Shared Sub SmoothFadeIn(form As Form, Optional interval As Integer = 10, Optional increment As Double = 0.05)
        form.Opacity = 0
        form.Show()

        Dim fadeTimer As New Timer()
        fadeTimer.Interval = interval

        AddHandler fadeTimer.Tick,
        Sub(sender As Object, e As EventArgs)
            If form.Opacity < 1 Then
                form.Opacity += increment
            Else
                form.Opacity = 1
                fadeTimer.Stop()
                fadeTimer.Dispose()
            End If
        End Sub

        fadeTimer.Start()
    End Sub




    '===== CUSTOM MENU RENDERER =====
    Public Class CustomMenuRenderer
        Inherits ToolStripProfessionalRenderer

        Protected Overrides Sub OnRenderMenuItemBackground(e As ToolStripItemRenderEventArgs)
            If e.Item.Selected Then
                ' Remove default selection highlight
            Else
                MyBase.OnRenderMenuItemBackground(e)
            End If
        End Sub

        Protected Overrides Sub OnRenderItemText(e As ToolStripItemTextRenderEventArgs)
            e.TextColor = If(e.Item.Selected, Color.Green, Color.Black)
            MyBase.OnRenderItemText(e)
        End Sub
    End Class

    ' Shared instance (reusable across forms)
    Public Shared ReadOnly MenuRenderer As New CustomMenuRenderer()


    '===== LABEL HOVER EFFECTS =====
    Public Shared Sub ApplyLabelHover(label As Label)
        AddHandler label.MouseEnter, AddressOf Label_MouseEnter
        AddHandler label.MouseLeave, AddressOf Label_MouseLeave
    End Sub

    Private Shared Sub Label_MouseEnter(sender As Object, e As EventArgs)
        DirectCast(sender, Label).ForeColor = Color.FromArgb(66, 80, 51) ' Your green
    End Sub

    Private Shared Sub Label_MouseLeave(sender As Object, e As EventArgs)
        DirectCast(sender, Label).ForeColor = Color.Black
    End Sub



    '===== BUTTON HOVER EFFECTS =====
    Public Shared Sub ApplyTransparentButtonHover(button As Button, hoverTextColor As Color)

        ' Store the original ForeColor only (since we won’t touch BackColor)
        Dim originalForeColor As Color = button.ForeColor

        ' Handle hover
        AddHandler button.MouseEnter, Sub(sender, e)
                                          Dim btn = DirectCast(sender, Button)
                                          btn.ForeColor = hoverTextColor
                                      End Sub

        ' Handle mouse leave
        AddHandler button.MouseLeave, Sub(sender, e)
                                          Dim btn = DirectCast(sender, Button)
                                          btn.ForeColor = originalForeColor
                                      End Sub
    End Sub



End Class
