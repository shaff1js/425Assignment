
Imports System.Data.Odbc
Public Class DBAccessClass
    Private DBCommand As OdbcCommand
    Private Const ConnectString As String = "Driver={MySQL ODBC 5.3 ANSI Driver};SERVER=141.209.241.47;DATABASE=sakila;USER=bis425c2g3;PASSWORD=firstpass"
    Private DBConnection As New OdbcConnection(ConnectString)
    Public DBDataAdapter As OdbcDataAdapter
    Public DBDataTable As DataTable
    Public Params As New List(Of OdbcParameter)
    Public RecordCount As Integer
    Public Exception As String

    Public Sub ExecuteQuery(QueryString As String)
        RecordCount = 0
        Exception = String.Empty

        Try
            DBConnection.Open()

            DBCommand = New OdbcCommand(QueryString, DBConnection)

            For Each p As OdbcParameter In Params
                DBCommand.Parameters.Add(p)
            Next


            Params.Clear()

            DBDataTable = New DataTable
            DBDataAdapter = New OdbcDataAdapter(DBCommand)

            RecordCount = DBDataAdapter.Fill(DBDataTable)
        Catch ex As Exception
            Exception = ex.Message
        End Try

        If DBConnection.State = ConnectionState.Open Then
            DBConnection.Close()
        End If
    End Sub

    Public Sub AddParam(Name As String, value As Object)
        Dim NewParam As New OdbcParameter(Name, value)
        Params.Add(NewParam)
    End Sub
End Class
