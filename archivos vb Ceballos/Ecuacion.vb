' Este programa utiliza la clase Leer del espacio de nombres
' MisClases.ES

Imports System
Imports MisClases.ES

Module Ecuacion
  Public Sub Main()
    Dim a, b, c, d, x1, x2 As Double

    Console.Write("Coeficiente a: ") : a = Leer.datoDouble()
    Console.Write("Coeficiente b: ") : b = Leer.datoDouble()
    Console.Write("Coeficiente c: ") : c = Leer.datoDouble()

    d = b * b - 4 * a * c
    If (d < 0) Then
      ' Si d es menor que 0
      Console.WriteLine("Las raíces son complejas.")
      Return ' salir
    End If
    ' Si d es mayor o igual que 0
    Console.WriteLine("Las raíces reales son:")
    d = Math.Sqrt(d)
    x1 = (-b + d) / (2 * a)
    x2 = (-b - d) / (2 * a)
    Console.WriteLine("x1 = " & x1 & ", x2 = " & x2)
  End Sub
End Module
