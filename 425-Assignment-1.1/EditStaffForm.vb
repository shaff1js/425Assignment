Imports System.Security.Cryptography
Imports System.Text
Imports System.IO

Public Class EditStaffForm
    Dim DB As New DBAccessClass
    Private Sub EditStaffForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ActiveString As String

        'clear out the picture box
        StaffPictureBox.Image = Nothing
        'load the page with the information from the selected row
        StaffIDTextBox.Text = StaffInfoForm.StaffIDString

        'perform query to add the information to the field
        'changing password will be handled by a seperate form since I am unable to unencrypt the password.

        'add params for query
        DB.AddParam("@Staff_ID", StaffIDTextBox.Text)

        'full query to be used
        DB.ExecuteQuery("SELECT first_name, last_name, address_id, picture, email, store_id, active, username from staff where staff_id like ?")

        'load information from query onto page
        FirstNameTextBox.Text = DB.DBDataTable.Rows(0).Item("first_name").ToString
        LastNameTextBox.Text = DB.DBDataTable.Rows(0).Item("last_name").ToString
        AddressIDTextBox.Text = DB.DBDataTable.Rows(0).Item("address_id").ToString
        EmailTextBox.Text = DB.DBDataTable.Rows(0).Item("email").ToString
        StoreIDTextBox.Text = DB.DBDataTable.Rows(0).Item("store_id").ToString
        'load active checkbox
        ActiveString = DB.DBDataTable.Rows(0).Item("active").ToString
        If ActiveString = "1" Then
            ActiveCheckBox.Checked = True
        Else
            ActiveCheckBox.Checked = False
        End If
        UserNameTextBox.Text = DB.DBDataTable.Rows(0).Item("username").ToString

        'insert picture into form
        Try

            Dim bytBLOBData() As Byte = DB.DBDataTable.Rows(0).Item("picture")
                Dim stmBLOBData As New MemoryStream(bytBLOBData)

            StaffPictureBox.Image = Image.FromStream(stmBLOBData)

        Catch ex As Exception
            StaffPictureBox.Image = Nothing
        End Try

    End Sub


    Private Sub BrowseButton_Click(sender As Object, e As EventArgs) Handles BrowseButton.Click
        'display image
        Dim ImageRoutine As New ImageRoutinesClass
        ImageRoutine.LoadImage(StaffPictureBox)

    End Sub
    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
        'declare variables
        Dim FirstNameString, LastNameString, AddressIDString, EmailString, StoreIDString, ActiveString, UsernameString As String
        Dim AddressIDInteger, StoreIDInteger As Integer
        Dim ms As New MemoryStream

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

        'code image to be saved
        If Not StaffPictureBox.Image Is Nothing Then

            StaffPictureBox.Image.Save(ms, StaffPictureBox.Image.RawFormat)
        End If

        'define parameters
        If StaffPictureBox.Image IsNot Nothing Then

            DB.AddParam("@first_name", FirstNameString)
            DB.AddParam("last_name", LastNameString)
            DB.AddParam("@address_id", AddressIDString)
            DB.AddParam("@picture", ms.ToArray())
            DB.AddParam("@email", EmailString)
            DB.AddParam("@store_id", StoreIDString)
            DB.AddParam("@active", ActiveString)
            DB.AddParam("@username", UsernameString)
            DB.AddParam("@staff_id", StaffIDTextBox.Text)

            'modify edited statement
            DB.ExecuteQuery("UPDATE Staff SET first_name = ?, last_name = ?, address_id = ?, picture = ?, email = ?, store_id = ?, active = ?, username = ? WHERE staff_id LIKE ?")
        Else
            DB.AddParam("@first_name", FirstNameString)
            DB.AddParam("last_name", LastNameString)
            DB.AddParam("@address_id", AddressIDString)
            DB.AddParam("@email", EmailString)
            DB.AddParam("@store_id", StoreIDString)
            DB.AddParam("@active", ActiveString)
            DB.AddParam("@username", UsernameString)
            DB.AddParam("@staff_id", StaffIDTextBox.Text)

            'modify edited statement
            DB.ExecuteQuery("UPDATE Staff SET first_name = ?, last_name = ?, address_id = ?, email = ?, store_id = ?, active = ?, username = ? WHERE staff_id LIKE ?")
        End If
        If Not String.IsNullOrEmpty(DB.Exception) Then
            MessageBox.Show(DB.Exception)
            Exit Sub
        End If

        'display message showing successful edit
        MessageBox.Show("You have successfully modified the record.", "New Staff Member Created", MessageBoxButtons.OK, MessageBoxIcon.Information)

        'set all areas to read only and disable save button
        FirstNameTextBox.ReadOnly = True
        LastNameTextBox.ReadOnly = True
        AddressIDTextBox.ReadOnly = True
        BrowseButton.Enabled = False
        EmailTextBox.ReadOnly = True
        StoreIDTextBox.ReadOnly = True
        ActiveCheckBox.Enabled = False
        UserNameTextBox.ReadOnly = True
        SaveButton.Enabled = False
        StaffPictureBox.Image = Nothing


        'close the form
        Me.Close()
    End Sub

    Private Sub EditButton_Click(sender As Object, e As EventArgs) Handles EditButton.Click

        'open textboxes to be edited and enable to save button
        FirstNameTextBox.ReadOnly = False
        LastNameTextBox.ReadOnly = False
        AddressIDTextBox.ReadOnly = False
        BrowseButton.Enabled = True
        EmailTextBox.ReadOnly = False
        StoreIDTextBox.ReadOnly = False
        ActiveCheckBox.Enabled = True
        UserNameTextBox.ReadOnly = False
        SaveButton.Enabled = True

    End Sub

    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles CancelButton.Click
        'set all areas to read only
        FirstNameTextBox.ReadOnly = True
        LastNameTextBox.ReadOnly = True
        AddressIDTextBox.ReadOnly = True
        BrowseButton.Enabled = False
        EmailTextBox.ReadOnly = True
        StoreIDTextBox.ReadOnly = True
        ActiveCheckBox.Enabled = False
        UserNameTextBox.ReadOnly = True
        SaveButton.Enabled = False
        StaffPictureBox.Image = Nothing

        'close the form
        Me.Close()
    End Sub

    Private Sub ChangePasswordButton_Click(sender As Object, e As EventArgs) Handles ChangePasswordButton.Click
        StaffInfoForm.StaffIDString = StaffIDTextBox.Text

        ChangePasswordForm.Show()
    End Sub
End Class