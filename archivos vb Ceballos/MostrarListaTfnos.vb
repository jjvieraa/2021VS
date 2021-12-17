Imports System
Imports System.IO

Module MostrarListaTfnos
  Public Sub mostrarFichero(ByVal fichero As String)
    Dim br As BinaryReader  ' flujo entrada de datos
                            ' desde el fichero
    Try
      ' Verificar si el fichero existe
      If (File.Exists(fichero)) Then
        ' Si existe, abrir un flujo desde el mismo para leer
        br = New BinaryReader(New FileStream( _
                      fichero, FileMode.Open, FileAccess.Read))

        ' Declarar los datos a leer desde el fichero
        Dim nombre, dirección As String
        Dim teléfono As Long

        Do
          ' Leer un nombre, una dirección y un teléfono desde el
          ' fichero. Cuando se alcance el final del fichero el
          ' método utilizado para leer lanzará una excepción del
          ' tipo EndOfStreamException.
          nombre = br.ReadString()
          dirección = br.ReadString()
          teléfono = br.ReadInt64()

          ' Mostrar los datos nombre, dirección y teléfono
          Console.WriteLine(nombre)
          Console.WriteLine(dirección)
          Console.WriteLine(teléfono)
          Console.WriteLine()
        Loop While (True)
      Else
        Console.WriteLine("El fichero no existe")
      End If
    Catch e As EndOfStreamException
      Console.WriteLine("Fin del listado")
    Finally
      ' Cerrar el flujo
      If (Not br Is Nothing) Then br.Close()
    End Try
  End Sub

  Public Sub Main(ByVal args() As String)
    Try
      If (args.Length = 0) Then
        ' Obtener el nombre del fichero
        Console.Write("Nombre del fichero: ")
        Dim nombreFichero As String = Console.ReadLine()
        mostrarFichero(nombreFichero)
      Else
        mostrarFichero(args(0))
      End If
    Catch e As IOException
      Console.WriteLine("Error: " + e.Message)
    End Try
  End Sub
End Module
