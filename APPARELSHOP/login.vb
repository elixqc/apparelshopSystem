Imports System.Drawing
Imports System.Windows.Forms
Imports MySql.Data.MySqlClient
Public Class login

    Dim conn As New MySqlConnection("server=localhost;userid=root;password=;database=apparelshopdb")


    Private Sub login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'asterisk password
        password.UseSystemPasswordChar = True

        'disabling autofocus on textbox when opening tabs
        For Each ctrl As Control In Me.Controls
            ctrl.TabStop = False
        Next

        ' Re-enable after form is shown
        AddHandler Me.Shown, Sub()
                                 For Each ctrl As Control In Me.Controls
                                     ctrl.TabStop = True
                                 Next
                                 Me.ActiveControl = Nothing
                             End Sub

        'adding animations on hover labels
        appthemes.ApplyLabelHover(signInText)
        appthemes.ApplyLabelHover(createAccLabel)
        appthemes.ApplyLabelHover(Label2)
        Me.DoubleBuffered = True

        passwordLogin.Text = "PASSWORD"
        passwordLogin.ForeColor = SystemColors.GrayText
        passwordLogin.PasswordChar = ControlChars.NullChar

    End Sub



    Private Sub emailText_Enter(sender As Object, e As EventArgs) Handles emailLogin.Enter
        If emailLogin.Text = "EMAIL ADDRESS" Then
            emailLogin.Text = ""
            emailLogin.ForeColor = Color.Black ' Change back to normal color
        End If
    End Sub

    Private Sub emailText_Leave(sender As Object, e As EventArgs) Handles emailLogin.Leave
        If String.IsNullOrWhiteSpace(emailLogin.Text) Then
            emailLogin.Text = "EMAIL ADDRESS"
            emailLogin.ForeColor = Color.Gray ' Make it look like a placeholder
        End If
    End Sub

    Private Sub passwordText_Enter(sender As Object, e As EventArgs) Handles passwordLogin.Enter
        ' Clear placeholder if needed
        If passwordLogin.Text = "PASSWORD" Then
            passwordLogin.Text = ""
            passwordLogin.ForeColor = SystemColors.WindowText
        End If

        ' Show actual characters while typing
        passwordLogin.PasswordChar = ControlChars.NullChar
    End Sub

    Private Sub passwordText_Leave(sender As Object, e As EventArgs) Handles passwordLogin.Leave
        ' Apply password effect if there's text
        If Not String.IsNullOrEmpty(passwordLogin.Text) Then
            passwordLogin.PasswordChar = "*"c
        Else
            ' Show placeholder if empty
            passwordLogin.Text = "PASSWORD"
            passwordLogin.ForeColor = SystemColors.GrayText
            passwordLogin.PasswordChar = ControlChars.NullChar
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        appthemes.FadeOutForm(Me)
    End Sub

    Private Sub signInText_Click(sender As Object, e As EventArgs) Handles signInText.Click
        signIn_panel.Show()
    End Sub
    Private Sub createAccLabel_Click(sender As Object, e As EventArgs) Handles createAccLabel.Click, Label1.Click
        signIn_panel.Hide()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        signIn_panel.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles createAccountBtn.Click
        Try
            conn.Open()

            ' Hash password using SHA2 (256)
            Dim cmd As New MySqlCommand("INSERT INTO customers (full_name, contact_number, address, email, password) 
                                     VALUES (@full_name, @contact_number, @address, @email, SHA2(@password, 256))", conn)
            cmd.Parameters.AddWithValue("@full_name", fullName.Text.Trim())
            cmd.Parameters.AddWithValue("@contact_number", contactNumber.Text.Trim())
            cmd.Parameters.AddWithValue("@address", address.Text.Trim())
            cmd.Parameters.AddWithValue("@email", email.Text.Trim())
            cmd.Parameters.AddWithValue("@password", password.Text.Trim())

            cmd.ExecuteNonQuery()
            MsgBox("User Created!! Please Proceed to Login")

            fullName.Text = ""
            contactNumber.Text = ""
            address.Text = ""
            email.Text = ""
            password.Text = ""

        Catch ex As MySqlException
            MsgBox("MySQL Error: " & ex.Message)
        Catch ex As Exception
            MsgBox("An error occurred: " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub

    Private Sub signInBtn_Click(sender As Object, e As EventArgs) Handles signInBtn.Click



        Try
            conn.Open()
            Dim foundUser As Boolean = False

            ' Try logging in as ADMIN
            Dim adminCmd As New MySqlCommand("SELECT user_id, username FROM users WHERE username = @username AND password = SHA2(@password, 256)", conn)
            adminCmd.Parameters.AddWithValue("@username", emailLogin.Text.Trim())
            adminCmd.Parameters.AddWithValue("@password", passwordLogin.Text.Trim())

            Dim reader As MySqlDataReader = adminCmd.ExecuteReader()

            If reader.Read() Then
                ' Admin login successful
                loggedInUserID = reader.GetInt32("user_id")
                loggedInUserFullName = reader.GetString("username")
                Dim firstName As String = loggedInUserFullName.Split(" "c)(0)
                reader.Close()

                MsgBox("Admin login successful!")

                Form1.Show()
                Form1.welcomeName.Text = "Welcome Admin, " & firstName
                Form1.welcomeName.Visible = True
                Me.Hide()
                foundUser = True

                emailLogin.Text = ""
                passwordLogin.Text = ""
            Else
                reader.Close()
            End If

            ' Try customer login only if admin not found
            If Not foundUser Then
                Try

                    Dim cmd As New MySqlCommand("SELECT customer_id, full_name FROM customers WHERE email = @email AND password = SHA2(@password, 256)", conn)
                    cmd.Parameters.AddWithValue("@email", emailLogin.Text.Trim())
                    cmd.Parameters.AddWithValue("@password", passwordLogin.Text.Trim())

                    Dim custReader As MySqlDataReader = cmd.ExecuteReader()

                    If custReader.Read() Then
                        loggedInUserID = custReader.GetInt32("customer_id")
                        loggedInUserEmail = emailLogin.Text.Trim()
                        loggedInUserFullName = custReader.GetString("full_name")
                        Dim firstName As String = loggedInUserFullName.Split(" "c)(0)

                        MsgBox("Login successful!")

                        Form1.Show()
                        Form1.welcomeName.Visible = True
                        Form1.welcomeName.Text = "Welcome, " & firstName
                        Me.Hide()
                        emailLogin.Text = ""
                        passwordLogin.Text = ""
                    Else
                        MsgBox("Invalid email or password.")
                    End If

                    custReader.Close()
                Catch ex As Exception
                    MsgBox("Error during customer login: " & ex.Message)
                Finally
                    conn.Close()
                End Try
            End If

        Catch ex As Exception
            MsgBox("Error during admin login: " & ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then conn.Close()
        End Try
    End Sub

    Private Sub emailLogin_TextChanged(sender As Object, e As EventArgs) Handles emailLogin.TextChanged

    End Sub
End Class