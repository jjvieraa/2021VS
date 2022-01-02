Imports MySql.Data.MySqlClient
Module load
    Public con As MySqlConnection = connect()
    Public cmd As New MySqlCommand
    Public da As New MySqlDataAdapter
    Public dt As New DataTable
    Public result As Integer
    Public sql As String

#Region "load user"
    Public Sub loaduser()
        dt = New DataTable
        Try
            connect.Open()
            sql = "SELECT * FROM rvempire_db.`tbluser`"
            With cmd
                .Connection = connect()
                .CommandText = sql

            End With
            da.SelectCommand = cmd
            da.Fill(dt)
            frmadmin.DataGridView4.DataSource = dt
            frmadmin.DataGridView4.Columns("pword").Visible = False
            frmadmin.DataGridView4.Columns("userid").Visible = False
            frmuser.DataGridView1.DataSource = dt
            frmuser.DataGridView1.Columns("pword").Visible = False
            frmuser.DataGridView1.Columns("userid").Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
#End Region

    Public Sub loadsupplier()
        dt = New DataTable
        Try
            connect.Open()
            sql = "SELECT * FROM rvempire_db.`tblsupplier`"
            With cmd
                .Connection = connect()
                .CommandText = sql

            End With
            da.SelectCommand = cmd
            da.Fill(dt)
            frmadmin.DataGridView3.DataSource = dt
            frmadmin.DataGridView3.Columns("suppid").Visible = False
            frmsupplier.DataGridView1.DataSource = dt
            frmsupplier.DataGridView1.Columns("suppid").Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Public Sub loadorder()
        dt = New DataTable
        Try
            connect.Open()
            sql = "SELECT * FROM rvempire_db.`tblorder`"
            With cmd
                .Connection = connect()
                .CommandText = sql

            End With
            da.SelectCommand = cmd
            da.Fill(dt)
            frmcashier.DataGridView1.DataSource = dt
            frmcashier.DataGridView1.Columns("orderid").Visible = False
            frmorder.DataGridView1.DataSource = dt
            frmorder.DataGridView1.Columns("orderid").Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Public Sub loadpayment()
        dt = New DataTable
        Try
            connect.Open()
            sql = "SELECT * FROM rvempire_db.`tblpayment`"
            With cmd
                .Connection = connect()
                .CommandText = sql

            End With
            da.SelectCommand = cmd
            da.Fill(dt)
            frmcashier.DataGridView2.DataSource = dt
            frmcashier.DataGridView2.Columns("payid").Visible = False
            frmpayment.DataGridView1.DataSource = dt
            frmpayment.DataGridView1.Columns("payid").Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub


    Public Sub loadproduct()
        dt = New DataTable
        Try
            connect.Open()
            sql = "SELECT * FROM rvempire_db.`tblproduct`"
            With cmd
                .Connection = connect()
                .CommandText = sql

            End With
            da.SelectCommand = cmd
            da.Fill(dt)
            frmadmin.DataGridView2.DataSource = dt
            frmadmin.DataGridView2.Columns("prodid").Visible = False
            frmproduct.DataGridView1.DataSource = dt
            frmproduct.DataGridView1.Columns("prodid").Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Public Sub loadcustomer()
        dt = New DataTable
        Try
            connect.Open()
            sql = "SELECT * FROM rvempire_db.`tblcustomer`"
            With cmd
                .Connection = connect()
                .CommandText = sql

            End With
            da.SelectCommand = cmd
            da.Fill(dt)
            frmadmin.DataGridView1.DataSource = dt
            frmadmin.DataGridView1.Columns("cusid").Visible = False
            frmcustomer.DataGridView1.DataSource = dt
            frmcustomer.DataGridView1.Columns("cusid").Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Public Sub loadshipment()
        dt = New DataTable
        Try
            connect.Open()
            sql = "SELECT * FROM rvempire_db.`tblshipment`"
            With cmd
                .Connection = connect()
                .CommandText = sql

            End With
            da.SelectCommand = cmd
            da.Fill(dt)
            frmadmin.DataGridView8.DataSource = dt
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Public Sub loaditem()
        dt = New DataTable
        Try
            connect.Open()
            sql = "SELECT * FROM rvempire_db.`tblitem`"
            With cmd
                .Connection = connect()
                .CommandText = sql

            End With
            da.SelectCommand = cmd
            da.Fill(dt)
            frmadmin.DataGridView6.DataSource = dt
            frmadmin.DataGridView6.Columns("itemid").Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Public Sub loadinventory()
        dt = New DataTable
        Try
            connect.Open()
            sql = "SELECT * FROM rvempire_db.`tblinventory`"
            With cmd
                .Connection = connect()
                .CommandText = sql

            End With
            da.SelectCommand = cmd
            da.Fill(dt)
            frmadmin.DataGridView5.DataSource = dt
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
End Module
