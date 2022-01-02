Imports MySql.Data.MySqlClient
Module item_click
    Public con As MySqlConnection = connect()
    Public cmd As New MySqlCommand
    Public da As New MySqlDataAdapter
    Public dt As New DataTable
    Public ds As New DataSet
    Public sql As String
    Public result As Integer

    Dim itemid As String
    Dim itembcode As String
    Dim suppid As String
    Dim prodname As String
    Dim proddesc As String
    Dim quantity As String
    Dim price As String
    Dim totalprice As String
    Dim stockin As String
    Public Sub itemclick()
        Try
            itemid = frmadmin.DataGridView6.CurrentRow.Cells(0).Value
            itembcode = frmadmin.DataGridView6.CurrentRow.Cells(1).Value
            suppid = frmadmin.DataGridView6.CurrentRow.Cells(2).Value
            prodname = frmadmin.DataGridView6.CurrentRow.Cells(3).Value
            proddesc = frmadmin.DataGridView6.CurrentRow.Cells(4).Value
            quantity = frmadmin.DataGridView6.CurrentRow.Cells(5).Value
            price = frmadmin.DataGridView6.CurrentRow.Cells(6).Value
            totalprice = frmadmin.DataGridView6.CurrentRow.Cells(7).Value
            stockin = frmadmin.DataGridView6.CurrentRow.Cells(5).Value
        Catch ex As Exception
        Finally
        End Try
    End Sub

    Public Sub saveinventory()
        If itemid = "" Or itembcode = "" Or suppid = "" Or prodname = "" Or proddesc = "" Or quantity = "" Or price = "" Or totalprice = "" Or stockin = "" Then
            MsgBox("No Shipted Item to moved in the Inventory")
        Else
            Try
                con.Open()
                sql = "INSERT into `rvempire_db`.`tblinventory` (`itemid`,`itembcode`,`prodname`,`proddesc`,`suppid`,`quantity`,`price`,`totalprice`,`date`,`stockin`,`stockout`) VALUES " & _
                "('" & itemid & "','" & itembcode & "','" & prodname & "','" & proddesc & "','" & suppid & "','" & quantity & "','" & price & "','" & totalprice & "','" & frmadmin.Label2.Text & "','" & stockin & "','" & 0 & "')"
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

    Public Sub deleteitem()
        dt = New DataTable
        Try
            con.Open()
            sql = "Delete from `tblitem` WHERE `tblitem`.`itemid` = '" & itemid & "'"
            With cmd
                .Connection = con
                .CommandText = sql
            End With
            result = cmd.ExecuteNonQuery
            If result > 0 Then
                MsgBox("New Shipted Item has been move to the inventory")
            Else

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
End Module

