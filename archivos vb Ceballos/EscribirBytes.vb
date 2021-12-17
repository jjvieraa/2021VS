Imports System
Imports System.IO

Module EscribirBytes
  Public Sub Main()
    Dim fs As FileStream
    Dim buffer(80) As Byte
    Dim nbytes, car As Integer
    Dim CR As Integer = 13

    Try
      ' Crear un flujo hacia el fichero texto.txt
      fs = New FileStream("texto.txt", _
                          FileMode.Create, FileAccess.Write)

      Console.WriteLine( _
        "Escriba el texto que desea almacenar en el fichero:")
      car = Console.Read()
      While (car <> CR And nbytes < buffer.Length)
        buffer(nbytes) = Convert.ToByte(car)
        nbytes += 1
        car = Console.Read()
      End While

      ' Escribir la línea de texto en el fichero
      fs.Write(buffer, 0, nbytes)
    Catch e As IOException
      Console.WriteLine("Error: " + e.Message)
    Finally
      If (Not fs Is Nothing) Then fs.Close()
    End Try
  End Sub
End Module

