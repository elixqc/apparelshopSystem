<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.streetWearBtn = New System.Windows.Forms.ToolStripMenuItem()
        Me.WATCHESToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MensToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FeminineToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.JEWELRYToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SEASONALSPECIALToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.welcomeName = New System.Windows.Forms.Label()
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip()
        Me.ApparelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PerfumeruToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MasculineToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FeminineToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.TestingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.adminPage = New System.Windows.Forms.ToolStripMenuItem()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'streetWearBtn
        '
        Me.streetWearBtn.Name = "streetWearBtn"
        Me.streetWearBtn.Size = New System.Drawing.Size(103, 21)
        Me.streetWearBtn.Text = "STREETWEAR"
        '
        'WATCHESToolStripMenuItem
        '
        Me.WATCHESToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.MensToolStripMenuItem, Me.FeminineToolStripMenuItem})
        Me.WATCHESToolStripMenuItem.Name = "WATCHESToolStripMenuItem"
        Me.WATCHESToolStripMenuItem.Size = New System.Drawing.Size(78, 21)
        Me.WATCHESToolStripMenuItem.Text = "PERFUME"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(128, 22)
        '
        'MensToolStripMenuItem
        '
        Me.MensToolStripMenuItem.Name = "MensToolStripMenuItem"
        Me.MensToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.MensToolStripMenuItem.Text = "Masculine"
        '
        'FeminineToolStripMenuItem
        '
        Me.FeminineToolStripMenuItem.Name = "FeminineToolStripMenuItem"
        Me.FeminineToolStripMenuItem.Size = New System.Drawing.Size(128, 22)
        Me.FeminineToolStripMenuItem.Text = "Feminine"
        '
        'JEWELRYToolStripMenuItem
        '
        Me.JEWELRYToolStripMenuItem.BackColor = System.Drawing.Color.Transparent
        Me.JEWELRYToolStripMenuItem.Name = "JEWELRYToolStripMenuItem"
        Me.JEWELRYToolStripMenuItem.Size = New System.Drawing.Size(69, 21)
        Me.JEWELRYToolStripMenuItem.Text = "OTHERS"
        '
        'SEASONALSPECIALToolStripMenuItem
        '
        Me.SEASONALSPECIALToolStripMenuItem.Name = "SEASONALSPECIALToolStripMenuItem"
        Me.SEASONALSPECIALToolStripMenuItem.Size = New System.Drawing.Size(141, 21)
        Me.SEASONALSPECIALToolStripMenuItem.Text = "SEASONAL SPECIAL"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), System.Drawing.Image)
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1709, 897)
        Me.Panel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.welcomeName)
        Me.Panel2.Controls.Add(Me.MenuStrip2)
        Me.Panel2.Controls.Add(Me.PictureBox4)
        Me.Panel2.Controls.Add(Me.PictureBox3)
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Controls.Add(Me.MenuStrip1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1709, 51)
        Me.Panel2.TabIndex = 0
        '
        'welcomeName
        '
        Me.welcomeName.AutoSize = True
        Me.welcomeName.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.welcomeName.Location = New System.Drawing.Point(1337, 22)
        Me.welcomeName.Name = "welcomeName"
        Me.welcomeName.Size = New System.Drawing.Size(45, 19)
        Me.welcomeName.TabIndex = 4
        Me.welcomeName.Text = "Label1"
        Me.welcomeName.Visible = False
        '
        'MenuStrip2
        '
        Me.MenuStrip2.AutoSize = False
        Me.MenuStrip2.BackColor = System.Drawing.Color.Transparent
        Me.MenuStrip2.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ApparelToolStripMenuItem, Me.PerfumeruToolStripMenuItem, Me.TestingToolStripMenuItem, Me.adminPage})
        Me.MenuStrip2.Location = New System.Drawing.Point(309, 13)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(514, 28)
        Me.MenuStrip2.TabIndex = 1
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'ApparelToolStripMenuItem
        '
        Me.ApparelToolStripMenuItem.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ApparelToolStripMenuItem.Name = "ApparelToolStripMenuItem"
        Me.ApparelToolStripMenuItem.Size = New System.Drawing.Size(77, 24)
        Me.ApparelToolStripMenuItem.Text = "APPAREL"
        '
        'PerfumeruToolStripMenuItem
        '
        Me.PerfumeruToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MasculineToolStripMenuItem, Me.FeminineToolStripMenuItem1})
        Me.PerfumeruToolStripMenuItem.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PerfumeruToolStripMenuItem.Name = "PerfumeruToolStripMenuItem"
        Me.PerfumeruToolStripMenuItem.Size = New System.Drawing.Size(95, 24)
        Me.PerfumeruToolStripMenuItem.Text = "PERFUMERY"
        '
        'MasculineToolStripMenuItem
        '
        Me.MasculineToolStripMenuItem.Name = "MasculineToolStripMenuItem"
        Me.MasculineToolStripMenuItem.Size = New System.Drawing.Size(131, 24)
        Me.MasculineToolStripMenuItem.Text = "Masculine"
        '
        'FeminineToolStripMenuItem1
        '
        Me.FeminineToolStripMenuItem1.Name = "FeminineToolStripMenuItem1"
        Me.FeminineToolStripMenuItem1.Size = New System.Drawing.Size(131, 24)
        Me.FeminineToolStripMenuItem1.Text = "Feminine"
        '
        'TestingToolStripMenuItem
        '
        Me.TestingToolStripMenuItem.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TestingToolStripMenuItem.Name = "TestingToolStripMenuItem"
        Me.TestingToolStripMenuItem.Size = New System.Drawing.Size(56, 24)
        Me.TestingToolStripMenuItem.Text = "testing"
        '
        'adminPage
        '
        Me.adminPage.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.adminPage.Name = "adminPage"
        Me.adminPage.Size = New System.Drawing.Size(98, 24)
        Me.adminPage.Text = "ADMIN PAGE"
        '
        'PictureBox4
        '
        Me.PictureBox4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(1539, 14)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(27, 27)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 3
        Me.PictureBox4.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PictureBox3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(1493, 15)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(25, 25)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 3
        Me.PictureBox3.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(13, 13)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(250, 25)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AutoSize = False
        Me.MenuStrip1.BackColor = System.Drawing.Color.Transparent
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Location = New System.Drawing.Point(309, 15)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(748, 26)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1726, 687)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents welcomeName As Label
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents streetWearBtn As ToolStripMenuItem
    Friend WithEvents WATCHESToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents JEWELRYToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SEASONALSPECIALToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents MensToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FeminineToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MenuStrip2 As MenuStrip
    Friend WithEvents ApparelToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PerfumeruToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents MasculineToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FeminineToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents TestingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents adminPage As ToolStripMenuItem
End Class
