Public Class StaffInfoForm
    Dim FirstNameString, LastNameString As String
    Public StaffIDString As String
    Private DB As New DBAccessClass

    Private Sub dgv_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles StaffInfoDataGridView.DataError

    End Sub

    Private Sub Retrieve_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        'initial loading of table. 
        DB.ExecuteQuery("Select * from staff")
        If DB.Exception <> String.Empty Then
            MessageBox.Show(DB.Exception)
        End If

        StaffInfoDataGridView.DataSource = DB.DBDataTable
        StaffInfoDataGridView.ReadOnly = True

    End Sub
    Private Sub FirstNameTextBox_GotFocus(sender As Object, e As EventArgs) Handles FirstNameTextBox.GotFocus
        'clear last name information
        LastNameTextBox.Clear()
        LastNameString = ""

        'reload table after clearing filters
        DB.ExecuteQuery("Select * from staff")
        If DB.Exception <> String.Empty Then
            MessageBox.Show(DB.Exception)
        End If

        StaffInfoDataGridView.DataSource = DB.DBDataTable
        StaffInfoDataGridView.ReadOnly = True
    End Sub
    Private Sub FirstNameTextBox_TextChanged(sender As Object, e As EventArgs) Handles FirstNameTextBox.TextChanged
        'edit first name sting and search database

        FirstNameString = FirstNameTextBox.Text

        'search database using the first name
        'order by first name?
        DB.AddParam("@first_name", FirstNameString & "%")

        DB.ExecuteQuery("Select * from staff where first_name LIKE ?")
        'load the table with the filtered information
        If DB.Exception <> String.Empty Then
            MessageBox.Show(DB.Exception)
        End If

        StaffInfoDataGridView.DataSource = DB.DBDataTable
        StaffInfoDataGridView.ReadOnly = True
    End Sub
    Private Sub LastNameTextBox_GotFocus(sender As Object, e As EventArgs) Handles LastNameTextBox.GotFocus
        'Clear first name information

        FirstNameTextBox.Clear()
        FirstNameString = ""

        'loading table after clearing filters
        DB.ExecuteQuery("Select * from staff")
        If DB.Exception <> String.Empty Then
            MessageBox.Show(DB.Exception)
        End If

        StaffInfoDataGridView.DataSource = DB.DBDataTable
        StaffInfoDataGridView.ReadOnly = True
    End Sub

    Private Sub NewStaffToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewStaffToolStripMenuItem.Click
        'display the new staff form
        NewStaffForm.ShowDialog()
    End Sub

    Private Sub StaffInfoDataGridView_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles StaffInfoDataGridView.CellDoubleClick
        'Load staff id from selected record into the staffidstring
        If e.RowIndex > -1 Then
            StaffIDString = StaffInfoDataGridView.Rows(e.RowIndex).Cells(0).Value()
        End If

        'open edit staff form
        EditStaffForm.ShowDialog()
    End Sub

    Private Sub EditToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles EditCustomerToolStripMenuItem.Click
        'Load staff id from selected record into the staffidstring
        StaffIDString = StaffInfoDataGridView.Rows(StaffInfoDataGridView.CurrentRow.Index).Cells(0).Value()

        'open edit staff form
        EditStaffForm.ShowDialog()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteCustomerToolStripMenuItem.Click
        Dim DialogBoxResult As DialogResult

        'Load staff id from selected record into the staffidstring
        StaffIDString = StaffInfoDataGridView.Rows(StaffInfoDataGridView.CurrentRow.Index).Cells(0).Value()

        'declare parameters
        DB.AddParam("@staff_id", StaffIDString)

        DialogBoxResult = MessageBox.Show("Are you sure that you want to delete this record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2)
        If DialogBoxResult = DialogResult.Yes Then
            DB.ExecuteQuery("DELETE from Staff where staff_id LIKE ?")
            MessageBox.Show("Record was deleted", "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Information)
            FirstNameTextBox.Clear()
            With LastNameTextBox
                .Clear()
                .Focus()
            End With
        Else
            Exit Sub
        End If
    End Sub

    Private Sub StaffInfoDataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles StaffInfoDataGridView.CellClick
        'enable the edit options
        If e.RowIndex < 0 Or e.ColumnIndex < 0 Or e.RowIndex = StaffInfoDataGridView.RowCount - 1 Then
            EditCustomerToolStripMenuItem.Enabled = False
            DeleteCustomerToolStripMenuItem.Enabled = False
            Exit Sub
        End If

        EditCustomerToolStripMenuItem.Enabled = True
        DeleteCustomerToolStripMenuItem.Enabled = True

    End Sub

    Private Sub LastNameTextbox_TextChanged(sender As Object, e As EventArgs) Handles LastNameTextBox.TextChanged
        'edit last name string to be used in database string

        LastNameString = LastNameTextBox.Text

        DB.AddParam("@last_name", LastNameString & "%")

        DB.ExecuteQuery("Select * from staff where last_name LIKE ?")
        'load the table with the filtered information
        If DB.Exception <> String.Empty Then
            MessageBox.Show(DB.Exception)
        End If

        StaffInfoDataGridView.DataSource = DB.DBDataTable
        StaffInfoDataGridView.ReadOnly = True
    End Sub


End Class
