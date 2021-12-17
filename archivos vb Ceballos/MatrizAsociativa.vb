Imports System

Module MatrizAsociativa
  ' Frecuencia con la que aparecen las letras en un texto.
  Public Sub Main()
    ' Crear la matriz c con z-a+1 elementos.
    ' VB.NET inicia los elementos de la matriz a cero.
    Dim a As Integer = Convert.ToInt32("a"c)
    Dim z As Integer = Convert.ToInt32("z"c)
    Dim c(z - a + 1) As Integer
    Dim car As Integer ' subíndice

    ' Entrada de datos y cálculo de la tabla de frecuencias
    Console.WriteLine("Introducir un texto.")
    Console.WriteLine("Para finalizar pulsar [Ctrl][z]")
    Console.WriteLine()

    car = Console.Read()
    While (car <> -1)
      ' Si el carácter leído está entre la 'a' y la 'z'
      ' incrementar el contador correspondiente
      If (car >= a And car <= z) Then
        c(car - a) += 1
      End If
      ' Leer el siguiente carácter del texto y contabilizarlo
      car = Console.Read()
    End While

    ' Mostrar la tabla de frecuencias
    Console.WriteLine()
    ' Visualizar una cabecera "a b c ... "
    For car = a To z
      Console.Write("  " & Convert.ToChar(car))
    Next
    Console.WriteLine()
    Console.WriteLine(" -----------------------------" & _
    "------------------------------------------------")
    ' Visualizar la frecuencia con la que han aparecido los caracteres
    For car = a To z
      Console.Write("{0,3:D}", c(car - a))
    Next
    Console.WriteLine()
  End Sub
End Module

