Imports MySql.Data.MySqlClient
Module update
    Public con As MySqlConnection = connect()
    Public cmd As New MySqlCommand
    Public da As New MySqlDataAdapter
    Public dt As New DataTable
    Public result As Integer
    Public sql As String

#Region "update user"
    Public Sub updateuser()
        Try
            con.Open()
            sql = "UPDATE `rvempire_db`.`tbluser` SET `fname` = '" & frmadmin.TextBox28.Text & "', `lname` = '" & frmadmin.TextBox27.Text & "', `address` = '" & frmadmin.TextBox20.Text & "', `contact` = '" & frmadmin.TextBox19.Text & "', `role` = '" & frmadmin.ComboBox3.Text & "', `uname` = '" & frmadmin.TextBox18.Text & "', `pword` = '" & frmadmin.TextBox16.Text & "' WHERE `tbluser`.`userid` = '" & frmadmin.id & "'"
            With cmd
                .Connection = con
                .CommandText = sql
            End With
            result = cmd.ExecuteNonQuery
            If result > 0 Then
                MsgBox("New User has been Updated!")
            Else
                MsgBox("No User update!")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
#End Region

#Region "update supplier"
    Public Sub updatesupplier()
        Try
            con.Open()
            sql = "UPDATE `rvempire_db`.`tblsupplier` SET `cname` = '" & frmadmin.TextBox9.Text & "', `contact` = '" & frmadmin.TextBox6.Text & "', `address` = '" & frmadmin.TextBox5.Text & "', `email` = '" & frmadmin.TextBox4.Text & "' WHERE `tblsupplier`.`suppid` = '" & frmadmin.id & "'"
            With cmd
                .Connection = con
                .CommandText = sql
            End With
            result = cmd.ExecuteNonQuery
            If result > 0 Then
                MsgBox("New Supplier has been Updated!")
            Else
                MsgBox("No Supplier update!")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
#End Region

#Region "update shipment to save item"
    Public Sub updateshipment()
        Try
            con.Open()
            sql = "UPDATE `rvempire_db`.`tblshipment` SET `date` = '" & frmadmin.Label2.Text & "' WHERE `tblshipment`.`suppid` = '" & frmadmin.TextBox59.Text & "'"
            With cmd
                .Connection = con
                .CommandText = sql
            End With
            result = cmd.ExecuteNonQuery
            If result > 0 Then

            Else

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
#End Region
End Module
