<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.btnUpload = New System.Windows.Forms.Button()
        Me.FileUploadButton = New System.Windows.Forms.Button()
        Me.SupplierLists = New System.Windows.Forms.ComboBox()
        Me.CategoryLists = New System.Windows.Forms.ComboBox()
        Me.QuantityList = New System.Windows.Forms.TextBox()
        Me.PriceTxt = New System.Windows.Forms.TextBox()
        Me.ColorTxt = New System.Windows.Forms.TextBox()
        Me.productNameTxt = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.FileSystemWatcher1 = New System.IO.FileSystemWatcher()
        Me.brandTxt = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.sizeTxt = New System.Windows.Forms.ComboBox()
        Me.addProductPanel.SuspendLayout()
        CType(Me.FileSystemWatcher1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'addProductPanel
        '
        Me.addProductPanel.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.addProductPanel.Controls.Add(Me.btnUpload)
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
        Me.addProductPanel.Controls.Add(Me.Label8)
        Me.addProductPanel.Controls.Add(Me.Label7)
        Me.addProductPanel.Controls.Add(Me.Label6)
        Me.addProductPanel.Controls.Add(Me.Label4)
        Me.addProductPanel.Controls.Add(Me.Label3)
        Me.addProductPanel.Controls.Add(Me.Label5)
        Me.addProductPanel.Controls.Add(Me.Label10)
        Me.addProductPanel.Controls.Add(Me.Label9)
        Me.addProductPanel.Controls.Add(Me.Label2)
        Me.addProductPanel.Controls.Add(Me.Label1)
        Me.addProductPanel.Location = New System.Drawing.Point(12, 427)
        Me.addProductPanel.Name = "addProductPanel"
        Me.addProductPanel.Size = New System.Drawing.Size(1311, 234)
        Me.addProductPanel.TabIndex = 0
        '
        'btnUpload
        '
        Me.btnUpload.Font = New System.Drawing.Font("Microsoft Himalaya", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpload.Location = New System.Drawing.Point(1185, 186)
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Size = New System.Drawing.Size(104, 23)
        Me.btnUpload.TabIndex = 4
        Me.btnUpload.Text = "ADD ITEM"
        Me.btnUpload.UseVisualStyleBackColor = True
        '
        'FileUploadButton
        '
        Me.FileUploadButton.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FileUploadButton.Location = New System.Drawing.Point(914, 36)
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
        Me.SupplierLists.Location = New System.Drawing.Point(455, 35)
        Me.SupplierLists.Name = "SupplierLists"
        Me.SupplierLists.Size = New System.Drawing.Size(142, 27)
        Me.SupplierLists.TabIndex = 2
        '
        'CategoryLists
        '
        Me.CategoryLists.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CategoryLists.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CategoryLists.FormattingEnabled = True
        Me.CategoryLists.Location = New System.Drawing.Point(291, 35)
        Me.CategoryLists.Name = "CategoryLists"
        Me.CategoryLists.Size = New System.Drawing.Size(142, 27)
        Me.CategoryLists.TabIndex = 2
        '
        'QuantityList
        '
        Me.QuantityList.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.QuantityList.Location = New System.Drawing.Point(771, 36)
        Me.QuantityList.Name = "QuantityList"
        Me.QuantityList.Size = New System.Drawing.Size(115, 26)
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
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Himalaya", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(910, 65)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(140, 42)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "UPLOAD PRODUCT " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "PICTURE"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Himalaya", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(767, 65)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 21)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "QUANTITY"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Himalaya", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(619, 65)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(109, 21)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "PRICE (IN PHP)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Himalaya", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(451, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 21)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "SUPPLIER"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Himalaya", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(287, 65)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 21)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "CATEGORY"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Himalaya", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(150, 65)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 21)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "COLOR"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Himalaya", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(121, 21)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "PRODUCT NAME"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Himalaya", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(117, 21)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ADD PRODUCTS"
        '
        'BackgroundWorker1
        '
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'ComboBox3
        '
        Me.ComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox3.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Items.AddRange(New Object() {"APPAREL", "PERFUME"})
        Me.ComboBox3.Location = New System.Drawing.Point(16, 89)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(115, 27)
        Me.ComboBox3.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Himalaya", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(12, 119)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(115, 21)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "PRODUCT TYPE"
        '
        'FileSystemWatcher1
        '
        Me.FileSystemWatcher1.EnableRaisingEvents = True
        Me.FileSystemWatcher1.SynchronizingObject = Me
        '
        'brandTxt
        '
        Me.brandTxt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.brandTxt.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.brandTxt.FormattingEnabled = True
        Me.brandTxt.Items.AddRange(New Object() {"APPAREL", "PERFUME"})
        Me.brandTxt.Location = New System.Drawing.Point(154, 89)
        Me.brandTxt.Name = "brandTxt"
        Me.brandTxt.Size = New System.Drawing.Size(115, 27)
        Me.brandTxt.TabIndex = 2
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Himalaya", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(150, 119)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(58, 21)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "BRAND"
        '
        'sizeTxt
        '
        Me.sizeTxt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.sizeTxt.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.sizeTxt.FormattingEnabled = True
        Me.sizeTxt.Items.AddRange(New Object() {"S", "M", "L", "XL", "XXL"})
        Me.sizeTxt.Location = New System.Drawing.Point(291, 89)
        Me.sizeTxt.Name = "sizeTxt"
        Me.sizeTxt.Size = New System.Drawing.Size(142, 27)
        Me.sizeTxt.TabIndex = 2
        '
        'AdminFormPage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1335, 673)
        Me.Controls.Add(Me.addProductPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "AdminFormPage"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AdminFormPage"
        Me.addProductPanel.ResumeLayout(False)
        Me.addProductPanel.PerformLayout()
        CType(Me.FileSystemWatcher1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

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
    Friend WithEvents btnUpload As Button
    Friend WithEvents ComboBox3 As ComboBox
    Friend WithEvents Label9 As Label
    Friend WithEvents FileSystemWatcher1 As IO.FileSystemWatcher
    Friend WithEvents brandTxt As ComboBox
    Friend WithEvents Label10 As Label
    Friend WithEvents sizeTxt As ComboBox
End Class
