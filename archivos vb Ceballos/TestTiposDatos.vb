Imports System

Module TestTiposDatos
  ' Tipos de datos
  Public Sub Main()
    Dim sCadena As String = "Lenguaje Visual Basic"
    Dim cMatrizCars() As Char = "abc" ' matriz de caracteres
    Dim dato_int As Integer = 4
    Dim dato_long As Long = Long.MinValue      ' mínimo valor Long
    Dim dato_float As Single = Single.MaxValue ' máximo valor Single
    Dim dato_double As Double = Math.PI        ' 3.1415926
    Dim dato_bool As Boolean = True

    Console.WriteLine(sCadena)
    Console.WriteLine(cMatrizCars)
    Console.WriteLine(dato_int)
    Console.WriteLine(dato_long)
    Console.WriteLine(dato_float)
    Console.WriteLine(dato_double)
    Console.WriteLine(dato_bool)
  End Sub
End Module
