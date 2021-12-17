Imports System

Module ValorUnicode
  ' Examinar una cadena de caracteres almacenada en un string
  Public Sub Main()
    Dim cadena As String = Nothing  ' referencia a una cadena de caracteres

    Console.Write("Introduzca un texto: ")
    cadena = Console.ReadLine() ' leer una línea de texto

    ' Examinar la cadena de caracteres
    Dim i As Integer
    Do
      Console.WriteLine("Carácter = " & cadena.Chars(i) & _
                  ", código Unicode = " & Convert.ToInt32(cadena.Chars(i)))
      i += 1
    Loop While (i < cadena.Length)
  End Sub
End Module
