' Este programa utiliza la clase Leer del espacio de nombres
' MisClases.ES
Imports System
Imports MisClases.ES

Module DiasMes
  ' Días correspondientes a un mes de un año dado

  Public Sub Main()
    Dim días, mes, año As Integer

    Console.Write("Mes (##): ") : mes = Leer.datoInt()
    Console.Write("Año (####): ") : año = Leer.datoInt()

    Select Case (mes)
      Case 1, 3, 5, 7, 8, 10, 12
        días = 31
      Case 4, 6, 9, 11
        días = 30
      Case 2  ' febrero
        ' Es el año bisiesto?
        If ((año Mod 4 = 0) And (año Mod 100 <> 0) Or (año Mod 400 = 0)) Then
          días = 29
        Else
          días = 28
        End If
      Case Else
        Console.WriteLine("El mes no es válido")
    End Select
    If (mes >= 1 And mes <= 12) Then
      Console.WriteLine("El mes " & mes & " del año " & año & _
                        " tiene " & días & " días")
    End If
  End Sub
End Module
