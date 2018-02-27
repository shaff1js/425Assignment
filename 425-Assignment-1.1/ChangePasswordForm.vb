Imports System.Security.Cryptography
Imports System.Text
Public Class ChangePasswordForm
    Dim db As New DBAccessClass
    Dim CurrentPasswordString, NewPasswordString, ConfirmPasswordString As String
    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
        'declare variables

        Dim PasswordCheckInteger As Integer

        'perfrom validations for current password, new password and confirm password
        If CurrentPasswordTextBox.Text = "" Then
            MessageBox.Show("Please enter your current password.", "Update Password", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If NewPasswordTextBox.Text = "" Then
            MessageBox.Show("Please enter your new password.", "Update Password", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If ConfirmPasswordTextBox.Text = "" Then
            MessageBox.Show("Please confirm your new password.", "Update Password", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        'fill strings
        CurrentPasswordString = CurrentPasswordTextBox.Text
        NewPasswordString = NewPasswordTextBox.Text
        ConfirmPasswordString = ConfirmPasswordTextBox.Text

        'check to make sure that new password and confirm password are the same
        If NewPasswordString = ConfirmPasswordString Then
            'declare encryption variables
            Dim bytHashedData As Byte()
            Dim encoder As New UTF8Encoding()
            Dim md5Hasher As New MD5CryptoServiceProvider

            'encrypt password
            bytHashedData = md5Hasher.ComputeHash(encoder.GetBytes(CurrentPasswordString))

            'define parameters
            db.AddParam("@staff_id", StaffInfoForm.StaffIDString)
            db.AddParam("password", bytHashedData)

            'execute query to check password against password on database
            db.ExecuteQuery("Select count(*) from staff where staff_id like ? and password like ?")

            PasswordCheckInteger = db.DBDataTable.Rows(0).Item(0)

            If PasswordCheckInteger > 0 Then
                'encrypt new password
                bytHashedData = md5Hasher.ComputeHash(encoder.GetBytes(NewPasswordString))

                'define parameters
                db.AddParam("password", bytHashedData)
                db.AddParam("@staff_id", StaffInfoForm.StaffIDString)

                'run update query
                db.ExecuteQuery("UPDATE staff SET password = ? where staff_id = ?")

                'display message showing successful query
                MessageBox.Show("You have successfully updated your password", "Update Password", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                'clear and close form after successful change
                CurrentPasswordTextBox.Clear()
                NewPasswordTextBox.Clear()
                ConfirmPasswordTextBox.Clear()
                CurrentPasswordString = ""
                NewPasswordString = ""
                ConfirmPasswordString = ""
                Me.Close()
            Else
                MessageBox.Show("Your password does not match the one on record.", "Incorrect Password", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        Else
            MessageBox.Show("Your new password does not match the confirm new password.", "Update Password", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

    End Sub

    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles CancelButton.Click
        'cancel the change password
        CurrentPasswordTextBox.Clear()
        NewPasswordTextBox.Clear()
        ConfirmPasswordTextBox.Clear()
        CurrentPasswordString = ""
        NewPasswordString = ""
        ConfirmPasswordString = ""
        Me.Close()
    End Sub
End Class