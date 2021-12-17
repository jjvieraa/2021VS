' Este programa utiliza la clase Leer del espacio de nombres
' MisClases.ES
Imports System
Imports System.Environment
Imports MisClases.ES

Module MatrizUnidimensional
  ' Creación de una matriz unidimensional
  Public Sub Main()
    Dim nElementos As Integer
    Console.Write("Número de elementos de la matriz: ")
    nElementos = Leer.datoInt()
    Dim m(nElementos - 1) As Integer ' crear la matriz m
    Dim i As Integer ' subíndice

    Console.WriteLine("Introducir los valores de la matriz.")
    For i = 0 To nElementos - 1
      Console.Write("m(" & i & ") = ")
      m(i) = Leer.datoInt()
    Next

    ' Visualizar los elementos de la matriz
    Console.WriteLine()
    For i = 0 To nElementos - 1
      Console.Write(m(i) & " ")
    Next
    Console.WriteLine()
    Console.WriteLine(NewLine & "Fin del proceso.")
  End Sub
End Module
