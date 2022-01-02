Imports MySql.Data.MySqlClient
Module save
    Public con As MySqlConnection = connect()
    Public cmd As New MySqlCommand
    Public da As New MySqlDataAdapter
    Public dt As New DataTable
    Public result As Integer
    Public sql As String

    Public Sub saveuser()
        If frmadmin.TextBox15.Text = "" Or frmadmin.TextBox11.Text = "" Or frmadmin.TextBox13.Text = "" Or frmadmin.TextBox14.Text = "" Or frmadmin.ComboBox1.Text = "" Or frmadmin.TextBox26.Text = "" Or frmadmin.TextBox25.Text = "" Then
            MsgBox("Please Fill up the data!")
        Else
            Try
                con.Open()
                sql = "INSERT into `rvempire_db`.`tbluser` (`fname`,`lname`,`address`,`contact`, `role`, `uname`, `pword`) VALUES ('" & frmadmin.TextBox15.Text & "','" & frmadmin.TextBox11.Text & "','" & frmadmin.TextBox13.Text & "','" & frmadmin.TextBox14.Text & "','" & frmadmin.ComboBox1.Text & "','" & frmadmin.TextBox26.Text & "','" & frmadmin.TextBox25.Text & "')"
                With cmd
                    .Connection = con
                    .CommandText = sql
                End With
                result = cmd.ExecuteNonQuery
                If result > 0 Then
                    MsgBox("New User has been added")
                Else
                    MsgBox("Sorry record not save!")
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                con.Close()
            End Try
        End If
    End Sub

    Public Sub savesupplier()
        If frmadmin.TextBox8.Text = "" Or frmadmin.TextBox7.Text = "" Or frmadmin.TextBox3.Text = "" Or frmadmin.TextBox2.Text = "" Then
            MsgBox("Please fill up the data!")
        Else
            Try
                con.Open()
                sql = "INSERT into `rvempire_db`.`tblsupplier` (`cname`,`contact`,`address`,`email`) VALUES ('" & frmadmin.TextBox8.Text & "','" & frmadmin.TextBox7.Text & "','" & frmadmin.TextBox3.Text & "','" & frmadmin.TextBox2.Text & "')"
                With cmd
                    .Connection = con
                    .CommandText = sql
                End With
                result = cmd.ExecuteNonQuery
                If result > 0 Then
                    MsgBox("New Supplier has been added")
                Else
                    MsgBox("Sorry record not save!")
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                con.Close()
            End Try
        End If
    End Sub

    Public Sub saveorder()
        If frmcashier.TextBox32.Text = "" Or frmcashier.TextBox31.Text = "" Or frmcashier.Label2.Text = "" Or frmcashier.TextBox30.Text = "" Or frmcashier.TextBox29.Text = "" Then
            MsgBox("Please fill up the data!")
        Else
            Try
                con.Open()
                sql = "INSERT into `rvempire_db`.`tblorder` (`proid`,`cusid`,`date`,`quantity`, `price`) VALUES ('" & frmcashier.TextBox32.Text & "','" & frmcashier.TextBox31.Text & "','" & frmcashier.Label2.Text & "','" & frmcashier.TextBox30.Text & "','" & frmcashier.TextBox29.Text & "')"
                With cmd
                    .Connection = con
                    .CommandText = sql
                End With
                result = cmd.ExecuteNonQuery
                If result > 0 Then
                    MsgBox("New Order has been added")
                Else
                    MsgBox("Sorry record not save!")
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                con.Close()
            End Try
        End If
    End Sub

    Public Sub saveshipment()
        If frmadmin.TextBox59.Text = "" Or frmadmin.TextBox58.Text = "" Then
            MsgBox("Please fill up the data!")
        Else
            Try
                con.Open()
                sql = "INSERT into `rvempire_db`.`tblshipment` (`suppid`,`itembcode`) VALUES ('" & frmadmin.TextBox59.Text & "','" & frmadmin.TextBox58.Text & "')"
                With cmd
                    .Connection = con
                    .CommandText = sql
                End With
                result = cmd.ExecuteNonQuery
                If result > 0 Then
                    MsgBox("New Shipment has been added")
                Else
                    MsgBox("Sorry record not save!")
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
                con.Close()
            End Try
        End If
    End Sub

    Public Sub saveitem()
        If frmadmin.TextBox58.Text = "" Or frmadmin.TextBox59.Text = "" Or frmadmin.TextBox29.Text = "" Or frmadmin.TextBox57.Text = "" Or frmadmin.TextBox56.Text = "" Or frmadmin.TextBox55.Text = "" Or frmadmin.TextBox54.Text = "" Then
            MsgBox("Please fill up the data!")
        Else
            Try
                con.Open()
                sql = "INSERT into `rvempire_db`.`tblitem` (`itembcode`,`suppid`,`prodname`,`proddesc`,`price`,`quantity`,`totalprice`) VALUES ('" & frmadmin.TextBox58.Text & "','" & frmadmin.TextBox59.Text & "','" & frmadmin.TextBox29.Text & "','" & frmadmin.TextBox57.Text & "','" & frmadmin.TextBox56.Text & "','" & frmadmin.TextBox55.Text & "','" & frmadmin.TextBox54.Text & "')"
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
        End If
    End Sub
End Module
