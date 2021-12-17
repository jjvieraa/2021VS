' Este programa utiliza la clase Leer del espacio de nombres
' MisClases.ES
Imports System
Imports MisClases.ES

Module ValoresMaxMin
  ' Obtener el máximo y el mínimo de un conjunto de valores
  Public Sub Main()
    Dim nElementos As Integer   ' número de elementos (valor no negativo)

    Do
      Console.Write("Número de valores que desea introducir: ")
      nElementos = Leer.datoInt()
    Loop While (nElementos < 1)

    Dim dato(nElementos - 1) As Single ' crear la matriz dato
    Dim i As Integer       ' subíndice
    Dim max, min As Single ' valor máximo y valor mínimo

    Console.WriteLine("Introducir los valores. " & _
                      "Para finalizar pulse [Entrar]")
    For i = 0 To dato.Length - 1
      Console.Write("dato(" & i & ")= ")
      dato(i) = Leer.datoSingle()
      If (Single.IsNaN(dato(i))) Then Exit For
    Next
    nElementos = i ' número de valores leídos

    ' Obtener los valores máximo y mínimo
    If (nElementos > 0) Then
      min = dato(0) : max = dato(0)
      For i = 0 To nElementos - 1
        If (dato(i) > max) Then max = dato(i)
        If (dato(i) < min) Then min = dato(i)
      Next
      ' Escribir los resultados 
      Console.WriteLine("Valor máximo: " & max)
      Console.WriteLine("Valor mínimo: " & min)
    Else
      Console.WriteLine("No hay datos.")
    End If
  End Sub
End Module

