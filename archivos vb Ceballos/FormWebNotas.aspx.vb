
Partial Class FormWebNotas
    Inherits System.Web.UI.Page

  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    etError.Text = ""
    If (lsdAsignatura.Items.Count = 0) Then
      CargarListaDesplegable()
    End If
  End Sub

  Private Sub CargarListaDesplegable()
  Dim sr As System.IO.StreamReader = Nothing
    Dim str As String
    Try
      ' Crear un flujo desde el fichero asignaturas.txt
      sr = New System.IO.StreamReader("C:\Inetpub\wwwroot\" & _
                      "FormWebNotas\App_Data\asignaturas.txt")
      ' Leer del fichero una línea de texto
      str = sr.ReadLine()
      While (Not str Is Nothing)
        ' Añadir a la lista la línea leída
        lsdAsignatura.Items.Add(str)
        ' Leer la línea siguiente
        str = sr.ReadLine()
      End While
    Catch exc As System.IO.IOException
      etError.Text = "Error: " + exc.Message
    Finally
      ' Cerrar el fichero
      If (Not sr Is Nothing) Then sr.Close()
    End Try
  End Sub

  Protected Sub btConsultarNota_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btConsultarNota.Click
    BuscarNota(lsdAsignatura.SelectedIndex)
  End Sub

  Private Sub BuscarNota(ByVal nAsig As Integer)
    Dim sr As System.IO.StreamReader = Nothing
    Dim str As String
    Dim tab As Char = System.Convert.ToChar(9)
    Dim sDatos As String() = Nothing
    Dim bEncontrado As Boolean = False

    Try
      ' Crear un flujo desde el fichero NotasAsigx.txt
      sr = New System.IO.StreamReader("C:\Inetpub\wwwroot\" & _
                "FormWebNotas\App_Data\NotasAsig" & nAsig & ".txt")

      ' Leer del fichero una línea de texto
      str = sr.ReadLine()
      While (Not str Is Nothing And Not bEncontrado)
        ' Dividir la línea en sus tres campos
        sDatos = str.Split(tab)
        If (ctDni.Text = sDatos(0)) Then bEncontrado = True
        ' Leer la línea siguiente
        If (Not bEncontrado) Then str = sr.ReadLine()
      End While

      ' Mostrar resultados
      If (bEncontrado) Then
        etNombre.Text = "Nombre:  " + sDatos(1)
        etNota.Text = "Nota:  " + sDatos(2)
      Else
        etNombre.Text = ""
        etNota.Text = ""
        etError.Text = "No figura en el acta"
      End If
    Catch exc As System.IO.IOException
      etError.Text = "Error: " + exc.Message
    Finally
      ' Cerrar el fichero
      If (Not sr Is Nothing) Then sr.Close()
    End Try
  End Sub
End Class
