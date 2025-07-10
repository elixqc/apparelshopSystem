<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class apparelPage
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(apparelPage))
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Button19 = New System.Windows.Forms.Button()
        Me.Button20 = New System.Windows.Forms.Button()
        Me.Button21 = New System.Windows.Forms.Button()
        Me.Button22 = New System.Windows.Forms.Button()
        Me.Button23 = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.sweatpantQty = New System.Windows.Forms.TextBox()
        Me.sweatpantSize = New System.Windows.Forms.ComboBox()
        Me.Button15 = New System.Windows.Forms.Button()
        Me.Button16 = New System.Windows.Forms.Button()
        Me.Button17 = New System.Windows.Forms.Button()
        Me.sweatpantAddToCart = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.hoodieQty = New System.Windows.Forms.TextBox()
        Me.hoodieSize = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.hoodieAddToCart = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.shirtQty = New System.Windows.Forms.TextBox()
        Me.shirtSize = New System.Windows.Forms.ComboBox()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.tshirtAddtocart = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.sweatshirtPanel = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.sweatshirtQty = New System.Windows.Forms.TextBox()
        Me.sweatshirtSize = New System.Windows.Forms.ComboBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.sweatshirtAddToCart = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.sweatshirtStockTxt = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.sweatpantsPic = New System.Windows.Forms.PictureBox()
        Me.hoodiePic = New System.Windows.Forms.PictureBox()
        Me.tshirtPic = New System.Windows.Forms.PictureBox()
        Me.sweatshirtPic = New System.Windows.Forms.PictureBox()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.sweatshirtPanel.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sweatpantsPic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.hoodiePic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tshirtPic, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sweatshirtPic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel4
        '
        Me.Panel4.AutoScroll = True
        Me.Panel4.Controls.Add(Me.Panel5)
        Me.Panel4.Controls.Add(Me.Panel3)
        Me.Panel4.Controls.Add(Me.Panel2)
        Me.Panel4.Controls.Add(Me.Panel1)
        Me.Panel4.Controls.Add(Me.sweatshirtPanel)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1416, 680)
        Me.Panel4.TabIndex = 6
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.SystemColors.HighlightText
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel5.Controls.Add(Me.Label16)
        Me.Panel5.Controls.Add(Me.TextBox2)
        Me.Panel5.Controls.Add(Me.ComboBox2)
        Me.Panel5.Controls.Add(Me.Button19)
        Me.Panel5.Controls.Add(Me.Button20)
        Me.Panel5.Controls.Add(Me.Button21)
        Me.Panel5.Controls.Add(Me.Button22)
        Me.Panel5.Controls.Add(Me.Button23)
        Me.Panel5.Controls.Add(Me.Label17)
        Me.Panel5.Controls.Add(Me.Label18)
        Me.Panel5.Controls.Add(Me.Label19)
        Me.Panel5.Controls.Add(Me.PictureBox4)
        Me.Panel5.Location = New System.Drawing.Point(29, 600)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(319, 479)
        Me.Panel5.TabIndex = 10
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Himalaya", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(277, 367)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(27, 16)
        Me.Label16.TabIndex = 6
        Me.Label16.Text = "Size"
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Himalaya", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.ForeColor = System.Drawing.Color.Gray
        Me.TextBox2.Location = New System.Drawing.Point(202, 389)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(100, 23)
        Me.TextBox2.TabIndex = 5
        Me.TextBox2.Text = "Quantity"
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ComboBox2
        '
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBox2.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"S", "M", "L", "XL"})
        Me.ComboBox2.Location = New System.Drawing.Point(180, 337)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(121, 27)
        Me.ComboBox2.TabIndex = 4
        '
        'Button19
        '
        Me.Button19.BackColor = System.Drawing.Color.Yellow
        Me.Button19.FlatAppearance.BorderSize = 2
        Me.Button19.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button19.Location = New System.Drawing.Point(102, 338)
        Me.Button19.Name = "Button19"
        Me.Button19.Size = New System.Drawing.Size(20, 20)
        Me.Button19.TabIndex = 3
        Me.Button19.UseVisualStyleBackColor = False
        '
        'Button20
        '
        Me.Button20.BackColor = System.Drawing.Color.Pink
        Me.Button20.FlatAppearance.BorderSize = 2
        Me.Button20.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button20.Location = New System.Drawing.Point(76, 338)
        Me.Button20.Name = "Button20"
        Me.Button20.Size = New System.Drawing.Size(20, 20)
        Me.Button20.TabIndex = 3
        Me.Button20.UseVisualStyleBackColor = False
        '
        'Button21
        '
        Me.Button21.BackColor = System.Drawing.Color.Blue
        Me.Button21.FlatAppearance.BorderSize = 2
        Me.Button21.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button21.Location = New System.Drawing.Point(50, 338)
        Me.Button21.Name = "Button21"
        Me.Button21.Size = New System.Drawing.Size(20, 20)
        Me.Button21.TabIndex = 3
        Me.Button21.UseVisualStyleBackColor = False
        '
        'Button22
        '
        Me.Button22.BackColor = System.Drawing.Color.Red
        Me.Button22.FlatAppearance.BorderSize = 2
        Me.Button22.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button22.Location = New System.Drawing.Point(24, 338)
        Me.Button22.Name = "Button22"
        Me.Button22.Size = New System.Drawing.Size(20, 20)
        Me.Button22.TabIndex = 3
        Me.Button22.UseVisualStyleBackColor = False
        '
        'Button23
        '
        Me.Button23.BackColor = System.Drawing.SystemColors.ControlText
        Me.Button23.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button23.FlatAppearance.BorderSize = 0
        Me.Button23.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button23.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button23.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Button23.Location = New System.Drawing.Point(202, 418)
        Me.Button23.Name = "Button23"
        Me.Button23.Size = New System.Drawing.Size(99, 40)
        Me.Button23.TabIndex = 2
        Me.Button23.Text = "ADD TO CART"
        Me.Button23.UseVisualStyleBackColor = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Himalaya", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(11, 397)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(147, 21)
        Me.Label17.TabIndex = 1
        Me.Label17.Text = "Oversized Tshirt Unisex"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(11, 418)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(42, 19)
        Me.Label18.TabIndex = 1
        Me.Label18.Text = "Stock:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(11, 439)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(51, 19)
        Me.Label19.TabIndex = 1
        Me.Label19.Text = "₱499.00"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.HighlightText
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel3.Controls.Add(Me.Label12)
        Me.Panel3.Controls.Add(Me.sweatpantQty)
        Me.Panel3.Controls.Add(Me.sweatpantSize)
        Me.Panel3.Controls.Add(Me.Button15)
        Me.Panel3.Controls.Add(Me.Button16)
        Me.Panel3.Controls.Add(Me.Button17)
        Me.Panel3.Controls.Add(Me.sweatpantAddToCart)
        Me.Panel3.Controls.Add(Me.Label13)
        Me.Panel3.Controls.Add(Me.Label14)
        Me.Panel3.Controls.Add(Me.Label15)
        Me.Panel3.Controls.Add(Me.sweatpantsPic)
        Me.Panel3.Location = New System.Drawing.Point(1062, 101)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(319, 479)
        Me.Panel3.TabIndex = 9
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Himalaya", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(277, 367)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(27, 16)
        Me.Label12.TabIndex = 6
        Me.Label12.Text = "Size"
        '
        'sweatpantQty
        '
        Me.sweatpantQty.Font = New System.Drawing.Font("Microsoft Himalaya", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sweatpantQty.ForeColor = System.Drawing.Color.Gray
        Me.sweatpantQty.Location = New System.Drawing.Point(202, 389)
        Me.sweatpantQty.Name = "sweatpantQty"
        Me.sweatpantQty.Size = New System.Drawing.Size(100, 23)
        Me.sweatpantQty.TabIndex = 5
        Me.sweatpantQty.Text = "Quantity"
        Me.sweatpantQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'sweatpantSize
        '
        Me.sweatpantSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.sweatpantSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.sweatpantSize.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sweatpantSize.FormattingEnabled = True
        Me.sweatpantSize.Items.AddRange(New Object() {"S", "M", "L", "XL"})
        Me.sweatpantSize.Location = New System.Drawing.Point(180, 337)
        Me.sweatpantSize.Name = "sweatpantSize"
        Me.sweatpantSize.Size = New System.Drawing.Size(121, 27)
        Me.sweatpantSize.TabIndex = 4
        '
        'Button15
        '
        Me.Button15.BackColor = System.Drawing.Color.Gray
        Me.Button15.FlatAppearance.BorderSize = 2
        Me.Button15.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button15.Location = New System.Drawing.Point(76, 338)
        Me.Button15.Name = "Button15"
        Me.Button15.Size = New System.Drawing.Size(20, 20)
        Me.Button15.TabIndex = 3
        Me.Button15.UseVisualStyleBackColor = False
        '
        'Button16
        '
        Me.Button16.BackColor = System.Drawing.Color.White
        Me.Button16.FlatAppearance.BorderSize = 2
        Me.Button16.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button16.Location = New System.Drawing.Point(50, 338)
        Me.Button16.Name = "Button16"
        Me.Button16.Size = New System.Drawing.Size(20, 20)
        Me.Button16.TabIndex = 3
        Me.Button16.UseVisualStyleBackColor = False
        '
        'Button17
        '
        Me.Button17.BackColor = System.Drawing.Color.Black
        Me.Button17.FlatAppearance.BorderSize = 2
        Me.Button17.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button17.Location = New System.Drawing.Point(24, 338)
        Me.Button17.Name = "Button17"
        Me.Button17.Size = New System.Drawing.Size(20, 20)
        Me.Button17.TabIndex = 3
        Me.Button17.UseVisualStyleBackColor = False
        '
        'sweatpantAddToCart
        '
        Me.sweatpantAddToCart.BackColor = System.Drawing.SystemColors.ControlText
        Me.sweatpantAddToCart.Cursor = System.Windows.Forms.Cursors.Hand
        Me.sweatpantAddToCart.FlatAppearance.BorderSize = 0
        Me.sweatpantAddToCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.sweatpantAddToCart.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sweatpantAddToCart.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.sweatpantAddToCart.Location = New System.Drawing.Point(202, 418)
        Me.sweatpantAddToCart.Name = "sweatpantAddToCart"
        Me.sweatpantAddToCart.Size = New System.Drawing.Size(99, 40)
        Me.sweatpantAddToCart.TabIndex = 2
        Me.sweatpantAddToCart.Text = "ADD TO CART"
        Me.sweatpantAddToCart.UseVisualStyleBackColor = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Himalaya", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(11, 397)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(147, 21)
        Me.Label13.TabIndex = 1
        Me.Label13.Text = "Oversized Tshirt Unisex"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(11, 418)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(42, 19)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "Stock:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(11, 439)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(51, 19)
        Me.Label15.TabIndex = 1
        Me.Label15.Text = "₱499.00"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.HighlightText
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.hoodieQty)
        Me.Panel2.Controls.Add(Me.hoodieSize)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.Button11)
        Me.Panel2.Controls.Add(Me.Button12)
        Me.Panel2.Controls.Add(Me.Button13)
        Me.Panel2.Controls.Add(Me.hoodieAddToCart)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.hoodiePic)
        Me.Panel2.Location = New System.Drawing.Point(715, 101)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(319, 479)
        Me.Panel2.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Himalaya", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(277, 367)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(27, 16)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Size"
        '
        'hoodieQty
        '
        Me.hoodieQty.Font = New System.Drawing.Font("Microsoft Himalaya", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.hoodieQty.ForeColor = System.Drawing.Color.Gray
        Me.hoodieQty.Location = New System.Drawing.Point(202, 389)
        Me.hoodieQty.Name = "hoodieQty"
        Me.hoodieQty.Size = New System.Drawing.Size(100, 23)
        Me.hoodieQty.TabIndex = 5
        Me.hoodieQty.Text = "Quantity"
        Me.hoodieQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'hoodieSize
        '
        Me.hoodieSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.hoodieSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.hoodieSize.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.hoodieSize.FormattingEnabled = True
        Me.hoodieSize.Items.AddRange(New Object() {"S", "M", "L", "XL"})
        Me.hoodieSize.Location = New System.Drawing.Point(180, 337)
        Me.hoodieSize.Name = "hoodieSize"
        Me.hoodieSize.Size = New System.Drawing.Size(121, 27)
        Me.hoodieSize.TabIndex = 4
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Yellow
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatAppearance.BorderSize = 2
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(102, 338)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(20, 20)
        Me.Button1.TabIndex = 3
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button11
        '
        Me.Button11.BackColor = System.Drawing.Color.Pink
        Me.Button11.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button11.FlatAppearance.BorderSize = 2
        Me.Button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button11.Location = New System.Drawing.Point(76, 338)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(20, 20)
        Me.Button11.TabIndex = 3
        Me.Button11.UseVisualStyleBackColor = False
        '
        'Button12
        '
        Me.Button12.BackColor = System.Drawing.Color.Blue
        Me.Button12.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button12.FlatAppearance.BorderSize = 2
        Me.Button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button12.Location = New System.Drawing.Point(50, 338)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(20, 20)
        Me.Button12.TabIndex = 3
        Me.Button12.UseVisualStyleBackColor = False
        '
        'Button13
        '
        Me.Button13.BackColor = System.Drawing.Color.Red
        Me.Button13.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button13.FlatAppearance.BorderSize = 2
        Me.Button13.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button13.Location = New System.Drawing.Point(24, 338)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(20, 20)
        Me.Button13.TabIndex = 3
        Me.Button13.UseVisualStyleBackColor = False
        '
        'hoodieAddToCart
        '
        Me.hoodieAddToCart.BackColor = System.Drawing.SystemColors.ControlText
        Me.hoodieAddToCart.Cursor = System.Windows.Forms.Cursors.Hand
        Me.hoodieAddToCart.FlatAppearance.BorderSize = 0
        Me.hoodieAddToCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.hoodieAddToCart.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.hoodieAddToCart.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.hoodieAddToCart.Location = New System.Drawing.Point(202, 418)
        Me.hoodieAddToCart.Name = "hoodieAddToCart"
        Me.hoodieAddToCart.Size = New System.Drawing.Size(99, 40)
        Me.hoodieAddToCart.TabIndex = 2
        Me.hoodieAddToCart.Text = "ADD TO CART"
        Me.hoodieAddToCart.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Himalaya", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(11, 397)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(147, 21)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Oversized Tshirt Unisex"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(11, 418)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 19)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "Stock:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(11, 439)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(51, 19)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "₱499.00"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.HighlightText
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.shirtQty)
        Me.Panel1.Controls.Add(Me.shirtSize)
        Me.Panel1.Controls.Add(Me.Button7)
        Me.Panel1.Controls.Add(Me.Button8)
        Me.Panel1.Controls.Add(Me.Button9)
        Me.Panel1.Controls.Add(Me.Button10)
        Me.Panel1.Controls.Add(Me.tshirtAddtocart)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.tshirtPic)
        Me.Panel1.Location = New System.Drawing.Point(370, 101)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(318, 479)
        Me.Panel1.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Himalaya", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(277, 367)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(27, 16)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Size"
        '
        'shirtQty
        '
        Me.shirtQty.Font = New System.Drawing.Font("Microsoft Himalaya", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.shirtQty.ForeColor = System.Drawing.Color.Gray
        Me.shirtQty.Location = New System.Drawing.Point(202, 389)
        Me.shirtQty.Name = "shirtQty"
        Me.shirtQty.Size = New System.Drawing.Size(100, 23)
        Me.shirtQty.TabIndex = 5
        Me.shirtQty.Text = "Quantity"
        Me.shirtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'shirtSize
        '
        Me.shirtSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.shirtSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.shirtSize.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.shirtSize.FormattingEnabled = True
        Me.shirtSize.Items.AddRange(New Object() {"S", "M", "L", "XL"})
        Me.shirtSize.Location = New System.Drawing.Point(180, 337)
        Me.shirtSize.Name = "shirtSize"
        Me.shirtSize.Size = New System.Drawing.Size(121, 27)
        Me.shirtSize.TabIndex = 4
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.Color.Green
        Me.Button7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button7.FlatAppearance.BorderSize = 2
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button7.Location = New System.Drawing.Point(102, 338)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(20, 20)
        Me.Button7.TabIndex = 3
        Me.Button7.UseVisualStyleBackColor = False
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.Color.Brown
        Me.Button8.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button8.FlatAppearance.BorderSize = 2
        Me.Button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button8.Location = New System.Drawing.Point(76, 338)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(20, 20)
        Me.Button8.TabIndex = 3
        Me.Button8.UseVisualStyleBackColor = False
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.Color.Blue
        Me.Button9.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button9.FlatAppearance.BorderSize = 2
        Me.Button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button9.Location = New System.Drawing.Point(50, 338)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(20, 20)
        Me.Button9.TabIndex = 3
        Me.Button9.UseVisualStyleBackColor = False
        '
        'Button10
        '
        Me.Button10.BackColor = System.Drawing.Color.White
        Me.Button10.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button10.FlatAppearance.BorderSize = 2
        Me.Button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button10.Location = New System.Drawing.Point(24, 338)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(20, 20)
        Me.Button10.TabIndex = 3
        Me.Button10.UseVisualStyleBackColor = False
        '
        'tshirtAddtocart
        '
        Me.tshirtAddtocart.BackColor = System.Drawing.SystemColors.ControlText
        Me.tshirtAddtocart.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tshirtAddtocart.FlatAppearance.BorderSize = 0
        Me.tshirtAddtocart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.tshirtAddtocart.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tshirtAddtocart.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.tshirtAddtocart.Location = New System.Drawing.Point(202, 418)
        Me.tshirtAddtocart.Name = "tshirtAddtocart"
        Me.tshirtAddtocart.Size = New System.Drawing.Size(99, 40)
        Me.tshirtAddtocart.TabIndex = 2
        Me.tshirtAddtocart.Text = "ADD TO CART"
        Me.tshirtAddtocart.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Himalaya", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(11, 397)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(147, 21)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Oversized Tshirt Unisex"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(11, 418)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 19)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Stock:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(11, 439)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 19)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "₱499.00"
        '
        'sweatshirtPanel
        '
        Me.sweatshirtPanel.BackColor = System.Drawing.SystemColors.HighlightText
        Me.sweatshirtPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.sweatshirtPanel.Controls.Add(Me.Label3)
        Me.sweatshirtPanel.Controls.Add(Me.sweatshirtQty)
        Me.sweatshirtPanel.Controls.Add(Me.sweatshirtSize)
        Me.sweatshirtPanel.Controls.Add(Me.Button6)
        Me.sweatshirtPanel.Controls.Add(Me.Button5)
        Me.sweatshirtPanel.Controls.Add(Me.Button4)
        Me.sweatshirtPanel.Controls.Add(Me.Button3)
        Me.sweatshirtPanel.Controls.Add(Me.Button2)
        Me.sweatshirtPanel.Controls.Add(Me.sweatshirtAddToCart)
        Me.sweatshirtPanel.Controls.Add(Me.Label2)
        Me.sweatshirtPanel.Controls.Add(Me.sweatshirtStockTxt)
        Me.sweatshirtPanel.Controls.Add(Me.Label1)
        Me.sweatshirtPanel.Controls.Add(Me.sweatshirtPic)
        Me.sweatshirtPanel.Location = New System.Drawing.Point(29, 101)
        Me.sweatshirtPanel.Name = "sweatshirtPanel"
        Me.sweatshirtPanel.Size = New System.Drawing.Size(318, 479)
        Me.sweatshirtPanel.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Himalaya", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(277, 367)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 16)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Size"
        '
        'sweatshirtQty
        '
        Me.sweatshirtQty.Font = New System.Drawing.Font("Microsoft Himalaya", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sweatshirtQty.ForeColor = System.Drawing.Color.Gray
        Me.sweatshirtQty.Location = New System.Drawing.Point(202, 389)
        Me.sweatshirtQty.Name = "sweatshirtQty"
        Me.sweatshirtQty.Size = New System.Drawing.Size(100, 23)
        Me.sweatshirtQty.TabIndex = 5
        Me.sweatshirtQty.Text = "Quantity"
        Me.sweatshirtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'sweatshirtSize
        '
        Me.sweatshirtSize.Cursor = System.Windows.Forms.Cursors.Hand
        Me.sweatshirtSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.sweatshirtSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.sweatshirtSize.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sweatshirtSize.FormattingEnabled = True
        Me.sweatshirtSize.Items.AddRange(New Object() {"S", "M", "L", "XL"})
        Me.sweatshirtSize.Location = New System.Drawing.Point(180, 337)
        Me.sweatshirtSize.Name = "sweatshirtSize"
        Me.sweatshirtSize.Size = New System.Drawing.Size(121, 27)
        Me.sweatshirtSize.TabIndex = 4
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.Yellow
        Me.Button6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button6.FlatAppearance.BorderSize = 2
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Location = New System.Drawing.Point(128, 338)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(20, 20)
        Me.Button6.TabIndex = 3
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.FlatAppearance.BorderSize = 2
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Location = New System.Drawing.Point(102, 338)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(20, 20)
        Me.Button5.TabIndex = 3
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Black
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.FlatAppearance.BorderSize = 2
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Location = New System.Drawing.Point(76, 338)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(20, 20)
        Me.Button4.TabIndex = 3
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Gray
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.FlatAppearance.BorderSize = 2
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(50, 338)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(20, 20)
        Me.Button3.TabIndex = 3
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.FlatAppearance.BorderSize = 2
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(24, 338)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(20, 20)
        Me.Button2.TabIndex = 3
        Me.Button2.UseVisualStyleBackColor = False
        '
        'sweatshirtAddToCart
        '
        Me.sweatshirtAddToCart.BackColor = System.Drawing.SystemColors.ControlText
        Me.sweatshirtAddToCart.Cursor = System.Windows.Forms.Cursors.Hand
        Me.sweatshirtAddToCart.FlatAppearance.BorderSize = 0
        Me.sweatshirtAddToCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.sweatshirtAddToCart.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sweatshirtAddToCart.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.sweatshirtAddToCart.Location = New System.Drawing.Point(202, 418)
        Me.sweatshirtAddToCart.Name = "sweatshirtAddToCart"
        Me.sweatshirtAddToCart.Size = New System.Drawing.Size(99, 40)
        Me.sweatshirtAddToCart.TabIndex = 2
        Me.sweatshirtAddToCart.Text = "ADD TO CART"
        Me.sweatshirtAddToCart.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Himalaya", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 397)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(118, 21)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Prestige Sweatshirt"
        '
        'sweatshirtStockTxt
        '
        Me.sweatshirtStockTxt.AutoSize = True
        Me.sweatshirtStockTxt.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sweatshirtStockTxt.Location = New System.Drawing.Point(11, 418)
        Me.sweatshirtStockTxt.Name = "sweatshirtStockTxt"
        Me.sweatshirtStockTxt.Size = New System.Drawing.Size(42, 19)
        Me.sweatshirtStockTxt.TabIndex = 1
        Me.sweatshirtStockTxt.Text = "Stock:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 439)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 19)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "₱599.00"
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(501, 12)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(369, 33)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 1
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(1348, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(48, 45)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox4.Image = Global.APPARELSHOP.My.Resources.Resources.blue_hoodie
        Me.PictureBox4.Location = New System.Drawing.Point(33, 14)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(254, 318)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 0
        Me.PictureBox4.TabStop = False
        '
        'sweatpantsPic
        '
        Me.sweatpantsPic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.sweatpantsPic.Image = Global.APPARELSHOP.My.Resources.Resources.black_Sweatpants
        Me.sweatpantsPic.Location = New System.Drawing.Point(35, 44)
        Me.sweatpantsPic.Name = "sweatpantsPic"
        Me.sweatpantsPic.Size = New System.Drawing.Size(254, 262)
        Me.sweatpantsPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.sweatpantsPic.TabIndex = 0
        Me.sweatpantsPic.TabStop = False
        '
        'hoodiePic
        '
        Me.hoodiePic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.hoodiePic.Image = Global.APPARELSHOP.My.Resources.Resources.blue_hoodie
        Me.hoodiePic.Location = New System.Drawing.Point(33, 14)
        Me.hoodiePic.Name = "hoodiePic"
        Me.hoodiePic.Size = New System.Drawing.Size(254, 318)
        Me.hoodiePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.hoodiePic.TabIndex = 0
        Me.hoodiePic.TabStop = False
        '
        'tshirtPic
        '
        Me.tshirtPic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tshirtPic.Image = Global.APPARELSHOP.My.Resources.Resources.white_shirt1
        Me.tshirtPic.Location = New System.Drawing.Point(21, 14)
        Me.tshirtPic.Name = "tshirtPic"
        Me.tshirtPic.Size = New System.Drawing.Size(270, 318)
        Me.tshirtPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.tshirtPic.TabIndex = 0
        Me.tshirtPic.TabStop = False
        '
        'sweatshirtPic
        '
        Me.sweatshirtPic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.sweatshirtPic.Image = Global.APPARELSHOP.My.Resources.Resources.white_swsh
        Me.sweatshirtPic.Location = New System.Drawing.Point(15, 14)
        Me.sweatshirtPic.Name = "sweatshirtPic"
        Me.sweatshirtPic.Size = New System.Drawing.Size(286, 318)
        Me.sweatshirtPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.sweatshirtPic.TabIndex = 0
        Me.sweatshirtPic.TabStop = False
        '
        'apparelPage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1416, 680)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Panel4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "apparelPage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "apparelPage"
        Me.Panel4.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.sweatshirtPanel.ResumeLayout(False)
        Me.sweatshirtPanel.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sweatpantsPic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.hoodiePic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tshirtPic, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sweatshirtPic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label16 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents Button19 As Button
    Friend WithEvents Button20 As Button
    Friend WithEvents Button21 As Button
    Friend WithEvents Button22 As Button
    Friend WithEvents Button23 As Button
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label12 As Label
    Friend WithEvents sweatpantQty As TextBox
    Friend WithEvents sweatpantSize As ComboBox
    Friend WithEvents Button15 As Button
    Friend WithEvents Button16 As Button
    Friend WithEvents Button17 As Button
    Friend WithEvents sweatpantAddToCart As Button
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents sweatpantsPic As PictureBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents hoodieQty As TextBox
    Friend WithEvents hoodieSize As ComboBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button11 As Button
    Friend WithEvents Button12 As Button
    Friend WithEvents Button13 As Button
    Friend WithEvents hoodieAddToCart As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents hoodiePic As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents shirtQty As TextBox
    Friend WithEvents shirtSize As ComboBox
    Friend WithEvents Button7 As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents Button9 As Button
    Friend WithEvents Button10 As Button
    Friend WithEvents tshirtAddtocart As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents tshirtPic As PictureBox
    Friend WithEvents sweatshirtPanel As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents sweatshirtQty As TextBox
    Friend WithEvents sweatshirtSize As ComboBox
    Friend WithEvents Button6 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents sweatshirtAddToCart As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents sweatshirtStockTxt As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents sweatshirtPic As PictureBox
End Class
