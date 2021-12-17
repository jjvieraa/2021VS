Module MiAplicacion
  Public Sub Main()
    Dim ec1 As CEcuacion = New CEcuacion(1, -3.2, 0, 7)

    Dim r As Double = ec1.ValorPara(1)
    System.Console.WriteLine(r)

    r = ec1.ValorPara(1.5)
    System.Console.WriteLine(r)
  End Sub
End Module

