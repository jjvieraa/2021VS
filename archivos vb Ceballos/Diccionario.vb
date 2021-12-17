Imports System

Public Class Diccionario
  Private spanish() As String
  Private english() As String
  Private ultimaEntradaLibre As Integer

  Public Sub New()
    spanish = New String(100) {}
    english = New String(100) {}
    ultimaEntradaLibre = 0
  End Sub

  Public Sub New(ByVal n As Integer)
    If (n < 1) Then n = 100
    spanish = New String(n) {}
    english = New String(n) {}
    ultimaEntradaLibre = 0
  End Sub

  Public Sub añadir(ByVal es As String, ByVal uk As String)
    If (ultimaEntradaLibre < 100) Then
      spanish(ultimaEntradaLibre) = es
      english(ultimaEntradaLibre) = uk
      ultimaEntradaLibre += 1
    Else
      Console.WriteLine("No hay entradas libres")
    End If
  End Sub

  Public Sub cambiar(ByVal i As Integer, ByVal es As String, ByVal uk As String)
    If (i < 0 Or i > 99) Then
      Console.WriteLine("No hay entradas libres")
      Return
    End If
    spanish(i) = es
    english(i) = uk
  End Sub

  Public Function EnToSp(ByVal palabra As String) As String
    Dim i As Integer
    For i = 0 To ultimaEntradaLibre - 1
      If (english(i).CompareTo(palabra) = 0) Then Return spanish(i)
    Next
    Return Nothing
  End Function

  Public Function SpToEn(ByVal palabra As String) As String
    Dim i As Integer
    For i = 0 To ultimaEntradaLibre - 1
      If (spanish(i).CompareTo(palabra) = 0) Then Return english(i)
    Next
    Return Nothing
  End Function

  Public Function buscar(ByVal palabra As String) As Integer
    ' Buscar en ingls o en español
    Dim i As Integer
    For i = 0 To ultimaEntradaLibre - 1
      If (spanish(i).CompareTo(palabra) = 0 Or _
          english(i).CompareTo(palabra) = 0) Then Return i
    Next
    Return -1
  End Function
End Class
