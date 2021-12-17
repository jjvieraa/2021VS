class CDesplazar
  Private texto As String
  Private tamaño As Integer

  Public Sub leerTexto()
    System.Console.Write("Introduce un texto: ")
    texto = System.Console.ReadLine()
    tamaño = texto.Length
  End Sub

  Public Sub mostrarTexto()
    System.Console.WriteLine(texto)
  End Sub

  Public Sub desplazarUnCaracter()
    Dim i As Integer
    Dim ultimo As Char
    ' Convertir el string en una matriz de caracteres
    Dim cadChar(tamaño - 1) As Char
    texto.CopyTo(0, cadChar, 0, tamaño)

    ultimo = cadChar(tamaño - 1)

    ' Desplazar el texto una posición a la derecha. El último
    ' pasa a ser el primero.
    For i = 0 To tamaño - 2
      cadChar(tamaño - (i + 1)) = cadChar(tamaño - (i + 2))
    Next

    cadChar(0) = ultimo
    ' Convertir la matriz de caracteres en un String
    texto = New String(cadChar)
  End Sub

  Public Function numCars() As Integer
    Return tamaño
  End Function
End Class

