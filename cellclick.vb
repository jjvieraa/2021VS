Module cellclick

    Public Sub userclick()
        Try
            frmadmin.id = frmuser.DataGridView1.CurrentRow.Cells(0).Value
            frmadmin.TextBox28.Text = frmuser.DataGridView1.CurrentRow.Cells(1).Value
            frmadmin.TextBox27.Text = frmuser.DataGridView1.CurrentRow.Cells(2).Value
            frmadmin.TextBox20.Text = frmuser.DataGridView1.CurrentRow.Cells(3).Value
            frmadmin.TextBox19.Text = frmuser.DataGridView1.CurrentRow.Cells(4).Value
            frmadmin.ComboBox3.Text = frmuser.DataGridView1.CurrentRow.Cells(5).Value
            frmadmin.TextBox18.Text = frmuser.DataGridView1.CurrentRow.Cells(6).Value
            frmadmin.TextBox16.Text = frmuser.DataGridView1.CurrentRow.Cells(7).Value
        Catch ex As Exception
        Finally
        End Try
    End Sub

    Public Sub supplierclick()
        Try
            frmadmin.id = frmsupplier.DataGridView1.CurrentRow.Cells(0).Value
            frmadmin.TextBox9.Text = frmsupplier.DataGridView1.CurrentRow.Cells(1).Value
            frmadmin.TextBox6.Text = frmsupplier.DataGridView1.CurrentRow.Cells(2).Value
            frmadmin.TextBox5.Text = frmsupplier.DataGridView1.CurrentRow.Cells(3).Value
            frmadmin.TextBox4.Text = frmsupplier.DataGridView1.CurrentRow.Cells(4).Value
            frmadmin.TextBox59.Text = frmsupplier.DataGridView1.CurrentRow.Cells(0).Value
        Catch ex As Exception
        Finally
        End Try
    End Sub

    'Public Sub itemclick()
    '    Try
    '        frmadmin.Text = frmadmin.DataGridView6.CurrentRow.Cells(0).Value
    '    Catch ex As Exception
    '    Finally
    '    End Try
    'End Sub

End Module
