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
        Me.Panel1.Location = New System.Drawing.Point(614, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(476, 536)
        Me.Panel1.TabIndex = 0
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.AutoScroll = True
        Me.FlowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(11, 73)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(455, 453)
        Me.FlowLayoutPanel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Himalaya", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 21)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ORDERS"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.Transparent
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Font = New System.Drawing.Font("Microsoft Himalaya", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toRecieveMenuStrip, Me.CompleteOrdersBtnMenu, Me.CANCELLEDToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(7, 41)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(459, 29)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'toRecieveMenuStrip
        '
        Me.toRecieveMenuStrip.Name = "toRecieveMenuStrip"
        Me.toRecieveMenuStrip.Size = New System.Drawing.Size(121, 25)
        Me.toRecieveMenuStrip.Text = "TO RECIEVE    "
        '
        'CompleteOrdersBtnMenu
        '
        Me.CompleteOrdersBtnMenu.Name = "CompleteOrdersBtnMenu"
        Me.CompleteOrdersBtnMenu.Size = New System.Drawing.Size(196, 25)
        Me.CompleteOrdersBtnMenu.Text = "            COMPLETED          "
        '
        'CANCELLEDToolStripMenuItem
        '
        Me.CANCELLEDToolStripMenuItem.Name = "CANCELLEDToolStripMenuItem"
        Me.CANCELLEDToolStripMenuItem.Size = New System.Drawing.Size(134, 25)
        Me.CANCELLEDToolStripMenuItem.Text = "       CANCELLED"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Himalaya", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(136, 21)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "USER SETTINGS:"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Lavender
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Font = New System.Drawing.Font("Microsoft Himalaya", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(16, 502)
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
        Me.deliveryAddress.Font = New System.Drawing.Font("Microsoft Himalaya", 18.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.deliveryAddress.Location = New System.Drawing.Point(16, 72)
        Me.deliveryAddress.Name = "deliveryAddress"
        Me.deliveryAddress.Size = New System.Drawing.Size(56, 26)
        Me.deliveryAddress.TabIndex = 3
        Me.deliveryAddress.Text = "Label3"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Himalaya", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(247, 21)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "CURRENT DELIVERY ADDRESS:"
        '
        'changeAddress
        '
        Me.changeAddress.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.changeAddress.Font = New System.Drawing.Font("Microsoft Himalaya", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.changeAddress.Location = New System.Drawing.Point(16, 103)
        Me.changeAddress.Name = "changeAddress"
        Me.changeAddress.Size = New System.Drawing.Size(81, 28)
        Me.changeAddress.TabIndex = 4
        Me.changeAddress.Text = "Change"
        Me.changeAddress.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Himalaya", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 134)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(236, 21)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "CURRENT CONTACT NUMBER:"
        '
        'contactNumber
        '
        Me.contactNumber.AutoSize = True
        Me.contactNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.contactNumber.Font = New System.Drawing.Font("Microsoft Himalaya", 18.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.contactNumber.Location = New System.Drawing.Point(16, 154)
        Me.contactNumber.Name = "contactNumber"
        Me.contactNumber.Size = New System.Drawing.Size(56, 26)
        Me.contactNumber.TabIndex = 3
        Me.contactNumber.Text = "Label3"
        '
        'ChangeContactNum
        '
        Me.ChangeContactNum.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ChangeContactNum.Font = New System.Drawing.Font("Microsoft Himalaya", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChangeContactNum.Location = New System.Drawing.Point(16, 185)
        Me.ChangeContactNum.Name = "ChangeContactNum"
        Me.ChangeContactNum.Size = New System.Drawing.Size(81, 28)
        Me.ChangeContactNum.TabIndex = 4
        Me.ChangeContactNum.Text = "Change"
        Me.ChangeContactNum.UseVisualStyleBackColor = True
        '
        'customerProfile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SeaShell
        Me.ClientSize = New System.Drawing.Size(1102, 560)
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
End Class
