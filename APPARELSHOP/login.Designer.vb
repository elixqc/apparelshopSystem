<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class login
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(login))
        Me.signInText = New System.Windows.Forms.Label()
        Me.createAccLabel = New System.Windows.Forms.Label()
        Me.signIn_panel = New System.Windows.Forms.Panel()
        Me.signInBtn = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.passwordLogin = New System.Windows.Forms.TextBox()
        Me.emailLogin = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.fullName = New System.Windows.Forms.TextBox()
        Me.FileSystemWatcher1 = New System.IO.FileSystemWatcher()
        Me.email = New System.Windows.Forms.TextBox()
        Me.password = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.contactNumber = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.address = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.createAccountBtn = New System.Windows.Forms.Button()
        Me.signIn_panel.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FileSystemWatcher1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'signInText
        '
        Me.signInText.AutoSize = True
        Me.signInText.Cursor = System.Windows.Forms.Cursors.Hand
        Me.signInText.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.signInText.Location = New System.Drawing.Point(95, 69)
        Me.signInText.Name = "signInText"
        Me.signInText.Size = New System.Drawing.Size(79, 27)
        Me.signInText.TabIndex = 0
        Me.signInText.Text = "Sign In"
        '
        'createAccLabel
        '
        Me.createAccLabel.AutoSize = True
        Me.createAccLabel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.createAccLabel.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.createAccLabel.Location = New System.Drawing.Point(211, 69)
        Me.createAccLabel.Name = "createAccLabel"
        Me.createAccLabel.Size = New System.Drawing.Size(163, 27)
        Me.createAccLabel.TabIndex = 0
        Me.createAccLabel.Text = "Create Account"
        '
        'signIn_panel
        '
        Me.signIn_panel.Controls.Add(Me.signInBtn)
        Me.signIn_panel.Controls.Add(Me.Label2)
        Me.signIn_panel.Controls.Add(Me.passwordLogin)
        Me.signIn_panel.Controls.Add(Me.emailLogin)
        Me.signIn_panel.Location = New System.Drawing.Point(51, 118)
        Me.signIn_panel.Name = "signIn_panel"
        Me.signIn_panel.Size = New System.Drawing.Size(344, 358)
        Me.signIn_panel.TabIndex = 1
        '
        'signInBtn
        '
        Me.signInBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.signInBtn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.signInBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.signInBtn.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.signInBtn.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.signInBtn.Location = New System.Drawing.Point(31, 281)
        Me.signInBtn.Name = "signInBtn"
        Me.signInBtn.Size = New System.Drawing.Size(278, 54)
        Me.signInBtn.TabIndex = 2
        Me.signInBtn.Text = "SIGN IN"
        Me.signInBtn.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label2.Font = New System.Drawing.Font("Yu Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(28, 144)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 14)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Register now"
        '
        'passwordLogin
        '
        Me.passwordLogin.Font = New System.Drawing.Font("Yu Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.passwordLogin.ForeColor = System.Drawing.Color.Gray
        Me.passwordLogin.Location = New System.Drawing.Point(31, 94)
        Me.passwordLogin.Name = "passwordLogin"
        Me.passwordLogin.Size = New System.Drawing.Size(278, 38)
        Me.passwordLogin.TabIndex = 0
        '
        'emailLogin
        '
        Me.emailLogin.Font = New System.Drawing.Font("Yu Gothic", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.emailLogin.ForeColor = System.Drawing.Color.Gray
        Me.emailLogin.Location = New System.Drawing.Point(31, 33)
        Me.emailLogin.Name = "emailLogin"
        Me.emailLogin.Size = New System.Drawing.Size(278, 38)
        Me.emailLogin.TabIndex = 0
        Me.emailLogin.Text = "EMAIL ADDRESS"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(47, 85)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(348, 54)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "____________________________" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(405, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(34, 33)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 2
        Me.PictureBox1.TabStop = False
        '
        'fullName
        '
        Me.fullName.Font = New System.Drawing.Font("Yu Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fullName.Location = New System.Drawing.Point(90, 142)
        Me.fullName.Name = "fullName"
        Me.fullName.Size = New System.Drawing.Size(258, 33)
        Me.fullName.TabIndex = 3
        '
        'FileSystemWatcher1
        '
        Me.FileSystemWatcher1.EnableRaisingEvents = True
        Me.FileSystemWatcher1.SynchronizingObject = Me
        '
        'email
        '
        Me.email.Font = New System.Drawing.Font("Yu Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.email.Location = New System.Drawing.Point(90, 202)
        Me.email.Name = "email"
        Me.email.Size = New System.Drawing.Size(258, 33)
        Me.email.TabIndex = 3
        '
        'password
        '
        Me.password.Font = New System.Drawing.Font("Yu Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.password.Location = New System.Drawing.Point(90, 254)
        Me.password.Name = "password"
        Me.password.Size = New System.Drawing.Size(258, 33)
        Me.password.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label3.Font = New System.Drawing.Font("Yu Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.InfoText
        Me.Label3.Location = New System.Drawing.Point(88, 178)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 16)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "FULL NAME"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label4.Font = New System.Drawing.Font("Yu Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.InfoText
        Me.Label4.Location = New System.Drawing.Point(87, 236)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 16)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "EMAIL"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label5.Font = New System.Drawing.Font("Yu Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.InfoText
        Me.Label5.Location = New System.Drawing.Point(87, 290)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 16)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "PASSWORD"
        '
        'contactNumber
        '
        Me.contactNumber.Font = New System.Drawing.Font("Yu Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.contactNumber.Location = New System.Drawing.Point(90, 309)
        Me.contactNumber.Name = "contactNumber"
        Me.contactNumber.Size = New System.Drawing.Size(258, 33)
        Me.contactNumber.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label6.Font = New System.Drawing.Font("Yu Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.InfoText
        Me.Label6.Location = New System.Drawing.Point(87, 345)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(120, 16)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "CONTACT NUMBER"
        '
        'address
        '
        Me.address.Font = New System.Drawing.Font("Yu Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.address.Location = New System.Drawing.Point(90, 364)
        Me.address.Name = "address"
        Me.address.Size = New System.Drawing.Size(258, 33)
        Me.address.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label7.Font = New System.Drawing.Font("Yu Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.InfoText
        Me.Label7.Location = New System.Drawing.Point(87, 400)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(188, 16)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "ADDRESS/DELIVERY ADDRESS"
        '
        'createAccountBtn
        '
        Me.createAccountBtn.BackColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(51, Byte), Integer))
        Me.createAccountBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.createAccountBtn.Font = New System.Drawing.Font("Microsoft Himalaya", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.createAccountBtn.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.createAccountBtn.Location = New System.Drawing.Point(90, 419)
        Me.createAccountBtn.Name = "createAccountBtn"
        Me.createAccountBtn.Size = New System.Drawing.Size(258, 57)
        Me.createAccountBtn.TabIndex = 4
        Me.createAccountBtn.Text = "CREATE ACCOUNT"
        Me.createAccountBtn.UseVisualStyleBackColor = False
        '
        'login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(451, 578)
        Me.Controls.Add(Me.signIn_panel)
        Me.Controls.Add(Me.createAccountBtn)
        Me.Controls.Add(Me.address)
        Me.Controls.Add(Me.contactNumber)
        Me.Controls.Add(Me.password)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.email)
        Me.Controls.Add(Me.fullName)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.createAccLabel)
        Me.Controls.Add(Me.signInText)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "login"
        Me.signIn_panel.ResumeLayout(False)
        Me.signIn_panel.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FileSystemWatcher1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents signInText As Label
    Friend WithEvents createAccLabel As Label
    Friend WithEvents signIn_panel As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents signInBtn As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents passwordLogin As TextBox
    Friend WithEvents emailLogin As TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents fullName As TextBox
    Friend WithEvents FileSystemWatcher1 As IO.FileSystemWatcher
    Friend WithEvents password As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents email As TextBox
    Friend WithEvents contactNumber As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents createAccountBtn As Button
    Friend WithEvents address As TextBox
    Friend WithEvents Label7 As Label
End Class
