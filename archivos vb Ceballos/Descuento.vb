' Este programa utiliza la clase Leer del espacio de nombres
' MisClases.ES
Imports System
Imports MisClases.ES

Module Descuento
  Public Sub Main()
    Dim ar, cc As Integer
    Dim pu, desc As Single

    Console.Write("Código artículo....... ")
    ar = Leer.datoInt()
    Console.Write("Cantidad comprada..... ")
    cc = Leer.datoInt()
    Console.Write("Precio unitario....... ")
    pu = Leer.datoSingle()
    Console.WriteLine()

    If (cc > 100) Then
      desc = 40.0F    ' descuento 40%
    ElseIf (cc >= 25) Then
      desc = 20.0F    ' descuento 20%
    ElseIf (cc >= 10) Then
      desc = 10.0F    ' descuento 10%
    Else
      desc = 0.0F     ' descuento 0%
    End If
    Console.WriteLine("Descuento............. " & desc & "%")
    Console.WriteLine("Total................. " & _
                       cc * pu * (1 - desc / 100))
  End Sub
End Module
