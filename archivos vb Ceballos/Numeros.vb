Imports System

Public Class Numeros
  ' Atributos
  Private m() As Integer
  Private numElementos As Integer

  ' Métodos
  Public Sub New(ByVal n As Integer)
    If (n < 1) Then
      n = 11
    ElseIf (n Mod 2 = 0) Then
      n += 1
    End If

    numElementos = n
    m = New Integer(numElementos - 1) {}
  End Sub

  Public Function Tamaño() As Integer
    Return numElementos
  End Function

  Public Sub AsignarValor(ByVal n As Integer, ByVal i As Integer)
    If (i < 0 Or i > numElementos - 1) Then
      Console.WriteLine("Índice fuera de límites")
      Return
    End If
    m(i) = n
  End Sub

  Public Sub Ordenar()
    Array.Sort(m)
  End Sub

  Public Function Mediana() As Integer
    Return m((numElementos - 1) / 2)
  End Function
End Class
