Imports System

Public Class CuadradoMagico
  Private cm(,) As Integer
  Private n As Integer

  Public Sub New(ByVal orden As Integer)
    If (Not esImpar(orden)) Then orden += 1
    n = orden
    cm = New Integer(n, n) {}
  End Sub

  Public Function esImpar(ByVal n As Integer) As Boolean
    If (n Mod 2 <> 0) Then Return True
    Return False
  End Function

  Public Sub cuadradoMagico()
    Dim fil, fil_ant As Integer, cont As Integer = 1
    Dim col As Integer = n \ 2, col_ant As Integer = n \ 2

    cm(fil, col) = cont
    cont += 1

    While (cont <= n * n)
      fil = fil - 1
      col = col + 1

      If (fil < 0) Then fil = n - 1
      If (col > n - 1) Then col = 0
      If (cm(fil, col) <> 0) Then
        col = col_ant
        fil = fil_ant + 1
        If (fil = n) Then fil = 0
      End If

      cm(fil, col) = cont
      cont += 1
      fil_ant = fil
      col_ant = col
    end while
  End Sub

  Public Sub visualizar()
    Dim i, j As Integer
    For i = 0 To n - 1
      Console.Write("  ")
      For j = 0 To n - 1
        Console.Write("{0,5:D}", cm(i, j))
      Next
      Console.WriteLine()
    Next
  End Sub
End Class
