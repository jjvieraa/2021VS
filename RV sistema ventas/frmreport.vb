Imports MySql.Data.MySqlClient
Public Class frmreport
    Dim cmd As New MySqlCommand
    Dim da As New MySqlDataAdapter
    Dim acscmd As New MySqlCommand
    Dim acsda As New MySqlDataAdapter
    Dim ascon As MySqlConnection = connect()

    Dim acsds As New DataTable
    Dim strsql As String
    Dim strreportname As String
    Dim reportselect As String
    

    Private Sub frmreport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        report("" & reportselect & "", "" & strreportname & "")
    End Sub
    Public Sub report(ByVal sql As String, ByVal rptname As String)
        acsds = New DataTable
        strsql = sql
        acscmd.CommandText = strsql
        acscmd.Connection = ascon
        acsda.SelectCommand = acscmd
        acsda.Fill(acsds)

        strreportname = rptname
        Dim strreportpath As String = Application.StartupPath & "\reports\" & strreportname & " .rpt"
        If Not IO.File.Exists(strreportpath) Then
            MsgBox("Unable to locate file: " & vbCrLf & strreportpath)
        End If

        Dim reportdoc As New CrystalDecisions.CrystalReports.Engine.ReportDocument

        reportdoc.Load(strreportpath)
        reportdoc.SetDataSource(acsds(0))
        CrystalReportViewer1.ReportSource = reportdoc
    End Sub

End Class