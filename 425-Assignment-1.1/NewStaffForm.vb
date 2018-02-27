Imports System.Security.Cryptography
Imports System.Text
Imports System.IO

Public Class NewStaffForm
    Dim DB As New DBAccessClass
    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
        'declare variables
        Dim FirstNameString, LastNameString, AddressIDString, EmailString, StoreIDString, ActiveString, UsernameString, PasswordString As String
        Dim AddressIDInteger, StoreIDInteger As Integer
        Dim ms As New MemoryStream

        'declare encryption variables
        Dim bytHashedData As Byte()
        Dim encoder As New UTF8Encoding()
        Dim md5Hasher As New MD5CryptoServiceProvider

        'fill strings
        FirstNameString = FirstNameTextBox.Text
        LastNameString = LastNameTextBox.Text
        AddressIDString = AddressIDTextBox.Text
        EmailString = EmailTextBox.Text
        StoreIDString = StoreIDTextBox.Text
        If ActiveCheckBox.Checked Then
            ActiveString = 1
        Else
            ActiveString = 0
        End If
        UsernameString = UserNameTextBox.Text
        PasswordString = PasswordTextBox.Text

        'perform validations
        If FirstNameTextBox.Text = "" Then
            MessageBox.Show("Please enter your first name.", "Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If LastNameTextBox.Text = "" Then
            MessageBox.Show("Please enter your last name.", "Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If AddressIDTextBox.Text = "" Then
            MessageBox.Show("Please enter your address ID.", "Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If StoreIDTextBox.Text = "" Then
            MessageBox.Show("Please enter your store ID.", "Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        If UserNameTextBox.Text = "" Then
            MessageBox.Show("Please enter your user name.", "Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        Try
            AddressIDInteger = Integer.Parse(AddressIDString)
        Catch ex As Exception
            MessageBox.Show("Address ID must be a number between 1 and 600.", "Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        If AddressIDInteger < 1 Or AddressIDInteger > 600 Then
            MessageBox.Show("Address ID must be a number between 1 and 600.", "Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Try
            StoreIDInteger = Integer.Parse(StoreIDString)
        Catch ex As Exception
            MessageBox.Show("Store ID must be 1 or 2.", "Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        If StoreIDInteger < 1 Or StoreIDInteger > 2 Then
            MessageBox.Show("Store ID must be 1 or 2.", "Data Entry Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        'encrypt password
        bytHashedData = md5Hasher.ComputeHash(encoder.GetBytes(PasswordString))

        'code image to be saved
        If Not StaffPictureBox.Image Is Nothing Then

            StaffPictureBox.Image.Save(ms, StaffPictureBox.Image.RawFormat)
        End If

        'define parameters
        If StaffPictureBox.Image IsNot Nothing Then
            'if no password
            If PasswordTextBox.Text = "" Then
                DB.AddParam("@first_name", FirstNameString)
                DB.AddParam("last_name", LastNameString)
                DB.AddParam("@address_id", AddressIDString)
                DB.AddParam("@picture", ms.ToArray())
                DB.AddParam("@email", EmailString)
                DB.AddParam("@store_id", StoreIDString)
                DB.AddParam("@active", ActiveString)
                DB.AddParam("@username", UsernameString)
                DB.AddParam("@password", "")
            Else

                'if password

                DB.AddParam("@first_name", FirstNameString)
                DB.AddParam("last_name", LastNameString)
                DB.AddParam("@address_id", AddressIDString)
                DB.AddParam("@picture", ms.ToArray())
                DB.AddParam("@email", EmailString)
                DB.AddParam("@store_id", StoreIDString)
                DB.AddParam("@active", ActiveString)
                DB.AddParam("@username", UsernameString)
                DB.AddParam("@password", bytHashedData)
            End If
            'add to database
            DB.ExecuteQuery("INSERT INTO staff (first_name, last_name, address_id, picture, email, store_id, active, username, password) VALUES(?, ?, ?, ?, ?, ?, ?, ?, ?)")
        Else
            'if no password
            If PasswordTextBox.Text = "" Then
                DB.AddParam("@first_name", FirstNameString)
                DB.AddParam("last_name", LastNameString)
                DB.AddParam("@address_id", AddressIDString)
                DB.AddParam("@email", EmailString)
                DB.AddParam("@store_id", StoreIDString)
                DB.AddParam("@active", ActiveString)
                DB.AddParam("@username", UsernameString)
                DB.AddParam("@password", "")
            Else

                'if password

                DB.AddParam("@first_name", FirstNameString)
                DB.AddParam("last_name", LastNameString)
                DB.AddParam("@address_id", AddressIDString)
                DB.AddParam("@email", EmailString)
                DB.AddParam("@store_id", StoreIDString)
                DB.AddParam("@active", ActiveString)
                DB.AddParam("@username", UsernameString)
                DB.AddParam("@password", bytHashedData)
            End If
            'add to database
            DB.ExecuteQuery("INSERT INTO staff (first_name, last_name, address_id, email, store_id, active, username, password) VALUES(?, ?, ?, ?, ?, ?, ?, ?)")
            End If 
            If Not String.IsNullOrEmpty(DB.Exception) Then
                MessageBox.Show(DB.Exception)
                Exit Sub
            End If

            MessageBox.Show("You have successfully added a new staff member.", "New Staff Member Created", MessageBoxButtons.OK, MessageBoxIcon.Information)



        'clear create form after the new staff member is created
        FirstNameString = ""
        LastNameString = ""
        AddressIDString = ""
        ms.SetLength(0)
        EmailString = ""
        StoreIDString = ""
        ActiveString = ""
        UsernameString = ""
        PasswordString = ""

        With FirstNameTextBox
            .Clear()
            .Focus()
        End With
        LastNameTextBox.Clear()
        AddressIDTextBox.Clear()
        StaffPictureBox.Image = Nothing
        EmailTextBox.Clear()
        StoreIDTextBox.Clear()
        ActiveCheckBox.Checked = False
        UserNameTextBox.Clear()
        PasswordTextBox.Clear()

    End Sub

    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles CancelButton.Click
        'close the form
        Me.Close()
    End Sub

    Private Sub BrowseButton_Click(sender As Object, e As EventArgs) Handles BrowseButton.Click
        'display image
        Dim ImageRoutine As New ImageRoutinesClass
        ImageRoutine.LoadImage(StaffPictureBox)

    End Sub
End Class