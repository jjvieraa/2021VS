Imports MySql.Data.MySqlClient
Module connection
    Public con As MySqlConnection = connect()
    Public cmd As New MySqlCommand
    Public da As New MySqlDataAdapter
    Public dt As New DataTable
    Public result As Integer
    Public sql As String

    Public reportselect As String
    Public reportname As String
    Public rptname As String

    Public Function connect() As MySqlConnection
        Return New MySqlConnection("server = localhost; user=root; database=rvempire_db")
    End Function
End Module
