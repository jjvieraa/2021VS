Imports System
Imports System.IO

Module LeerCars
  Public Sub Main()
    Dim sr As StreamReader
    Dim str As String

    Try
      ' Crear un flujo desde el fichero doc.txt
      sr = New StreamReader("doc.txt")
      ' Leer del fichero una línea de texto
      str = sr.ReadLine()
      While (str <> Nothing)
        ' Mostrar la línea leída
        Console.WriteLine(str)
        ' Leer la línea siguiente
        str = sr.ReadLine()
      End While
    Catch e As IOException
      Console.WriteLine("Error: " + e.Message)
    Finally
      ' Cerrar el fichero
      If (Not sr Is Nothing) Then sr.Close()
    End Try
  End Sub
End Module
