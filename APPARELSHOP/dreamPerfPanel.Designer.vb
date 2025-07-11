<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddtoCartPanel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddtoCartPanel))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Button23 = New System.Windows.Forms.Button()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.perfumePic = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.perfumePic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label2.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(342, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(282, 380)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = resources.GetString("Label2.Text")
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Himalaya", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.ForeColor = System.Drawing.Color.Gray
        Me.TextBox2.Location = New System.Drawing.Point(556, 444)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(100, 23)
        Me.TextBox2.TabIndex = 8
        Me.TextBox2.Text = "Quantity"
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Button23
        '
        Me.Button23.BackColor = System.Drawing.SystemColors.ControlText
        Me.Button23.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button23.FlatAppearance.BorderSize = 0
        Me.Button23.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button23.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button23.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Button23.Location = New System.Drawing.Point(556, 473)
        Me.Button23.Name = "Button23"
        Me.Button23.Size = New System.Drawing.Size(99, 40)
        Me.Button23.TabIndex = 7
        Me.Button23.Text = "ADD TO CART"
        Me.Button23.UseVisualStyleBackColor = False
        '
        'PictureBox5
        '
        Me.PictureBox5.Image = Global.APPARELSHOP.My.Resources.Resources.xbuttfinal
        Me.PictureBox5.Location = New System.Drawing.Point(632, 5)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(26, 24)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox5.TabIndex = 9
        Me.PictureBox5.TabStop = False
        '
        'perfumePic
        '
        Me.perfumePic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.perfumePic.Image = Global.APPARELSHOP.My.Resources.Resources.dreamFinal
        Me.perfumePic.Location = New System.Drawing.Point(3, 47)
        Me.perfumePic.Name = "perfumePic"
        Me.perfumePic.Size = New System.Drawing.Size(333, 399)
        Me.perfumePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.perfumePic.TabIndex = 1
        Me.perfumePic.TabStop = False
        '
        'AddtoCartPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(664, 524)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Button23)
        Me.Controls.Add(Me.perfumePic)
        Me.Controls.Add(Me.Label2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "AddtoCartPanel"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "dreamPerfPanel"
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.perfumePic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents perfumePic As PictureBox
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Button23 As Button
End Class
