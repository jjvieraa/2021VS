class CEcuacion
  ' El término de mayor grado tiene exponente 3 fijo
  Private c3, c2, c1, c0 As Double ' coeficientes

  Public Sub New(a As Double, b As Double, c As Double, d As Double)
    Ecuación(a, b, c, d)
  End Sub

  Public Sub Ecuación(a As Double, b As Double, c As Double, d As Double)
    c3 = a : c2 = b : c1 = c : c0 = d
  End Sub

  Public Function ValorPara(x As Double) As Double
    Dim resultado As Double
    resultado = c3 * x * x * x + c2 * x * x + c1 * x + c0
    Return resultado ' devolver el valor calculado
  End Function
End Class

