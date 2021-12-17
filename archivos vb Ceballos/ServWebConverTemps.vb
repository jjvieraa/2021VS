Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols

' Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la siguiente línea.
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://websol.aut.uah.es/ServiciosWeb/", _
Description:="CONVERSIÓN CENTÍGRADOS (C) <-> FAHRENHEIT (F)")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class ServWebConverTemps
  Inherits System.Web.Services.WebService

  <WebMethod(Description:="Convertir grados F a C")> _
  Public Function ConvFahrACent(ByVal gFahr As Double) As Double
    Return ((gFahr - 32) * 5.0) / 9.0
  End Function

  <WebMethod(Description:="Convertir grados C a F")> _
  Public Function ConvCentAFahr(ByVal gCent As Double) As Double
    Return 9.0 / 5.0 * gCent + 32
  End Function

End Class