﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AdminFormPage
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
        Me.addProductPanel = New System.Windows.Forms.Panel()
        Me.genderTxt = New System.Windows.Forms.ComboBox()
        Me.remarksTxt = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.supplierPriceTxt = New System.Windows.Forms.TextBox()
        Me.addProductBtn = New System.Windows.Forms.Button()
        Me.FileUploadButton = New System.Windows.Forms.Button()
        Me.SupplierLists = New System.Windows.Forms.ComboBox()
        Me.sizeTxt = New System.Windows.Forms.ComboBox()
        Me.brandTxt = New System.Windows.Forms.ComboBox()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.CategoryLists = New System.Windows.Forms.ComboBox()
        Me.QuantityList = New System.Windows.Forms.TextBox()
        Me.PriceTxt = New System.Windows.Forms.TextBox()
        Me.ColorTxt = New System.Windows.Forms.TextBox()
        Me.productNameTxt = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.FileSystemWatcher1 = New System.IO.FileSystemWatcher()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.statusDropdown = New System.Windows.Forms.ComboBox()
        Me.btnUpdateStatus = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblTotalProductsSold = New System.Windows.Forms.Label()
        Me.lblTotalStoreIncome = New System.Windows.Forms.Label()
        Me.dtpStartDate = New System.Windows.Forms.DateTimePicker()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.dtpEndDate = New System.Windows.Forms.DateTimePicker()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblResult = New System.Windows.Forms.Label()
        Me.lblTotalStoreProfit = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.createBtn = New System.Windows.Forms.Button()
        Me.passwordTxt = New System.Windows.Forms.TextBox()
        Me.usernameTxt = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtCancelReason = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.btnUpdateQR = New System.Windows.Forms.Button()
        Me.addProductPanel.SuspendLayout()
        CType(Me.FileSystemWatcher1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'addProductPanel
        '
        Me.addProductPanel.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.addProductPanel.Controls.Add(Me.genderTxt)
        Me.addProductPanel.Controls.Add(Me.remarksTxt)
        Me.addProductPanel.Controls.Add(Me.Label11)
        Me.addProductPanel.Controls.Add(Me.supplierPriceTxt)
        Me.addProductPanel.Controls.Add(Me.addProductBtn)
        Me.addProductPanel.Controls.Add(Me.FileUploadButton)
        Me.addProductPanel.Controls.Add(Me.SupplierLists)
        Me.addProductPanel.Controls.Add(Me.sizeTxt)
        Me.addProductPanel.Controls.Add(Me.brandTxt)
        Me.addProductPanel.Controls.Add(Me.ComboBox3)
        Me.addProductPanel.Controls.Add(Me.CategoryLists)
        Me.addProductPanel.Controls.Add(Me.QuantityList)
        Me.addProductPanel.Controls.Add(Me.PriceTxt)
        Me.addProductPanel.Controls.Add(Me.ColorTxt)
        Me.addProductPanel.Controls.Add(Me.productNameTxt)
        Me.addProductPanel.Controls.Add(Me.Label14)
        Me.addProductPanel.Controls.Add(Me.Label13)
        Me.addProductPanel.Controls.Add(Me.Label8)
        Me.addProductPanel.Controls.Add(Me.Label12)
        Me.addProductPanel.Controls.Add(Me.Label7)
        Me.addProductPanel.Controls.Add(Me.Label6)
        Me.addProductPanel.Controls.Add(Me.Label4)
        Me.addProductPanel.Controls.Add(Me.Label3)
        Me.addProductPanel.Controls.Add(Me.Label5)
        Me.addProductPanel.Controls.Add(Me.Label10)
        Me.addProductPanel.Controls.Add(Me.Label9)
        Me.addProductPanel.Controls.Add(Me.Label2)
        Me.addProductPanel.Controls.Add(Me.Label1)
        Me.addProductPanel.Location = New System.Drawing.Point(13, 531)
        Me.addProductPanel.Name = "addProductPanel"
        Me.addProductPanel.Size = New System.Drawing.Size(1311, 212)
        Me.addProductPanel.TabIndex = 0
        '
        'genderTxt
        '
        Me.genderTxt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.genderTxt.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.genderTxt.FormattingEnabled = True
        Me.genderTxt.Items.AddRange(New Object() {"Male", "Female", "Unisex"})
        Me.genderTxt.Location = New System.Drawing.Point(775, 34)
        Me.genderTxt.Name = "genderTxt"
        Me.genderTxt.Size = New System.Drawing.Size(121, 27)
        Me.genderTxt.TabIndex = 8
        '
        'remarksTxt
        '
        Me.remarksTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.remarksTxt.Location = New System.Drawing.Point(940, 32)
        Me.remarksTxt.Name = "remarksTxt"
        Me.remarksTxt.Size = New System.Drawing.Size(340, 29)
        Me.remarksTxt.TabIndex = 7
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(619, 149)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(105, 38)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "SUPPLIER PRICE" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "PER PIECE" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'supplierPriceTxt
        '
        Me.supplierPriceTxt.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.supplierPriceTxt.Location = New System.Drawing.Point(623, 115)
        Me.supplierPriceTxt.Name = "supplierPriceTxt"
        Me.supplierPriceTxt.Size = New System.Drawing.Size(115, 26)
        Me.supplierPriceTxt.TabIndex = 5
        '
        'addProductBtn
        '
        Me.addProductBtn.BackColor = System.Drawing.Color.ForestGreen
        Me.addProductBtn.Font = New System.Drawing.Font("Microsoft Himalaya", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.addProductBtn.ForeColor = System.Drawing.Color.White
        Me.addProductBtn.Location = New System.Drawing.Point(1187, 173)
        Me.addProductBtn.Name = "addProductBtn"
        Me.addProductBtn.Size = New System.Drawing.Size(104, 31)
        Me.addProductBtn.TabIndex = 4
        Me.addProductBtn.Text = "ADD ITEM"
        Me.addProductBtn.UseVisualStyleBackColor = False
        '
        'FileUploadButton
        '
        Me.FileUploadButton.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FileUploadButton.Location = New System.Drawing.Point(940, 114)
        Me.FileUploadButton.Name = "FileUploadButton"
        Me.FileUploadButton.Size = New System.Drawing.Size(128, 26)
        Me.FileUploadButton.TabIndex = 3
        Me.FileUploadButton.Text = "FILE UPLOAD"
        Me.FileUploadButton.UseVisualStyleBackColor = True
        '
        'SupplierLists
        '
        Me.SupplierLists.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SupplierLists.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SupplierLists.FormattingEnabled = True
        Me.SupplierLists.Location = New System.Drawing.Point(454, 119)
        Me.SupplierLists.Name = "SupplierLists"
        Me.SupplierLists.Size = New System.Drawing.Size(142, 27)
        Me.SupplierLists.TabIndex = 2
        '
        'sizeTxt
        '
        Me.sizeTxt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.sizeTxt.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sizeTxt.FormattingEnabled = True
        Me.sizeTxt.Items.AddRange(New Object() {"S", "M", "L", "XL", "XXL"})
        Me.sizeTxt.Location = New System.Drawing.Point(291, 35)
        Me.sizeTxt.Name = "sizeTxt"
        Me.sizeTxt.Size = New System.Drawing.Size(142, 27)
        Me.sizeTxt.TabIndex = 2
        '
        'brandTxt
        '
        Me.brandTxt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.brandTxt.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.brandTxt.FormattingEnabled = True
        Me.brandTxt.Items.AddRange(New Object() {"APPAREL", "PERFUME"})
        Me.brandTxt.Location = New System.Drawing.Point(154, 119)
        Me.brandTxt.Name = "brandTxt"
        Me.brandTxt.Size = New System.Drawing.Size(115, 27)
        Me.brandTxt.TabIndex = 2
        '
        'ComboBox3
        '
        Me.ComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox3.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Items.AddRange(New Object() {"APPAREL", "PERFUME"})
        Me.ComboBox3.Location = New System.Drawing.Point(16, 119)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(115, 27)
        Me.ComboBox3.TabIndex = 2
        '
        'CategoryLists
        '
        Me.CategoryLists.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CategoryLists.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CategoryLists.FormattingEnabled = True
        Me.CategoryLists.Location = New System.Drawing.Point(291, 119)
        Me.CategoryLists.Name = "CategoryLists"
        Me.CategoryLists.Size = New System.Drawing.Size(142, 27)
        Me.CategoryLists.TabIndex = 2
        '
        'QuantityList
        '
        Me.QuantityList.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.QuantityList.Location = New System.Drawing.Point(454, 36)
        Me.QuantityList.Name = "QuantityList"
        Me.QuantityList.Size = New System.Drawing.Size(142, 26)
        Me.QuantityList.TabIndex = 1
        '
        'PriceTxt
        '
        Me.PriceTxt.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PriceTxt.Location = New System.Drawing.Point(623, 36)
        Me.PriceTxt.Name = "PriceTxt"
        Me.PriceTxt.Size = New System.Drawing.Size(115, 26)
        Me.PriceTxt.TabIndex = 1
        '
        'ColorTxt
        '
        Me.ColorTxt.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ColorTxt.Location = New System.Drawing.Point(154, 36)
        Me.ColorTxt.Name = "ColorTxt"
        Me.ColorTxt.Size = New System.Drawing.Size(115, 26)
        Me.ColorTxt.TabIndex = 1
        '
        'productNameTxt
        '
        Me.productNameTxt.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.productNameTxt.Location = New System.Drawing.Point(16, 35)
        Me.productNameTxt.Name = "productNameTxt"
        Me.productNameTxt.Size = New System.Drawing.Size(115, 26)
        Me.productNameTxt.TabIndex = 1
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(771, 67)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(99, 19)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "DESIGNED FOR"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(936, 65)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(68, 19)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "REMARKS"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(936, 143)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(123, 38)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "UPLOAD PRODUCT " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "PICTURE"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(287, 67)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(36, 19)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "SIZE"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(450, 67)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 19)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "QUANTITY"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(622, 62)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 57)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "SELLING PRICE" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "PER PIECE" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(IN PHP)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(450, 149)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 19)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "SUPPLIER"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(287, 149)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 19)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "CATEGORY"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(150, 65)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 19)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "COLOR"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(150, 149)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(52, 19)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "BRAND"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(12, 149)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 19)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "PRODUCT TYPE"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 19)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "PRODUCT NAME"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Himalaya", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.ForestGreen
        Me.Label1.Location = New System.Drawing.Point(12, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(129, 21)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ADD PRODUCTS"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'FileSystemWatcher1
        '
        Me.FileSystemWatcher1.EnableRaisingEvents = True
        Me.FileSystemWatcher1.SynchronizingObject = Me
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(915, 33)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(408, 388)
        Me.DataGridView1.TabIndex = 1
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Himalaya", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.ForestGreen
        Me.Label15.Location = New System.Drawing.Point(911, 9)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(91, 21)
        Me.Label15.TabIndex = 2
        Me.Label15.Text = "PRODUCTS"
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(360, 33)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(541, 349)
        Me.DataGridView2.TabIndex = 3
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Himalaya", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.ForestGreen
        Me.Label16.Location = New System.Drawing.Point(356, 9)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(71, 21)
        Me.Label16.TabIndex = 2
        Me.Label16.Text = "ORDERS"
        '
        'statusDropdown
        '
        Me.statusDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.statusDropdown.Font = New System.Drawing.Font("Microsoft Himalaya", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.statusDropdown.FormattingEnabled = True
        Me.statusDropdown.Location = New System.Drawing.Point(408, 392)
        Me.statusDropdown.Name = "statusDropdown"
        Me.statusDropdown.Size = New System.Drawing.Size(166, 29)
        Me.statusDropdown.TabIndex = 4
        '
        'btnUpdateStatus
        '
        Me.btnUpdateStatus.BackColor = System.Drawing.Color.ForestGreen
        Me.btnUpdateStatus.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdateStatus.ForeColor = System.Drawing.Color.White
        Me.btnUpdateStatus.Location = New System.Drawing.Point(776, 388)
        Me.btnUpdateStatus.Name = "btnUpdateStatus"
        Me.btnUpdateStatus.Size = New System.Drawing.Size(125, 33)
        Me.btnUpdateStatus.TabIndex = 5
        Me.btnUpdateStatus.Text = "UPDATE STATUS"
        Me.btnUpdateStatus.UseVisualStyleBackColor = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label17.Location = New System.Drawing.Point(404, 423)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(39, 19)
        Me.Label17.TabIndex = 6
        Me.Label17.Text = "status"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Himalaya", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.ForestGreen
        Me.Label18.Location = New System.Drawing.Point(8, 9)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(141, 24)
        Me.Label18.TabIndex = 2
        Me.Label18.Text = "STORE INCOME"
        '
        'lblTotalProductsSold
        '
        Me.lblTotalProductsSold.AutoSize = True
        Me.lblTotalProductsSold.Font = New System.Drawing.Font("Microsoft Himalaya", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalProductsSold.Location = New System.Drawing.Point(9, 36)
        Me.lblTotalProductsSold.Name = "lblTotalProductsSold"
        Me.lblTotalProductsSold.Size = New System.Drawing.Size(127, 21)
        Me.lblTotalProductsSold.TabIndex = 2
        Me.lblTotalProductsSold.Text = "Total Products Sold:"
        '
        'lblTotalStoreIncome
        '
        Me.lblTotalStoreIncome.AutoSize = True
        Me.lblTotalStoreIncome.Font = New System.Drawing.Font("Microsoft Himalaya", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalStoreIncome.Location = New System.Drawing.Point(8, 86)
        Me.lblTotalStoreIncome.Name = "lblTotalStoreIncome"
        Me.lblTotalStoreIncome.Size = New System.Drawing.Size(124, 21)
        Me.lblTotalStoreIncome.TabIndex = 2
        Me.lblTotalStoreIncome.Text = "Total Store Income:"
        '
        'dtpStartDate
        '
        Me.dtpStartDate.Location = New System.Drawing.Point(48, 206)
        Me.dtpStartDate.Name = "dtpStartDate"
        Me.dtpStartDate.Size = New System.Drawing.Size(200, 20)
        Me.dtpStartDate.TabIndex = 7
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Himalaya", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.ForestGreen
        Me.Label19.Location = New System.Drawing.Point(12, 165)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(281, 21)
        Me.Label19.TabIndex = 2
        Me.Label19.Text = "Select a date range to view shop income:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Himalaya", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(94, 186)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(109, 21)
        Me.Label20.TabIndex = 2
        Me.Label20.Text = "Select Start Date:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Himalaya", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(94, 229)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(105, 21)
        Me.Label21.TabIndex = 2
        Me.Label21.Text = "Select End Date:"
        '
        'dtpEndDate
        '
        Me.dtpEndDate.Location = New System.Drawing.Point(48, 248)
        Me.dtpEndDate.Name = "dtpEndDate"
        Me.dtpEndDate.Size = New System.Drawing.Size(200, 20)
        Me.dtpEndDate.TabIndex = 8
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.ForestGreen
        Me.Button1.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(48, 277)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(200, 39)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "Calculate"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'lblResult
        '
        Me.lblResult.AutoSize = True
        Me.lblResult.Font = New System.Drawing.Font("Microsoft Himalaya", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResult.Location = New System.Drawing.Point(12, 331)
        Me.lblResult.Name = "lblResult"
        Me.lblResult.Size = New System.Drawing.Size(69, 21)
        Me.lblResult.TabIndex = 2
        Me.lblResult.Text = "lblResult"
        '
        'lblTotalStoreProfit
        '
        Me.lblTotalStoreProfit.AutoSize = True
        Me.lblTotalStoreProfit.Font = New System.Drawing.Font("Microsoft Himalaya", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalStoreProfit.Location = New System.Drawing.Point(8, 61)
        Me.lblTotalStoreProfit.Name = "lblTotalStoreProfit"
        Me.lblTotalStoreProfit.Size = New System.Drawing.Size(115, 21)
        Me.lblTotalStoreProfit.TabIndex = 2
        Me.lblTotalStoreProfit.Text = "Total Store Profit:"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.Panel1.Controls.Add(Me.createBtn)
        Me.Panel1.Controls.Add(Me.passwordTxt)
        Me.Panel1.Controls.Add(Me.usernameTxt)
        Me.Panel1.Controls.Add(Me.Label22)
        Me.Panel1.Controls.Add(Me.Label24)
        Me.Panel1.Controls.Add(Me.Label23)
        Me.Panel1.Location = New System.Drawing.Point(839, 432)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(485, 84)
        Me.Panel1.TabIndex = 10
        '
        'createBtn
        '
        Me.createBtn.BackColor = System.Drawing.Color.ForestGreen
        Me.createBtn.Font = New System.Drawing.Font("Microsoft Himalaya", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.createBtn.ForeColor = System.Drawing.SystemColors.Control
        Me.createBtn.Location = New System.Drawing.Point(377, 17)
        Me.createBtn.Name = "createBtn"
        Me.createBtn.Size = New System.Drawing.Size(105, 40)
        Me.createBtn.TabIndex = 1
        Me.createBtn.Text = "CREATE STAFF ACCOUNT"
        Me.createBtn.UseVisualStyleBackColor = False
        '
        'passwordTxt
        '
        Me.passwordTxt.Font = New System.Drawing.Font("Microsoft Himalaya", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.passwordTxt.Location = New System.Drawing.Point(190, 20)
        Me.passwordTxt.Name = "passwordTxt"
        Me.passwordTxt.Size = New System.Drawing.Size(181, 23)
        Me.passwordTxt.TabIndex = 0
        '
        'usernameTxt
        '
        Me.usernameTxt.Font = New System.Drawing.Font("Microsoft Himalaya", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.usernameTxt.Location = New System.Drawing.Point(4, 20)
        Me.usernameTxt.Name = "usernameTxt"
        Me.usernameTxt.Size = New System.Drawing.Size(181, 23)
        Me.usernameTxt.TabIndex = 0
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.ForeColor = System.Drawing.SystemColors.GrayText
        Me.Label22.Location = New System.Drawing.Point(2, 4)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(204, 19)
        Me.Label22.TabIndex = 6
        Me.Label22.Text = "CREATE ADMIN/STAFF ACCOUNT"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label24.Location = New System.Drawing.Point(186, 46)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(56, 19)
        Me.Label24.TabIndex = 6
        Me.Label24.Text = "password"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label23.Location = New System.Drawing.Point(5, 46)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(57, 19)
        Me.Label23.TabIndex = 6
        Me.Label23.Text = "username"
        '
        'txtCancelReason
        '
        Me.txtCancelReason.Enabled = False
        Me.txtCancelReason.Font = New System.Drawing.Font("Microsoft Himalaya", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCancelReason.Location = New System.Drawing.Point(580, 392)
        Me.txtCancelReason.Name = "txtCancelReason"
        Me.txtCancelReason.Size = New System.Drawing.Size(190, 28)
        Me.txtCancelReason.TabIndex = 11
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label25.Location = New System.Drawing.Point(576, 423)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(52, 19)
        Me.Label25.TabIndex = 6
        Me.Label25.Text = "message"
        '
        'btnUpdateQR
        '
        Me.btnUpdateQR.BackColor = System.Drawing.Color.ForestGreen
        Me.btnUpdateQR.Font = New System.Drawing.Font("Microsoft Himalaya", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdateQR.ForeColor = System.Drawing.Color.Transparent
        Me.btnUpdateQR.Location = New System.Drawing.Point(707, 432)
        Me.btnUpdateQR.Name = "btnUpdateQR"
        Me.btnUpdateQR.Size = New System.Drawing.Size(124, 84)
        Me.btnUpdateQR.TabIndex = 12
        Me.btnUpdateQR.Text = "UPDATE QR PAYMENT PICTURE"
        Me.btnUpdateQR.UseVisualStyleBackColor = False
        '
        'AdminFormPage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1351, 669)
        Me.Controls.Add(Me.btnUpdateQR)
        Me.Controls.Add(Me.txtCancelReason)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.dtpEndDate)
        Me.Controls.Add(Me.dtpStartDate)
        Me.Controls.Add(Me.btnUpdateStatus)
        Me.Controls.Add(Me.statusDropdown)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.lblTotalStoreIncome)
        Me.Controls.Add(Me.lblTotalProductsSold)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.lblResult)
        Me.Controls.Add(Me.lblTotalStoreProfit)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.addProductPanel)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label17)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "AdminFormPage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ADMIN PAGE"
        Me.addProductPanel.ResumeLayout(False)
        Me.addProductPanel.PerformLayout()
        CType(Me.FileSystemWatcher1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents addProductPanel As Panel
    Friend WithEvents CategoryLists As ComboBox
    Friend WithEvents ColorTxt As TextBox
    Friend WithEvents productNameTxt As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents SupplierLists As ComboBox
    Friend WithEvents QuantityList As TextBox
    Friend WithEvents PriceTxt As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents FileUploadButton As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents addProductBtn As Button
    Friend WithEvents ComboBox3 As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents FileSystemWatcher1 As IO.FileSystemWatcher
    Friend WithEvents brandTxt As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents sizeTxt As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents supplierPriceTxt As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents remarksTxt As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents genderTxt As ComboBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label15 As Label
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents Label16 As Label
    Friend WithEvents statusDropdown As ComboBox
    Friend WithEvents btnUpdateStatus As Button
    Friend WithEvents Label17 As Label
    Friend WithEvents dtpStartDate As DateTimePicker
    Friend WithEvents lblTotalStoreIncome As Label
    Friend WithEvents lblTotalProductsSold As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents dtpEndDate As DateTimePicker
    Friend WithEvents Label21 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents lblResult As Label
    Friend WithEvents lblTotalStoreProfit As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents createBtn As Button
    Friend WithEvents passwordTxt As TextBox
    Friend WithEvents usernameTxt As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents txtCancelReason As TextBox
    Friend WithEvents Label25 As Label
    Friend WithEvents btnUpdateQR As Button
End Class
