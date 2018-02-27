Public Class Assignment2Form
    Dim PostalCodeInteger As Integer
    Dim LastNameString As String
    Private DB As New DBAccessClass
    Private Sub dgv_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles CustomerAddressDataGridView.DataError

    End Sub

    Private Sub Retrieve_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'initial load of the table

        DB.ExecuteQuery("SELECT customer_id, store_id, first_name, last_name, email, create_date, c.last_update as customer_last_update, a.address_id, address, district, city_id, postal_code, phone, a.last_update as address_last_update FROM customer c left join address a on c.address_id = a.address_id")

        If DB.Exception <> String.Empty Then
            MessageBox.Show(DB.Exception)
        End If

        CustomerAddressDataGridView.DataSource = DB.DBDataTable
        CustomerAddressDataGridView.ReadOnly = True

    End Sub

    Private Sub LastNameTextBox_GotFocus(sender As Object, e As EventArgs) Handles LastNameTextBox.GotFocus
        'Clear first name information

        PostalCodeTextBox.Clear()
        'PostalCodeInteger = 

        'loading table after clearing filters
        DB.ExecuteQuery("SELECT customer_id, store_id, first_name, last_name, email, create_date, c.last_update as customer_last_update, a.address_id, address, district, city_id, postal_code, phone, a.last_update as address_last_update FROM customer c left join address a on c.address_id = a.address_id")
        If DB.Exception <> String.Empty Then
            MessageBox.Show(DB.Exception)
        End If

        CustomerAddressDataGridView.DataSource = DB.DBDataTable
        CustomerAddressDataGridView.ReadOnly = True
    End Sub


    Private Sub PostalCodeTextbox_TextChanged(sender As Object, e As EventArgs) Handles PostalCodeTextBox.TextChanged
        'edit last name string to be used in database string

        ' PostalCodeInteger = Integer.Parse(PostalCodeTextBox.Text)

        If PostalCodeTextBox.Text = "" Then
            Exit Sub
        Else
            DB.AddParam("@address.postal_code", PostalCodeTextBox.Text & "%")
            'exculde location
            DB.ExecuteQuery("SELECT customer_id, store_id, first_name, last_name, email, create_date, c.last_update as customer_last_update, a.address_id, address, district, city_id, postal_code, phone, a.last_update as address_last_update FROM customer c left join address a on c.address_id = a.address_id where a.postal_code like ?")
            'load the table with the filtered information
            If DB.Exception <> String.Empty Then
            MessageBox.Show(DB.Exception)
        End If

        CustomerAddressDataGridView.DataSource = DB.DBDataTable
        CustomerAddressDataGridView.ReadOnly = True
    End If

    End Sub

    Private Sub PostalCodeTextBox_GotFocus(sender As Object, e As EventArgs) Handles PostalCodeTextBox.GotFocus
        'Clear first name information

        LastNameTextBox.Clear()
        LastNameString = ""

        'loading table after clearing filters
        DB.ExecuteQuery("SELECT customer_id, store_id, first_name, last_name, email, create_date, c.last_update as customer_last_update, a.address_id, address, district, city_id, postal_code, phone, a.last_update as address_last_update FROM customer c left join address a on c.address_id = a.address_id")
        If DB.Exception <> String.Empty Then
            MessageBox.Show(DB.Exception)
        End If

        CustomerAddressDataGridView.DataSource = DB.DBDataTable
        CustomerAddressDataGridView.ReadOnly = True
    End Sub


    Private Sub LastNameTextbox_TextChanged(sender As Object, e As EventArgs) Handles LastNameTextBox.TextChanged
        'edit last name string to be used in database string

        LastNameString = LastNameTextBox.Text

        DB.AddParam("@customer.last_name", LastNameString & "%")

        DB.ExecuteQuery("SELECT customer_id, store_id, first_name, last_name, email, create_date, c.last_update as customer_last_update, a.address_id, address, district, city_id, postal_code, phone, a.last_update as address_last_update FROM customer c left join address a on c.address_id = a.address_id where last_name like ?")
        'load the table with the filtered information
        If DB.Exception <> String.Empty Then
            MessageBox.Show(DB.Exception)
        End If

        CustomerAddressDataGridView.DataSource = DB.DBDataTable
        CustomerAddressDataGridView.ReadOnly = True
    End Sub
End Class