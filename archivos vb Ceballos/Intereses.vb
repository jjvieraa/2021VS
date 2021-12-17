' Este programa utiliza la clase Leer del espacio de nombres
' MisClases.ES

Imports System
Imports MisClases.ES

Module Intereses
  Public Sub Main()
    Dim c, intereses, capital As Double
    Dim r As Single
    Dim t As Integer

    Console.Write("Capital invertido: ")
    c = Leer.datoDouble()
    Console.Write("A un % anual del: ")
    r = Leer.datoSingle()
    Console.Write("Durante cuántos días: ")
    t = Leer.datoInt()

    intereses = c * r * t / (360 * 100)
    capital = c + intereses

    Console.WriteLine()
    Console.WriteLine("Intereses producidos... " & intereses)
    Console.WriteLine("Capital acumulado...... " & capital)
  End Sub
end module
