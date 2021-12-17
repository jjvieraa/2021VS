Imports System

Public Class CFecha
  Private día As Integer = 1
  Private mes As Integer = 1
  Private año As Integer = 2000

  Public Sub New()
  End Sub

  Public Sub New(d As Integer, m As Integer, a As Integer)
    día = d : mes = m : año = a
    If (Not FechaCorrecta()) Then ' Se asume 1/1/2000
      día = 1 : mes = 1 : año = 2000
    End If
  End Sub

  Public Function EstablecerFecha(ByVal d As Integer, ByVal m As Integer, ByVal a As Integer) As Boolean
    día = d : mes = m : año = a
    Return FechaCorrecta()
  End Function

  Public Function ObtenerDía() As Integer
    Return día
  End Function

  Public Function ObtenerMes() As Integer
    Return mes
  End Function

  Public Function ObtenerAño() As Integer
    Return año
  End Function

  Private Function FechaCorrecta() As Boolean
    Dim día_correcto As Boolean = True
    Dim mes_correcto As Boolean = True
    Dim año_correcto As Boolean = True

    año_correcto = año >= 1

    Select Case (mes)
      Case 1, 3, 5, 7, 8, 10, 12
        día_correcto = día >= 1 And día <= 31
      Case 4, 6, 9, 11
        día_correcto = día >= 1 And día <= 30
      Case 2  ' febrero
        ' Es el año bisiesto?
        If ((año Mod 4 = 0) And (año Mod 100 <> 0) Or (año Mod 400 = 0)) Then
          día_correcto = día >= 1 And día <= 29
        Else
          día_correcto = día >= 1 And día <= 28
        End If
      Case Else
        mes_correcto = False
    End Select
    Return día_correcto And mes_correcto And año_correcto
  End Function
End Class
