<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class newCart
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.CartPanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.CartPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'CartPanel
        '
        Me.CartPanel.AutoScroll = True
        Me.CartPanel.Controls.Add(Me.Button1)
        Me.CartPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CartPanel.Location = New System.Drawing.Point(0, 0)
        Me.CartPanel.Name = "CartPanel"
        Me.CartPanel.Size = New System.Drawing.Size(487, 598)
        Me.CartPanel.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(3, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "testing"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'newCart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(487, 598)
        Me.Controls.Add(Me.CartPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "newCart"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "newCart"
        Me.CartPanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CartPanel As FlowLayoutPanel
    Friend WithEvents Button1 As Button
End Class
