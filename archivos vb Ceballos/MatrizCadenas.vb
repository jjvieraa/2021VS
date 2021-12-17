' Este programa utiliza la clase Leer del espacio de nombres
' MisClases.ES
Imports System
Imports MisClases.ES

Module MatrizCadenas
  Public Sub Main()
    Dim nFilas, fila As Integer
    Do
      Console.Write("Número de filas de la matriz:  ")
      nFilas = Leer.datoInt()
    Loop While (nFilas < 1) ' no permitir un valor cero o negativo

    ' Matriz de cadenas de caracteres
    Dim nombre(nFilas - 1) As String

    Console.WriteLine("Escriba los nombres que desea introducir.")
    Console.WriteLine("Puede finalizar pulsando las teclas [Ctrl][Z].")
    For fila = 0 To nFilas - 1
      Console.Write("Nombre(" & fila & "): ")
      nombre(fila) = Console.ReadLine()
      ' Si se pulsó [Ctrl][Z], salir del bucle
      If (nombre(fila) = Nothing) Then Exit For
    Next
    Console.WriteLine()
    nFilas = fila ' número de filas leídas

    Dim respuesta As Char
    Do
      Console.Write("¿Desea visualizar el contenido de la matriz? (s/n): ")
      respuesta = Convert.ToChar(Console.Read())
      Console.ReadLine() ' limpiar el flujo de entrada
    Loop While (respuesta <> "s"c And respuesta <> "n"c)

    If (respuesta = "s"c) Then
      ' Visualizar la lista de nombres
      Console.WriteLine()
      For fila = 0 To nFilas - 1
        Console.WriteLine(nombre(fila))
      Next
    End If
  End Sub
End Module

