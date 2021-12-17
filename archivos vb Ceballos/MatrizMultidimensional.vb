' Este programa utiliza la clase Leer del espacio de nombres
' MisClases.ES
Imports System
Imports MisClases.ES

Module MatrizMultidimensional
  ' Creación de una matriz multidimensional.
  ' Suma de las filas de una matriz de dos dimensiones.
  Public Sub Main()
    Dim nfilas, ncols As Integer    ' filas y columnas de la matriz

    Do
      Console.Write("Número de filas de la matriz:    ")
      nfilas = Leer.datoInt()
    Loop While (nfilas < 1) ' no permitir un valor cero o negativo

    Do
      Console.Write("Número de columnas de la matriz: ")
      ncols = Leer.datoInt()
    Loop While (ncols < 1) ' no permitir un valor cero o negativo

    Dim m(nfilas - 1, ncols - 1) As Single ' crear la matriz m
    Dim fila, col As Integer ' subíndices
    Dim sumafila As Single   ' suma de los elementos de una fila

    Console.WriteLine("Introducir los valores de la matriz.")
    For fila = 0 To nfilas - 1
      For col = 0 To ncols - 1
        Console.Write("m(" & fila & "," & col & ") = ")
        m(fila, col) = Leer.datoSingle()
      Next
    Next

    ' Visualizar la suma de cada fila de la matriz
    Console.WriteLine()
    For fila = 0 To nfilas - 1
      sumafila = 0
      For col = 0 To ncols - 1
        sumafila += m(fila, col)
      Next
      Console.WriteLine("Suma de la fila " & fila & ": " & sumafila)
    Next
    Console.WriteLine("Fin del proceso.")
  End Sub
End Module
