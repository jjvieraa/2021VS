' Este programa utiliza la clase Leer del espacio de nombres
' MisClases.ES
Imports System
Imports MisClases.ES

Module RaizCuadrada
  ' Raíz cuadrada. Método de Newton.
  Public Sub Main()
    Dim n As Double        ' número
    Dim aprox As Double    ' aproximación a la raíz cuadrada
    Dim antaprox As Double ' anterior aproximación a la raíz cuadrada
    Dim epsilon As Double  ' coeficiente de error

    Do
      Console.Write("Número: ")
      n = Leer.datoDouble()
    Loop While (n < 0)

    Do
      Console.Write("Raíz cuadrada aproximada: ")
      aprox = Leer.datoDouble()
    Loop While (aprox <= 0)

    Do
      Console.Write("Coeficiente de error: ")
      epsilon = Leer.datoDouble()
    Loop While (epsilon <= 0)

    Do
      antaprox = aprox
      aprox = (n / antaprox + antaprox) / 2
    Loop While (Math.Abs(aprox - antaprox) >= epsilon)

    Console.WriteLine("La raíz cuadrada de {0:F2} es {1:F2}", n, aprox)
  End Sub
End Module
