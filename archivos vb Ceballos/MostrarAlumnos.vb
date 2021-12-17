Imports System
Imports System.IO

Module MostrarAlumnos
  Public Sub mostrarFichero(ByVal fichero As String)
    Dim br As BinaryReader  ' flujo entrada de datos
                            ' desde el fichero
    Try
      If (File.Exists(fichero)) Then
        ' Si existe, abrir un flujo desde el mismo para leer
        br = New BinaryReader(New FileStream( _
                      fichero, FileMode.Open, FileAccess.Read))

        ' Declarar los datos a leer desde el fichero
        Dim nombre As String
        Dim nota As Single

        Do
          ' Leer un nombre y una nota desde el fichero. Cuando
          ' se alcance el final del fichero VB lanzará una excepción
          ' del tipo EndOfStreamException.
          nombre = br.ReadString()
          nota = br.ReadSingle()

          ' Mostrar los datos nº de matrícula, nombre y calificación
          Console.WriteLine(nombre)
          Console.WriteLine(nota)
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
  End sub
End Module
