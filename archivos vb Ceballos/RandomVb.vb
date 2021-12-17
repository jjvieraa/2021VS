Imports System

Module RandomVb
  ' Obtener números aleatorios dentro de un rango
  Public Sub Main()
    Dim límiteSup As Integer = 49, límiteInf As Integer = 1
    Dim n(5) As Integer
    ' Crear un objeto de la clase Random
    Dim rnd As Random = New Random()

    Dim i, k As Integer
    For i = 0 To n.Length - 1
      ' Obtener un número aleatorio
      n(i) = Math.Floor((límiteSup - límiteInf + 1) * _
                         rnd.NextDouble() + límiteInf)
      ' Verificar si ya existe el último número obtenido
      For k = 0 To i - 1
        If (n(k) = n(i)) Then ' ya existe
          i -= 1  ' i será incrementada por el For externo
          Exit For ' salir de este For
        End If
      Next
    Next
    ' Ordenar la matriz
    Array.Sort(n)
    ' Mostrar la matriz
    For i = 0 To n.Length - 1
      System.Console.Write(n(i) & " ")
    Next
    System.Console.WriteLine()
  End Sub
End Module

