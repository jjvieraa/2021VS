Imports System
Imports System.IO
Imports MisClases.ES ' espacio de nombres de la clase Leer

Module CrearListaTfnos
  Public Sub crearFichero(ByVal fichero As String)
    Dim bw As BinaryWriter ' salida de datos hacia el fichero
    Dim resp As Char
    Try
      ' Crear un flujo hacia el fichero que permita escribir
      ' datos de tipos primitivos y cadenas de caracteres.
      bw = New BinaryWriter(New FileStream( _
                    fichero, FileMode.Create, FileAccess.Write))

      ' Declarar los datos a escribir en el fichero
      Dim nombre, dirección As String
      Dim teléfono As Long

      ' Leer datos de la entrada estándar y escribirlos
      ' en el fichero
      Do
        Console.Write("nombre:    ") : nombre = Console.ReadLine()
        Console.Write("dirección: ") : dirección = Console.ReadLine()
        Console.Write("teléfono:  ") : teléfono = Leer.datoLong()

        ' Almacenar un nombre, una dirección y un teléfono en
        ' el fichero
        bw.Write(nombre)
        bw.Write(dirección)
        bw.Write(teléfono)

        Console.Write("¿desea escribir otro registro? (s/n) ")
        resp = Convert.ToChar(Console.Read())
        ' Eliminar los caracteres sobrantes en el flujo de entrada
        Console.ReadLine()
      Loop While (resp = "s"c)
    Finally
      ' Cerrar el flujo
      If (Not bw Is Nothing) Then bw.Close()
    End Try
  End Sub

  Public Sub Main()
    Dim nombreFichero As String     ' nombre del fichero

    Try
      ' Obtener el nombre del fichero
      Console.Write("Nombre del fichero: ")
      nombreFichero = Console.ReadLine()

      ' Verificar si el fichero existe
      Dim resp As Char = "s"c
      If (File.Exists(nombreFichero)) Then
        Console.Write("El fichero existe. ¿Desea sobreescribirlo? (s/n) ")
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
