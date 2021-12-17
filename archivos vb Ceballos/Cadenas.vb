Imports System
Imports System.Text

Module Cadenas
  ' Convertir una cadena a mayúsculas
  Public Sub MinusculasMayusculas(str As StringBuilder)
    Dim i As Integer = 0
    Dim desp As Integer = Convert.ToInt32("a"c) - Convert.ToInt32("A"c)
    Dim car As Char
    For i = 0 To str.Length - 1
      car = str.Chars(i)
      If (car >= "a"c And car <= "z"c) Then
        str.Chars(i) = Convert.ToChar(Convert.ToInt32(car) - desp)
      End If
    Next
  End Sub

  Public Sub Main()
    Dim scadena As String = Nothing
    Dim bcadena As StringBuilder = Nothing

    Console.Write("Introduzca un texto: ")
    scadena = Console.ReadLine() ' leer una línea de texto
    ' Construir un objeto StringBuilder a partir de la cadena
    bcadena = New StringBuilder(scadena)

    ' Convertir minúsculas a mayúsculas
    MinusculasMayusculas(bcadena) ' llamar al método
    System.Console.WriteLine(bcadena)   ' escribir el resultado
  End Sub
End Module

