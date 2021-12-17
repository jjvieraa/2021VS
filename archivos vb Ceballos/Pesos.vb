' Este programa utiliza la clase Leer del espacio de nombres
' MisClases.ES
Imports System
Imports MisClases.ES

Public Class CPesos
  Private peso_inf As Integer = 10
  Private peso_sup As Integer = 100
  Private lista() As Integer

  Public Sub CrearObj(ByVal numero As Integer)
    Dim i, peso As Integer
    lista = New Integer(peso_sup - peso_inf + 1) {}

    For i = 0 To numero - 1
      Console.Write("Peso del alumno " & (i + 1) & ": ")
      peso = Leer.datoInt()
      While ((peso < 10) Or (peso > 100))
        Console.Write("Peso incorrecto, (debe estar entre " & _
                       peso_inf & "-" & peso_sup & "): ")
        peso = Leer.datoInt()
      End While
      lista(peso - 10) += 1
    Next
  End Sub

  Public Sub Mostrar()
    Dim j, contador As Integer
    Console.WriteLine()
    Console.WriteLine(" Peso       Número de Alumnos")
    Console.WriteLine("------------------------------")

    For j = 0 To peso_sup - peso_inf
      If (lista(j) > 0) Then
        System.Console.Write("  " & (j + 10) & "        ")
        For contador = 0 To lista(j) - 1
          System.Console.Write("*")
        Next
        System.Console.WriteLine()
      End If
    Next
  End Sub
End Class

Module Pesos
  Public Sub Main()
    Dim numAlumnos As Integer
    Dim p As CPesos = New CPesos()
    System.Console.Write("Introduce el número de alumnos: ")
    numAlumnos = Leer.datoInt()
    p.CrearObj(numAlumnos)
    p.Mostrar()
  End Sub
End Module

