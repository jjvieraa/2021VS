' Clase CGrados. Un objeto de esta clase almacena un valor
' en grados centígrados.
' Atributos:
'   gradosC
' Métodos:
'   AsignarCentígrados, ObtenerFahrenheit y ObtenerCentígrados
'
Public Class CGrados
  Private gradosC As Single ' grados centígrados

  Public Sub AsignarCentígrados(gC As Single)
    ' Establecer el atributo grados centígrados
    gradosC = gC
  End Sub

  Public Function ObtenerFahrenheit() As Single
    ' Retornar los grados fahrenheit equivalentes a gradosC
    Return 9 / 5 * gradosC + 32
  End Function

  Public Function ObtenerCentígrados() As Single
    Return gradosC ' retornar los grados centígrados
  End Function
End Class

