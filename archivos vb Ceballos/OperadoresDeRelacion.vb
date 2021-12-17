Module OperadoresDeRelacion
  '
  ' Expresiones condicionales 
  '
  Sub Main()
    Dim num As Integer = 23

    If num Mod 2 = 0 Then 'si el resto de la división es igual a 0,
      System.Console.WriteLine("Número par")
    Else               'si el resto de la división no es igual a 0,
      System.Console.WriteLine("Número impar")
    End If

    System.Console.WriteLine("Valor: " & num)
  End Sub
End Module
