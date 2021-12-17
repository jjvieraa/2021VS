Module Test
  Public Sub Main()
    Dim nFilas As Integer = 3, nCarsPorFila As Integer = 60
    Dim car, f, c As Integer, CR As Integer = 13

    ' Definir la matriz de caracteres
    Dim m(nFilas - 1, nCarsPorFila - 1) As Char
    ' Leer las cadenas de caracteres
    System.Console.WriteLine("Introducir cadenas:")
    For f = 0 To nFilas - 1
      c = 0
      ' Leer una cadena
      car = System.Console.Read()
      While (car <> CR And c < nCarsPorFila)
        m(f, c) = System.Convert.ToChar(car)
        c += 1 ' posición del siguiente carácter
        car = System.Console.Read()
      End While
      System.Console.ReadLine() ' Limpiar el buffer de entrada
    Next
    ' Escribir las cadenas de caracteres
    For f = 0 To nFilas - 1
      c = 0
      ' Escribir una cadena
      While (c < nCarsPorFila)
        System.Console.Write(m(f, c))
        c += 1
      End While
      System.Console.WriteLine() ' cambiar de línea
    Next
  End Sub
End Module

