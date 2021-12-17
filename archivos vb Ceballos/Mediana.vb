' Este programa utiliza la clase Leer del espacio de nombres
' MisClases.ES
Imports System
Imports MisClases.ES

Module Mediana
  Public Sub IntroducirDatos(ByVal x As Numeros)
    Dim i, n As Integer, t As Integer = x.Tamaño()

    For i = 0 To t - 1
      Console.Write("Valor: ")
      n = Leer.datoInt()
      x.AsignarValor(n, i)
    Next
  End Sub

  Public Sub Main()
    Dim n As Integer

    Console.WriteLine("¿Cuántos números quieres introducir?")
    Do
      Console.Write("Recuerda, debe ser un valor impar: ")
      n = Leer.datoInt()
    Loop While (n Mod 2 = 0)

    Dim a As Numeros = New Numeros(n)
    IntroducirDatos(a)
    a.Ordenar()
    Console.WriteLine("Mediana = " & a.Mediana())
  End Sub
End Module
