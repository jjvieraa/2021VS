Module clear
    Public Sub clearuser()
        frmadmin.TextBox15.Clear()
        frmadmin.TextBox11.Clear()
        frmadmin.TextBox13.Clear()
        frmadmin.TextBox14.Clear()
        frmadmin.ComboBox1.Text = ""
        frmadmin.TextBox25.Clear()
        frmadmin.TextBox26.Clear()
        frmadmin.id = ""
    End Sub

    Public Sub clearupdateuser()
        frmadmin.TextBox28.Clear()
        frmadmin.TextBox27.Clear()
        frmadmin.TextBox20.Clear()
        frmadmin.TextBox19.Clear()
        frmadmin.ComboBox3.Text = ""
        frmadmin.TextBox18.Clear()
        frmadmin.TextBox16.Clear()
        frmadmin.id = ""
    End Sub

    Public Sub clearsupplier()
        With frmadmin
            .TextBox8.Clear()
            .TextBox7.Clear()
            .TextBox3.Clear()
            .TextBox2.Clear()
            .id = ("")
        End With

    End Sub

    Public Sub clearupdatesupplier()
        With frmadmin
            .TextBox9.Clear()
            .TextBox4.Clear()
            .TextBox5.Clear()
            .TextBox6.Clear()
            .id = ""
        End With
    End Sub

    Public Sub clearshipment()
        With frmadmin
            .TextBox59.Clear()
            .TextBox58.Clear()
            .TextBox57.Clear()
            .TextBox55.Clear()
            .TextBox54.Clear()
            .TextBox29.Clear()
            .TextBox56.Clear()
            .id = ""
        End With
    End Sub
End Module
