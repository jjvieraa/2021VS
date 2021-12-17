Imports System
Imports System.IO
Imports System.Environment

Module EscribirCars
  Public Sub Main()
    Dim sw As StreamWriter
    Dim str As String

    Try
      ' Obtener el nombre del fichero de la entrada estándar
      Console.Write("Nombre del fichero: ")
      str = Console.ReadLine()

      Dim resp As Char = "s"c
      If (File.Exists(str)) Then
        Console.Write("El fichero existe ¿desea sobreescribirlo? (s/n) ")
        resp = Convert.ToChar(Console.Read())
        ' Saltar los bytes no leídos del flujo de entrada estándar
        Console.ReadLine()
      End If
      If (resp <> "s"c) Then Return

      ' Crear un flujo hacia el fichero doc.txt
      sw = New StreamWriter(str)

      Console.WriteLine( _
        "Escriba las líneas de texto a almacenar en el fichero." _
        + NewLine + "Finalice cada línea pulsando la tecla " _
        + "<Entrar>." + NewLine + "Para finalizar pulse sólo " _
        + "la tecla <Entrar>." + NewLine)
      ' Leer una línea de la entrada estándar
      str = Console.ReadLine()
      While (str.Length <> 0)
        ' Escribir la línea leída en el fichero
        sw.WriteLine(str)
        ' Leer la línea siguiente
        str = Console.ReadLine()
      End While
    Catch e As UnauthorizedAccessException
      Console.WriteLine("Error: " + e.Message)
    Catch e As IOException
      Console.WriteLine("Error: " + e.Message)
    Finally
      If (Not sw Is Nothing) Then sw.Close()
    End Try
  End Sub
End Module

