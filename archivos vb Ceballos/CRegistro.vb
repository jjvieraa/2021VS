' Definición de la clase CRegistro
'
Public Class CRegistro
  ' Atributos
  Private referencia As String
  Private precio As Double

  ' Métodos
  Public Sub New()  ' constructor por omisión

  End Sub

  Public Sub New(refer As String, pre As Double)  ' constructor
    referencia = refer
    precio = pre
  End Sub

  Public Sub asignarReferencia(refer As String)
    referencia = refer
  End Sub

  Public Function obtenerReferencia() As String
    Return referencia
  End Function

  Public Sub asignarPrecio(pre As Double)
    precio = pre
  End Sub

  Public Function obtenerPrecio() As Double
    Return precio
  End Function

  Public Function tamaño() As Integer
    ' Longitud en bytes de los atributos (un double = 8 bytes)
    Return referencia.Length * 2 + 8
  End Function
End Class
