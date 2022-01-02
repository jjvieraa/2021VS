Imports MySql.Data.MySqlClient
Public Class frmadmin
    Public id As String
    Public itemid As String

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        frmsupplier.Show()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        frmuser.Show()
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Me.Close()
        Form1.Show()

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Label2.Text = My.Computer.Clock.LocalTime.Date
        Label40.Text = TimeOfDay
    End Sub

    Private Sub frmadmin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Start()
        loaduser()
        loadsupplier()
        loadshipment()
        loaditem()
        loadcustomer()
        loadproduct()
        loadinventory()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        saveuser()
        loaduser()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        clearuser()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        savesupplier()
        loadsupplier()
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        clearupdatesupplier()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        clearsupplier()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        clearupdateuser()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click

        updateuser()
        loaduser()
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        updatesupplier()
        loadsupplier()
    End Sub

    Private Sub Button24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button24.Click
        frmsupplier.Show()
    End Sub

    Private Sub Button27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button27.Click
        frmsupplier.Show()
    End Sub

    Private Sub TextBox55_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox55.TextChanged
        If TextBox55.Text = "" Or TextBox56.Text = "" Then
            TextBox54.Text = ""
        Else
            TextBox54.Text = Val(TextBox56.Text) * Val(TextBox55.Text)
        End If

    End Sub

    Private Sub TextBox56_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox56.TextChanged
        If TextBox55.Text = "" Or TextBox56.Text = "" Then
            TextBox54.Text = ""
        Else
            TextBox54.Text = Val(TextBox56.Text) * Val(TextBox55.Text)
        End If
    End Sub

    Private Sub Button26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button26.Click
        saveshipment()
        saveitem()
        updateshipment()
        loaditem()
        loadshipment()
        clearupdatesupplier()
        clearsupplier()
    End Sub

    Private Sub Button25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button25.Click
        clearshipment()
    End Sub

    Private Sub DataGridView6_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView6.CellClick
        itemclick()
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        saveinventory()
        deleteitem()
        Call frmadmin_Load(sender, e)
    End Sub

    Private Sub Button29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button29.Click
        frmshipted.Show()
    End Sub


    Dim con As MySqlConnection = connect()
    Public Function connect() As MySqlConnection
        Return New MySqlConnection("server = localhost; user=root; database=rvempire_db")
    End Function

    Dim cmd As New MySqlCommand
    Dim da As New MySqlDataAdapter
    Dim ds As New DataTable
    Dim result As Integer
    Dim sql As String
    Dim strsql As String
    Dim strreportname As String
    Private Sub report(ByVal sql As String, ByVal rptname As String)
        report("" & reportselect & "", "" & reportname & "")
    End Sub

    Public Sub report()
        ds = New DataTable
        strsql = sql
        cmd.CommandText = strsql
        cmd.Connection = con
        da.SelectCommand = cmd
        da.Fill(ds)
        strreportname = rptname

        Dim strreportpath As String = Application.StartupPath & "\reports\" & reportname & ".rpt"

        If Not IO.File.Exists(strreportpath) Then
            MsgBox("Unable to locate file:" & vbCrLf & strreportpath)

        End If

        Dim reportdoc As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        reportdoc.Load(strreportpath)
        reportdoc.SetDataSource(ds)

    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        strreportname = "CrystalReport1"
        reportselect = "SELECT `tblshipment`.`shipid`, `tblshipment`.`suppid`, `tblshipment`.`itembcode`, `tblshipment`.`date`FROM   `rvempire_db`.`tblshipment` `tblshipment`"
        'reportselect = "SELECT `tblclearedrecords`.`clearID`, `tblclearedrecords`.`browID`, `tblclearedrecords`.`bookTitle`, `tblclearedrecords`.`studID`, `tblclearedrecords`.`studName`, `tblclearedrecords`.`staffID`, `tblclearedrecords`.`staffName`, `tblclearedrecords`.`studentcopies`, `tblclearedrecords`.`releasedates`, `tblclearedrecords`.`duedate` FROM   `scalibdb`.`tblclearedrecords` `tblclearedrecords`"
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub
End Class