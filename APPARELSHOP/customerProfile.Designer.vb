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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.toRecieveMenuStrip = New System.Windows.Forms.ToolStripMenuItem()
        Me.CompleteOrdersBtnMenu = New System.Windows.Forms.ToolStripMenuItem()
        Me.CANCELLEDToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.deliveryAddress = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.changeAddress = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.contactNumber = New System.Windows.Forms.Label()
        Me.ChangeContactNum = New System.Windows.Forms.Button()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Lavender
        Me.Panel1.Controls.Add(Me.FlowLayoutPanel1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.MenuStrip1)
        Me.Panel1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Panel1.Location = New System.Drawing.Point(536, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(532, 536)
        Me.Panel1.TabIndex = 0
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(16, 73)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(503, 453)
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(12, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ORDERS"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.Lavender
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toRecieveMenuStrip, Me.CompleteOrdersBtnMenu, Me.CANCELLEDToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(16, 33)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(490, 28)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'toRecieveMenuStrip
        '
        Me.toRecieveMenuStrip.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.toRecieveMenuStrip.ForeColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.toRecieveMenuStrip.Name = "toRecieveMenuStrip"
        Me.toRecieveMenuStrip.Size = New System.Drawing.Size(148, 24)
        Me.toRecieveMenuStrip.Text = "TO RECIEVE    "
        '
        'CompleteOrdersBtnMenu
        '
        Me.CompleteOrdersBtnMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.CompleteOrdersBtnMenu.ForeColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.CompleteOrdersBtnMenu.Name = "CompleteOrdersBtnMenu"
        Me.CompleteOrdersBtnMenu.Size = New System.Drawing.Size(188, 24)
        Me.CompleteOrdersBtnMenu.Text = "       COMPLETED     "
        '
        'CANCELLEDToolStripMenuItem
        '
        Me.CANCELLEDToolStripMenuItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.CANCELLEDToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.CANCELLEDToolStripMenuItem.Name = "CANCELLEDToolStripMenuItem"
        Me.CANCELLEDToolStripMenuItem.Size = New System.Drawing.Size(146, 24)
        Me.CANCELLEDToolStripMenuItem.Text = "    CANCELLED"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(12, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(200, 25)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "USER SETTINGS:"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Lavender
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Button1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Button1.Location = New System.Drawing.Point(935, 561)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(133, 46)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "LOG OUT"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'deliveryAddress
        '
        Me.deliveryAddress.AutoSize = True
        Me.deliveryAddress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.deliveryAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.deliveryAddress.ForeColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.deliveryAddress.Location = New System.Drawing.Point(49, 85)
        Me.deliveryAddress.Name = "deliveryAddress"
        Me.deliveryAddress.Size = New System.Drawing.Size(65, 22)
        Me.deliveryAddress.TabIndex = 3
        Me.deliveryAddress.Text = "Label3"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(45, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(286, 20)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "CURRENT DELIVERY ADDRESS:"
        '
        'changeAddress
        '
        Me.changeAddress.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.changeAddress.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.changeAddress.ForeColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.changeAddress.Location = New System.Drawing.Point(49, 117)
        Me.changeAddress.Name = "changeAddress"
        Me.changeAddress.Size = New System.Drawing.Size(83, 29)
        Me.changeAddress.TabIndex = 4
        Me.changeAddress.Text = "Change"
        Me.changeAddress.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(49, 158)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(266, 20)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "CURRENT CONTACT NUMBER:"
        '
        'contactNumber
        '
        Me.contactNumber.AutoSize = True
        Me.contactNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.contactNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.contactNumber.ForeColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.contactNumber.Location = New System.Drawing.Point(53, 190)
        Me.contactNumber.Name = "contactNumber"
        Me.contactNumber.Size = New System.Drawing.Size(65, 22)
        Me.contactNumber.TabIndex = 3
        Me.contactNumber.Text = "Label3"
        '
        'ChangeContactNum
        '
        Me.ChangeContactNum.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ChangeContactNum.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.ChangeContactNum.ForeColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.ChangeContactNum.Location = New System.Drawing.Point(53, 222)
        Me.ChangeContactNum.Name = "ChangeContactNum"
        Me.ChangeContactNum.Size = New System.Drawing.Size(83, 29)
        Me.ChangeContactNum.TabIndex = 4
        Me.ChangeContactNum.Text = "Change"
        Me.ChangeContactNum.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.BackColor = System.Drawing.Color.Lavender
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(12, 286)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(468, 262)
        Me.FlowLayoutPanel2.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(66, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(11, 263)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(144, 20)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "NOTIFICATIONS"
        '
        'customerProfile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SeaShell
        Me.ClientSize = New System.Drawing.Size(1082, 619)
        Me.Controls.Add(Me.FlowLayoutPanel2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ChangeContactNum)
        Me.Controls.Add(Me.changeAddress)
        Me.Controls.Add(Me.contactNumber)
        Me.Controls.Add(Me.deliveryAddress)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "customerProfile"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "customerProfile"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents toRecieveMenuStrip As ToolStripMenuItem
    Friend WithEvents CompleteOrdersBtnMenu As ToolStripMenuItem
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents CANCELLEDToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents deliveryAddress As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents changeAddress As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents contactNumber As Label
    Friend WithEvents ChangeContactNum As Button
    Friend WithEvents FlowLayoutPanel2 As FlowLayoutPanel
    Friend WithEvents Label5 As Label
End Class
