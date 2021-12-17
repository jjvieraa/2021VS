Imports System
Imports System.IO

Module Grep
  Public Function BuscarCadena(cadena1 As String, _
                               cadena2 As String) As Boolean
    ' ¿cadena2 está contenida en cadena1?
    If (cadena1.IndexOf(cadena2) > -1) Then
      Return True  ' sí
    Else
      Return False ' no
    End If
  End Function

  Public Sub BuscarEnFich(nombrefich As String, cadena As String)
    ' Definiciones de variables
    Dim sr As StreamReader

    Try
      ' Asegurarse de que el fichero existe
      If (Not File.Exists(nombrefich)) Then
        Console.WriteLine("No existe el fichero " + nombrefich)
        Return
      End If

      ' Abrir un flujo de entrada desde el fichero fuente
      sr = New StreamReader(nombrefich)

      ' Buscar cadena en el fichero fuente
      Dim linea As String
      Dim nroLinea As Integer

      linea = sr.ReadLine()
      While (Not linea Is Nothing)
        ' Si se alcanzó el final del fichero,
        ' Readline devuelve Nothing
        nroLinea += 1 ' contador de líneas
        If (BuscarCadena(linea, cadena)) Then
          Console.WriteLine(nombrefich & " " & nroLinea & " " & _
                            linea)
        End If
        linea = sr.ReadLine()
      End While
    Catch e As IOException
      Console.WriteLine("Error: " + e.Message)
    Finally
      ' Cerrar el flujo
      If (Not sr Is Nothing) Then sr.Close()
    End Try
  End Sub

  Public Sub Main(args() As String)
    ' Main debe recibir dos o más parámetros: la cadena a buscar
    ' y los ficheros fuente. Por ejemplo:
    ' Grep Catch Grep.vb Leer.vb

    If (args.Length < 2) Then
      Console.WriteLine("Sintaxis: Grep " + "<cadena> " + _
                         "<fichero 1> <fichero 2> ...")
    Else
      Dim i As Integer
      For i = 1 To args.Length - 1
        ' Buscar args(0) en args(i)
        BuscarEnFich(args(i), args(0))
      Next
    End If
  End Sub
End Module

