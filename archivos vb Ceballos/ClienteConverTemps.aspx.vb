﻿
Partial Class ClienteConverTemps
    Inherits System.Web.UI.Page

  Protected Sub btConvertir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btConvertir.Click
    Dim nGrados As Double
    'Crear un objeto de la clase ServWebConverTemps que es la
    'clase que implementa el servicio Web XML
    Dim obGrados As ConvertirGrados.ServWebConverTemps = _
                    New ConvertirGrados.ServWebConverTemps()
    'Credenciales para autenticación de clientes de servicios Web
    obGrados.Credentials = System.Net.CredentialCache.DefaultCredentials

    'Obtener el valor escrito en la caja de texto
    nGrados = Convert.ToDouble(ctGrados.Text)
    'Realizar la conversión invocando al método correspondiente
    'del objeto obGrados de la clase ServWebConverTemps
    If (btopCentAFahr.Checked) Then
      nGrados = obGrados.ConvCentAFahr(nGrados)
    End If
    If (btopFahrACent.Checked) Then
      nGrados = obGrados.ConvFahrACent(nGrados)
    End If
    'Mostrar el resultado en la caja de texto
    ctGrados.Text = Convert.ToString(nGrados)
  End Sub
End Class
