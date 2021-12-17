Imports System

Class CEsfera
  ' Atributos
  Private rad As Double = 0

  ' Constructores
  Public Sub New()
  End Sub

  Public Sub New(r As Double)
    rad = r
  End Sub

  ' Métodos
  Public Sub setRadio(r As Double)
    rad = r
  End Sub

  Public Function getRadio() As Double
    Return rad
  End Function

  Public Function Volumen() As Double
    Return (4.0 / 3.0) * Math.PI * rad * rad * rad
  End Function
End Class
