Imports System
Imports System.IO

Module LeerBytes
  Public Sub Main()
    Dim fe As FileStream
    Dim cBuffer(80) As Char
    Dim bBuffer(80) As Byte
    Dim nbytes As Integer

    Try
      ' Crear un flujo desde el fichero texto.txt
      fe = New FileStream("texto.txt", _
                          FileMode.Open, FileAccess.Read)
      ' Leer del fichero una línea de texto
      nbytes = fe.Read(bBuffer, 0, 81)
      ' Crear un objeto String con el texto leído
      Array.Copy(bBuffer, cBuffer, bBuffer.Length)
      Dim str As String = New String(cBuffer, 0, nbytes)
      ' Mostrar el texto leído
      Console.WriteLine(str)
    Catch e As IOException
      Console.WriteLine("Error: " + e.Message)
    Finally
      ' Cerrar el fichero
      If (Not fe Is Nothing) Then fe.Close()
    End Try
  End Sub
End Module
