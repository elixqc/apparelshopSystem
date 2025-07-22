<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class customerProfile
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.TOSHIPToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TORECIEVEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.Transparent
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TOSHIPToolStripMenuItem, Me.TORECIEVEToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(914, 34)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(189, 29)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'TOSHIPToolStripMenuItem
        '
        Me.TOSHIPToolStripMenuItem.Font = New System.Drawing.Font("Microsoft Himalaya", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TOSHIPToolStripMenuItem.Name = "TOSHIPToolStripMenuItem"
        Me.TOSHIPToolStripMenuItem.Size = New System.Drawing.Size(76, 25)
        Me.TOSHIPToolStripMenuItem.Text = "TO SHIP"
        '
        'TORECIEVEToolStripMenuItem
        '
        Me.TORECIEVEToolStripMenuItem.BackColor = System.Drawing.Color.Transparent
        Me.TORECIEVEToolStripMenuItem.Font = New System.Drawing.Font("Microsoft Himalaya", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TORECIEVEToolStripMenuItem.Name = "TORECIEVEToolStripMenuItem"
        Me.TORECIEVEToolStripMenuItem.Size = New System.Drawing.Size(105, 25)
        Me.TORECIEVEToolStripMenuItem.Text = "TO RECIEVE"
        '
        'customerProfile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1102, 560)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "customerProfile"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "customerProfile"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents TOSHIPToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TORECIEVEToolStripMenuItem As ToolStripMenuItem
End Class
