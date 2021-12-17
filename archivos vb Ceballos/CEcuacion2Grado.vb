' Este programa utiliza la clase Leer del espacio de nombres
' MisClases.ES
Imports System
Imports MisClases.ES

Module CEcuacion2Grado
  ' Calcular las raíces de una ecuación de 2º grado
  Public Sub Main()
    Dim a, b, c As Double ' coeficientes de la ecuación
    Dim d As Double       ' discriminante
    Dim re, im As Double  ' parte real e imaginaria de la raíz

    Console.WriteLine("Coeficientes a, b y c de la ecuación:")
    Console.Write("a = ") : a = Leer.datoDouble()
    Console.Write("b = ") : b = Leer.datoDouble()
    Console.Write("c = ") : c = Leer.datoDouble()
    Console.WriteLine()
    If (a = 0 And b = 0) Then
      Console.WriteLine("La ecuación es degenerada")
    ElseIf (a = 0) Then
      Console.WriteLine("La única raíz es: " & -c / b)
    Else
      re = -b / (2 * a)
      d = b * b - 4 * a * c
      im = Math.Sqrt(Math.Abs(d)) / (2 * a)
      If (d >= 0) Then
        Console.WriteLine("Raíces reales:")
        Console.WriteLine((re + im) & ", " & (re - im))
      Else
        Console.WriteLine("Raíces complejas:")
        Console.WriteLine(re & " + " & Math.Abs(im) & " j")
        Console.WriteLine(re & " - " & Math.Abs(im) & " j")
      End If
    End If
  End Sub
End Module
