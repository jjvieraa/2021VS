' Definición de la clase CListaTfnos.
'
Imports System
Imports System.IO

Public Class CListaTfnos
  Private fs As FileStream           ' flujo subyacente
  Private bw As BinaryWriter         ' flujo hacia el fichero
  Private br As BinaryReader         ' flujo desde el fichero
  Private nregs As Integer           ' número de registros
  Private tamañoReg As Integer = 140 ' tamaño del registro en bytes
  Private regsEliminados As Boolean = False ' true si se
                                     ' eliminaron registros

  Public Sub New(fichero As String)
    If (Directory.Exists(fichero)) Then
      Throw New IOException(Path.GetFileName(fichero) & " no es un fichero")
    End If
    fs = New FileStream(fichero, FileMode.OpenOrCreate, FileAccess.ReadWrite)
    bw = New BinaryWriter(fs)
    br = New BinaryReader(fs)

    ' Como es casi seguro que el último registro no ocupe el
    ' tamaño fijado, utilizamos Ceiling para redondear por encima.
    nregs = Math.Ceiling(fs.Length / tamañoReg)
  End Sub

  Public Sub cerrarFichero()
    bw.Close() : br.Close() : fs.Close()
  End Sub

  Public Function númeroDeRegs() As Integer
    Return nregs ' número de registros
  End Function

  Public Function escribirReg(i As Integer, obj As CPersona) As Boolean
    If (i >= 0 And i <= nregs) Then
      If (obj.tamaño() + 4 > tamañoReg) Then
        Console.WriteLine("tamaño del registro excedido")
      Else
        ' Situar el puntero de L/E
        bw.BaseStream.Seek(i * tamañoReg, SeekOrigin.Begin)
        bw.Write(obj.obtenerNombre())
        bw.Write(obj.obtenerDirección())
        bw.Write(obj.obtenerTeléfono())
        Return True
      End If
    Else
      Console.WriteLine("número de registro fuera de límites")
    End If
    Return False
  End Function

  Public Sub añadirReg(obj As CPersona)
    If (escribirReg(nregs, obj)) Then nregs += 1
  End Sub

  Public Function leerReg(i As Integer) As CPersona
    If (i >= 0 And i < nregs) Then
      ' Situar el puntero de L/E
      br.BaseStream.Seek(i * tamañoReg, SeekOrigin.Begin)

      Dim nombre, dirección As String
      Dim teléfono As Long
      nombre = br.ReadString()
      dirección = br.ReadString()
      teléfono = br.ReadInt64()

      Return New CPersona(nombre, dirección, teléfono)
    Else
      Console.WriteLine("número de registro fuera de límites")
      Return Nothing
    End If
  End Function

  Public Function eliminarReg(tel As Long) As Boolean
    Dim obj As CPersona
    ' Buscar el teléfono y marcar el registro para
    ' posteriormente eliminarlo
    Dim reg_i As Integer
    For reg_i = 0 To nregs - 1
      obj = leerReg(reg_i)
      If (obj.obtenerTeléfono() = tel) Then
        obj.asignarTeléfono(0)
        escribirReg(reg_i, obj)
        regsEliminados = True
        Return True
      End If
    Next
    Return False
  End Function

  Public Function tieneRegsEliminados() As Boolean
    Return regsEliminados
  End Function

  Public Function buscarReg(str As String, pos As Integer) As Integer
    ' Buscar un registro por una subcadena del nombre
    ' a partir de un registro determinado
    Dim obj As CPersona
    Dim nom As String
    If (str = Nothing) Then Return -1
    If (pos < 0) Then pos = 0
    Dim reg_i As Integer
    For reg_i = pos To nregs - 1
      obj = leerReg(reg_i)
      nom = obj.obtenerNombre()
      ' str está contenida en nom?
      If (nom.IndexOf(str) > -1) Then
        Return reg_i
      End If
    Next
    Return -1
  End Function
End Class
