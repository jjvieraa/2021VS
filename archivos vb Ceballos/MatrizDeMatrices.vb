Module Test
  Public Sub Main()
    Dim nFilas As Integer = 3, nCarsPorFila As Integer = 60
    Dim car, f, c, k As Integer, CR As Integer = 13

    ' Declarar una matriz de matrices
    Dim m(nFilas - 1)() As Char
    ' Una cadena
    Dim cadena(nCarsPorFila - 1) As Char

    ' Leer las cadenas de caracteres
    System.Console.WriteLine("Introducir cadenas:")
    For f = 0 To nFilas - 1
      c = 0
      ' Leer una cadena
      car = System.Console.Read()
      While (car <> CR And c < nCarsPorFila)
        cadena(c) = System.Convert.ToChar(car)
        c += 1 ' posición del siguiente carácter = caracteres leídos
        car = System.Console.Read()
      End While
      System.Console.ReadLine() ' Limpiar el buffer de entrada

      ' Añadir una submatriz de longitud c a m
      m(f) = New Char(c) {}
      ' Copiar la cadena leída en m(f)
      For k = 0 To c - 1
        m(f)(k) = cadena(k)
      Next
    Next

    ' Escribir las cadenas de caracteres
    For f = 0 To nFilas - 1
      System.Console.WriteLine(m(f))
    Next
  End Sub
End Module

