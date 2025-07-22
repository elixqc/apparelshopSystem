<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class apparelPageSample
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
        Me.Flowproductpanel = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnLoadProducts = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Flowproductpanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'Flowproductpanel
        '
        Me.Flowproductpanel.AutoScroll = True
        Me.Flowproductpanel.Controls.Add(Me.btnLoadProducts)
        Me.Flowproductpanel.Controls.Add(Me.Button1)
        Me.Flowproductpanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Flowproductpanel.Location = New System.Drawing.Point(0, 0)
        Me.Flowproductpanel.Name = "Flowproductpanel"
        Me.Flowproductpanel.Size = New System.Drawing.Size(1400, 641)
        Me.Flowproductpanel.TabIndex = 0
        '
        'btnLoadProducts
        '
        Me.btnLoadProducts.Location = New System.Drawing.Point(3, 3)
        Me.btnLoadProducts.Name = "btnLoadProducts"
        Me.btnLoadProducts.Size = New System.Drawing.Size(75, 23)
        Me.btnLoadProducts.TabIndex = 0
        Me.btnLoadProducts.Text = "test"
        Me.btnLoadProducts.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(84, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'apparelPageSample
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1400, 641)
        Me.Controls.Add(Me.Flowproductpanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "apparelPageSample"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "APPARELS"
        Me.Flowproductpanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Flowproductpanel As FlowLayoutPanel
    Friend WithEvents btnLoadProducts As Button
    Friend WithEvents Button1 As Button
End Class
