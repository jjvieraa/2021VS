<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btSaludo = New System.Windows.Forms.Button()
        Me.etSaludo = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btSaludo
        '
        Me.btSaludo.Location = New System.Drawing.Point(26, 99)
        Me.btSaludo.Name = "btSaludo"
        Me.btSaludo.Size = New System.Drawing.Size(232, 23)
        Me.btSaludo.TabIndex = 3
        Me.btSaludo.Text = "Haga clic aquí"
        '
        'etSaludo
        '
        Me.etSaludo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.etSaludo.Location = New System.Drawing.Point(26, 40)
        Me.etSaludo.Name = "etSaludo"
        Me.etSaludo.Size = New System.Drawing.Size(232, 29)
        Me.etSaludo.TabIndex = 2
        Me.etSaludo.Text = "etiqueta"
        Me.etSaludo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 162)
        Me.Controls.Add(Me.btSaludo)
        Me.Controls.Add(Me.etSaludo)
        Me.Name = "Form1"
        Me.Text = "Saludo"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btSaludo As System.Windows.Forms.Button
  Friend WithEvents etSaludo As System.Windows.Forms.Label

End Class
