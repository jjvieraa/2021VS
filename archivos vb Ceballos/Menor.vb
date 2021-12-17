' Este programa utiliza la clase Leer del espacio de nombres
' MisClases.ES
Imports System
Imports MisClases.ES

Module Menor
  ' Menor de tres números a, b y c
  Public Sub Main()
    Dim a, b, c, menor As Single

    ' Leer los valores de a, b y c
    Console.Write("a : ") : a = Leer.datoSingle()
    Console.Write("b : ") : b = Leer.datoSingle()
    Console.Write("c : ") : c = Leer.datoSingle()
    ' Obtener el menor
    If (a < b) Then
      If (a < c) Then
        menor = a
      Else
        menor = c
      End If
    Else
      If (b < c) Then
        menor = b
      Else
        menor = c
      End If
    End If
    Console.WriteLine("Menor = " & menor)
  End Sub
End Module
