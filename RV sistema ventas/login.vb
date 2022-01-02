Imports MySql.Data.MySqlClient
Module login
    Public con As MySqlConnection = connect()
    Public cmd As New MySqlCommand
    Public da As New MySqlDataAdapter
    Public dt As New DataTable
    Public ds As New DataSet
    Public sql As String
    
    Public Sub loginthis()
        Try
            Dim maxrow As Integer
            con.Open()
            dt = New DataTable
            sql = ("select * from tbluser where uname='" & Form1.TextBox1.Text & "' and pword = '" & Form1.TextBox2.Text & "'")
            With cmd
                .Connection = con
                .CommandText = sql
            End With
            da.SelectCommand = cmd
            da.Fill(dt)
            maxrow = dt.Rows.Count
            If dt.Rows.Count > 0 Then
                If dt.Rows(0).Item("role") = "Administrator" Then
                    MsgBox("You have successfully logged in as an " & dt.Rows(0).Item("role"))
                    Form1.TextBox1.Clear()
                    Form1.TextBox2.Clear()
                    frmadmin.Show()
                    frmadmin.Label1.Text = "Admistrator : " & "  " & dt.Rows(0).Item("fname") & "  " & dt.Rows(0).Item("lname")
                    Form1.Hide()

                ElseIf dt.Rows(0).Item("role") = "Staff Clerk" Then
                    MsgBox("You have successfully logged in as an " & dt.Rows(0).Item("role"))
                    Form1.TextBox1.Clear()
                    Form1.TextBox2.Clear()
                    frmstaff.Label1.Text = "Staff Clerk : " & "  " & dt.Rows(0).Item("fname") & "  " & dt.Rows(0).Item("lname")
                    frmstaff.Show()
                    Form1.Hide()


                ElseIf dt.Rows(0).Item("role") = "Cashier" Then
                    MsgBox("You have successfully logged in as an " & dt.Rows(0).Item("role"))
                    Form1.TextBox1.Clear()
                    Form1.TextBox2.Clear()
                    frmcashier.Label1.Text = "Cashier : " & "  " & dt.Rows(0).Item("fname") & "  " & dt.Rows(0).Item("lname")
                    frmcashier.Show()
                    Form1.Hide()

                Else

                    MsgBox("Acount doest not exist!", MsgBoxStyle.Information)
                End If
            Else
                MsgBox("Acount doest not exist!", MsgBoxStyle.Information)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        con.Close()
        da.Dispose()
    End Sub

End Module
