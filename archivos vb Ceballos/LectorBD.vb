Imports System
Imports System.Data
Imports System.Data.OleDb

Public Class BaseDeDatos
  Private ConexionConBD As OleDbConnection
  Private Orden As OleDbCommand
  Private Lector As OleDbDataReader

  Public Sub LeerDeBaseDeDatos()
    'Crear la conexión con la base de datos
    Dim strConexión As String = "Provider=Microsoft.Jet.OLEDB.4.0;" & _
                                "Data Source=C:.\..\..\tfnos.mdb;"
    ConexionConBD = New OleDbConnection(strConexión)

    'Crear una consulta
    Dim Consulta As String = "SELECT nombre, telefono FROM telefonos"
    Orden = New OleDbCommand(Consulta, ConexionConBD)

    'Abrir la base de datos
    ConexionConBD.Open()
    'ExecuteReader hace la consulta y devuelve un OleDbDataReader
    Lector = Orden.ExecuteReader()
    'Llamar siempre a Read antes de acceder a los datos
    While Lector.Read() 'siguiente registro
      Console.WriteLine(Lector("nombre") + " " + _
                        Lector("telefono"))
    End While
    'Llamar siempre a Close una vez finalizada la lectura
    Lector.Close()
  End Sub

  Public Sub CerrarConexion()
    ' Cerrar la conexión cuando ya no sea necesaria
    If (Not Lector Is Nothing) Then
      Lector.Close()
    End If
    If (Not ConexionConBD Is Nothing) Then
      ConexionConBD.Close()
    End If
  End Sub

  Public Shared Sub Main()
    Dim bd As BaseDeDatos = New BaseDeDatos()
    Try
      bd.LeerDeBaseDeDatos()
    Catch e As Exception
      Console.WriteLine("Error: " + e.Message)
    Finally
      bd.CerrarConexion()
    End Try
  End Sub
End Class
