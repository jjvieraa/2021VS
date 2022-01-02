Imports MySql.Data.MySqlClient
Module delete
    Public con As MySqlConnection = connect()
    Public cmd As New MySqlCommand
    Public da As New MySqlDataAdapter
    Public dt As New DataTable
    Public result As Integer
    Public sql As String

    Public Sub deleteuser()
        dt = New DataTable
        Try
            con.Open()
            sql = "Delete from `tbluser` WHERE `tbluser`.`userid` = '" & frmadmin.id & "'"
            With cmd
                .Connection = con
                .CommandText = sql
            End With
            result = cmd.ExecuteNonQuery
            If result > 0 Then
                MsgBox("User record has been deleted!")
            Else
                MsgBox("No User record delete!")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try

    End Sub


    Public Sub deletesupplier()
        dt = New DataTable
        Try
            con.Open()
            sql = "Delete from `tblsupplier` WHERE `tblsupplier`.`suppid` = '" & frmadmin.id & "'"
            With cmd
                .Connection = con
                .CommandText = sql
            End With
            result = cmd.ExecuteNonQuery
            If result > 0 Then
                MsgBox("User record has been deleted!")
            Else
                MsgBox("No Supplier record delete!")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

End Module
