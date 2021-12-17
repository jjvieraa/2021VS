Imports System

Module Pitagoras
  ' Teorema de Pitágoras
  Public Sub Main()
    Dim x As Integer = 1, y As Integer = 1, z As Integer = 0
    Dim TH As Char = Convert.ToChar(&H9) ' tab horizontal

    Console.WriteLine("Z" & TH & "X" & TH & "Y")
    Console.WriteLine("____________________")
    While (x <= 50)
      ' Calcular z. Como z es un entero, almacena
      ' la parte entera (redondeada) de la raíz cuadrada
      z = Math.Sqrt(x * x + y * y)
      While (y <= 50 And z <= 50)
        ' Si la raíz cuadrada anterior fue exacta,
        ' escribir z, x e y
        If (z * z = x * x + y * y) Then
          Console.WriteLine(z & TH & x & TH & y)
        End If
        y = y + 1
        z = Math.Sqrt(x * x + y * y)
      End While
      x = x + 1 : y = x
    End While
  End Sub
End Module
