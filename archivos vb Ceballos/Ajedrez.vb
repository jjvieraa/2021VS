' Este programa utiliza la clase Leer del espacio de nombres
' MisClases.ES
Imports System
Imports MisClases.ES

Module Ajedrez
  ' Imprimir un tablero de ajedrez.
  Public Sub Main()
    Dim falfil, calfil As Integer ' posición inicial del alfil
    Dim fila, columna As Integer  ' posición actual del alfil

    Console.WriteLine("Posición del alfil:")
    Console.Write("  fila    ") : falfil = Leer.datoInt()
    Console.Write("  columna ") : calfil = Leer.datoInt()
    Console.WriteLine() ' dejar una línea en blanco

    ' Pintar el tablero de ajedrez
    For fila = 1 To 8
      For columna = 1 To 8
        If ((fila + columna = falfil + calfil) Or _
           (fila - columna = falfil - calfil)) Then
          Console.Write("* ")
        ElseIf ((fila + columna) Mod 2 = 0) Then
          Console.Write("B ")
        Else
          Console.Write("N ")
        End If
      Next
      Console.WriteLine() ' cambiar de fila
    Next
  End Sub
End Module
