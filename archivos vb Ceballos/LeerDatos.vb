' Este programa utiliza la clase Leer del espacio de nombres
' MisClases.ES

Imports System
Imports MisClases.ES

Module LeerDatos
  Public Sub Main()
    Dim dato_Short As Short = 0
    Dim dato_Int As Integer = 0
    Dim dato_Long As Long = 0
    Dim dato_Single As Single = 0
    Dim dato_Double As Double = 0

    Console.Write("Dato Short: ")
    dato_Short = Leer.datoShort()
    Console.Write("Dato Integer: ")
    dato_Int = Leer.datoInt()
    Console.Write("Dato Long: ")
    dato_Long = Leer.datoLong()
    Console.Write("Dato Single: ")
    dato_Single = Leer.datoSingle()
    Console.Write("Dato Double: ")
    dato_Double = Leer.datoDouble()

    Console.WriteLine(dato_Short)
    Console.WriteLine(dato_Int)
    Console.WriteLine(dato_Long)
    Console.WriteLine(dato_Single)
    Console.WriteLine(dato_Double)
  End Sub
End Module
