Imports MySql.Data.MySqlClient

Public Class UserManagementForm

    Private Sub UserManagementForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set form properties
        Me.Text = "User Management"
        Me.StartPosition = FormStartPosition.CenterParent
        Me.FormBorderStyle = FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False

        ' Load users when form opens
        LoadUsersToGrid()
    End Sub

    ' Load users into the DataGridView
    Private Sub LoadUsersToGrid()
        Dim query As String = "
            SELECT 
                user_id AS 'User ID',
                username AS 'Username'
            FROM users
            ORDER BY user_id ASC
        "

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()
                Dim adapter As New MySqlDataAdapter(query, conn)
                Dim table As New DataTable()
                adapter.Fill(table)

                dgvUsers.DataSource = table
                dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                dgvUsers.ReadOnly = True
                dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect

                ' Hide the User ID column for cleaner look
                dgvUsers.Columns("User ID").Visible = False
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading users: " & ex.Message)
        End Try
    End Sub

    ' Delete selected user
    Private Sub btnDeleteUser_Click(sender As Object, e As EventArgs) Handles btnDeleteUser.Click
        ' Check if a user is selected
        If dgvUsers.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a user to delete.")
            Return
        End If

        Dim selectedRow As DataGridViewRow = dgvUsers.SelectedRows(0)
        Dim userId As Integer = Convert.ToInt32(selectedRow.Cells("User ID").Value)
        Dim username As String = selectedRow.Cells("Username").Value.ToString()

        ' Confirm deletion
        Dim result As DialogResult = MessageBox.Show(
            $"Are you sure you want to delete user '{username}'?{vbCrLf}This action cannot be undone.",
            "Confirm Deletion",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning)

        If result = DialogResult.No Then
            Return
        End If

        Try
            Using conn As New MySqlConnection(connectionString)
                conn.Open()

                ' Check if this is the last user (safety check)
                Dim countCmd As New MySqlCommand("SELECT COUNT(*) FROM users", conn)
                Dim userCount As Integer = Convert.ToInt32(countCmd.ExecuteScalar())

                If userCount <= 1 Then
                    MessageBox.Show("Cannot delete the last admin user.")
                    Return
                End If

                ' Delete the user
                Dim deleteCmd As New MySqlCommand("DELETE FROM users WHERE user_id = @userId", conn)
                deleteCmd.Parameters.AddWithValue("@userId", userId)

                Dim rowsAffected As Integer = deleteCmd.ExecuteNonQuery()

                If rowsAffected > 0 Then
                    MessageBox.Show($"User '{username}' has been deleted successfully.")
                    ' Auto-refresh the grid immediately after successful deletion
                    LoadUsersToGrid()
                Else
                    MessageBox.Show("Failed to delete user.")
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error deleting user: " & ex.Message)
        End Try
    End Sub




End Class

