Imports System
Imports System.IO
Imports MisClases.ES ' espacio de nombres de la clase Leer

Module CrearAlumnos
  Public Sub crearFichero(ByVal fichero As String)
    Dim bw As BinaryWriter ' salida de datos hacia el fichero
    Dim resp As Char
    Try
      ' Crear un flujo hacia el fichero que permita escribir
      ' datos de tipos primitivos y que utilice un buffer.
      bw = New BinaryWriter(New FileStream( _
                    fichero, FileMode.Create, FileAccess.Write))

      ' Declarar los datos a escribir en el fichero
      Dim nombre As String
      Dim nota As Single

      ' Leer datos de la entrada estándar y escribirlos
      ' en el fichero
      Do
        Console.Write("Nombre:              ")
        nombre = Console.ReadLine()
        Console.Write("Nota:                ")
        nota = Leer.datoSingle()

        ' Almacenar un registro en el fichero
        bw.Write(nombre)
        bw.Write(nota)

        Console.Write("desea escribir otro registro? (s/n) ")
        resp = Convert.ToChar(Console.Read())
        ' Saltar los caracteres disponibles en el flujo de entrada
        Console.ReadLine()
      Loop While (resp = "s"c)
    Finally
      ' Cerrar el flujo
      If (Not bw Is Nothing) Then bw.Close()
    End Try
  End Sub

  Public Sub Main(ByVal args() As String)
    Dim nombreFichero As String     ' nombre del fichero

    Try
      ' Obtener el nombre del fichero
      Console.Write("Nombre del fichero: ")
      nombreFichero = Console.ReadLine()

      ' Verificar si el fichero existe
      Dim resp As Char = "s"c
      If (File.Exists(nombreFichero)) Then
        Console.Write("¿El fichero existe desea sobreescribirlo? (s/n) ")
        resp = Convert.ToChar(Console.Read())
        ' Eliminar los caracteres sobrantes en el flujo de entrada
        Console.ReadLine()
      End If
      If (resp = "s"c) Then
        crearFichero(nombreFichero)
      End If
    Catch e As IOException
      Console.WriteLine("Error: " + e.Message)
    End Try
  End Sub
End Module
