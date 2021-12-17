Module FusionarListas
  ' Fusionar dos listas ordenadas
  Public Function Fusionar(ByVal listaA() As String, _
                           ByVal listaB() As String, _
                           ByVal listaC() As String)
    Dim ind, indA, indB, indC As Integer

    If (listaA.Length + listaB.Length = 0) Then
      Return 0
    End If

    ' Fusionar las listas A y B en la C
    While (indA < listaA.Length And indB < listaB.Length)
      If (listaA(indA).CompareTo(listaB(indB)) < 0) Then
        listaC(indC) = listaA(indA)
        indC += 1 : indA += 1
      Else
        listaC(indC) = listaB(indB)
        indC += 1 : indB += 1
      End If
    End While

    ' Los dos bucles siguientes son para prever el caso de que,
    ' lógicamente una lista finalizará antes que la otra.
    For ind = indA To listaA.Length - 1
      listaC(indC) = listaA(ind)
      indC += 1
    Next

    For ind = indB To listaB.Length - 1
      listaC(indC) = listaB(ind)
      indC += 1
    Next

    Return 1
  End Function

  Public Sub Main()
    ' Iniciamos las listas a ordenar (puede sustituir este
    ' proceso, por otro de lectura con el fin de tomar los
    ' datos de la entrada estándar).
    Dim lista1() As String = {"Ana", "Carmen", "David", _
                              "Francisco", "Javier", "Jesús", _
                              "José", "Josefina", "Luis", _
                              "María", "Patricia", "Sonia"}

    Dim lista2() As String = {"Agustín", "Belén", "Daniel", _
                              "Fernando", "Manuel", _
                              "Pedro", "Rosa", "Susana"}

    ' Declarar la matriz que va a almacenar el resultado de
    ' fusionar las dos anteriores
    Dim lista3(lista1.Length + lista2.Length) As String

    ' Fusionar lista1 y lista2 y almacenar el resultado en lista3.
    ' El método "Fusionar" devolverá un 0 cuando no se pueda
    ' realizar la fusión.
    Dim ind, r As Integer
    r = Fusionar(lista1, lista2, lista3)

    ' Escribir la matriz resultante
    If (r <> 0) Then
      For ind = 0 To lista3.Length - 1
        System.Console.WriteLine(lista3(ind))
      Next
    Else
      System.Console.WriteLine("Error")
    End If
  End Sub
End Module

