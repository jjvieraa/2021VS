Module Ejercicio3
  Function calcular(ByVal a As Double, ByVal b As Double, ByVal c As Double) As Double
    Dim resultado As Double

    resultado = ((b * b) - (4 * a * c)) / (2 * a)
    Return resultado
  End Function

  Sub Main()
    Dim a As Double = 1, b As Double = 5, c As Double = 2
    Dim resultado As Double

    resultado = calcular(a, b, c)

    System.Console.WriteLine("El resultado es " & resultado)
  End Sub
End Module
