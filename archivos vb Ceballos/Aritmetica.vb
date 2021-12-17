Module Aritmetica
  '
  ' Operaciones aritméticas 
  '
  Sub Main()
    Dim dato1, dato2, dato3, resultado As Integer

    dato1 = 10
    dato2 = 20
    dato3 = 30

    ' Suma
    resultado = dato1 + dato2 + dato3
    System.Console.WriteLine("{0} + {1} + {2} = {3}", dato1, dato2, dato3, resultado)

    ' Resta
    resultado = dato1 - dato2 - dato3
    System.Console.WriteLine("{0} - {1} - {2} = {3}", dato1, dato2, dato3, resultado)

    ' Multiplicación
    resultado = dato1 * dato2 * dato3
    System.Console.WriteLine("{0} * {1} * {2} = {3}", dato1, dato2, dato3, resultado)

    ' División
    resultado = dato1 / dato2 / dato3
    System.Console.WriteLine("{0} / {1} / {2} = {3}", dato1, dato2, dato3, resultado)

    ' Varias Operaciones
    resultado = dato1 + dato1 * dato2 - dato3
    System.Console.WriteLine("{0} + {1} * {2} - {3} = {4}", _
                             dato1, dato1, dato2, dato3, resultado)
  End Sub
End Module
