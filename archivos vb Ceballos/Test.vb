Imports System
Imports System.IO

Module Test
  Public Sub Main(ByVal args() As String)
    If (args.Length <> 2) Then
      Console.WriteLine("Sintaxis: Ficheros " + _
                        "<fichero1>" + " <fichero2>")
    Else
      Dim ficheros As CFicheros = New CFicheros()
      Try
        ficheros.abrir(args(0), args(1))
        ficheros.fusionar()
      Catch e As IOException
        Console.WriteLine("Error: " + e.Message)
      End Try
    End If
  End Sub
End Module
