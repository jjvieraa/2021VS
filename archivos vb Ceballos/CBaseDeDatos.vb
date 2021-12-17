' Definición de la clase CBaseDeDatos.
'
Imports System
Imports System.IO

Public Class CBaseDeDatos
  ' Atributos
  Private fs As FileStream          ' flujo subyacente
  Private bw As BinaryWriter        ' flujo hacia el fichero
  Private br As BinaryReader        ' flujo desde el fichero
  Private ficheroActual As String   ' nombre del fichero
  Private nregs As Integer          ' número de registros
  Private tamañoReg As Integer = 50 ' tamaño del registro en bytes
  Private borrar As Boolean = False ' True si se borran registros

  ' Métodos
  Public Sub New(fichero As String) ' constructor
    ' ¿Se trata de un fichero?
    If (Directory.Exists(fichero)) Then
      Throw New IOException(Path.GetFileName(fichero) + " no es un fichero")
    End If

    ' Asignar valores a los atributos
    fs = New FileStream(fichero, FileMode.OpenOrCreate, FileAccess.ReadWrite)
    bw = New BinaryWriter(fs) ' flujo hacia el fichero
    br = New BinaryReader(fs) ' flujo desde el fichero
    ficheroActual = fichero
    ' Como es casi seguro que el último registro no ocupe el
    ' tamaño fijado, utilizamos Ceiling para redondear por encima.
    nregs = Math.Ceiling(fs.Length / tamañoReg)
  End Sub

  Public Sub cerrar()
    bw.Close() : br.Close() : fs.Close()
  End Sub

  Public Function longitud() As Integer
    Return nregs ' número de registros
  End Function

  Public Function ponerValorEn(i As Integer, objeto As CRegistro) As Boolean
    If (i >= 0 And i <= nregs) Then
      ' Los 1 o 2 primeros bytes que escribe Write indican la
      ' longitud de la cadena que escribe a continuación,
      ' información utilizada por ReadString para recuperarla.
      If (objeto.tamaño() + 2 > tamañoReg) Then
        Console.WriteLine("tamaño del registro excedido")
      Else
        ' Situar el puntero de L/E en el registro i.
        bw.BaseStream.Seek(i * tamañoReg, SeekOrigin.Begin)
        ' Sobreescribir el registro con la nueva información
        bw.Write(objeto.obtenerReferencia())
        bw.Write(objeto.obtenerPrecio())
        Return True
      End If
    Else
      Console.WriteLine("número de registro fuera de límites")
    End If
    Return False
  End Function

  Public Sub añadir(obj As CRegistro)
    ' Añadir un registro al final del fichero e incrementar
    ' el número de registros
    If (ponerValorEn(nregs, obj)) Then nregs += 1
  End Sub

  Public Function valorEn(i As Integer) As CRegistro
    If (i >= 0 And i < nregs) Then
      ' Situar el puntero de L/E en el registro i.
      br.BaseStream.Seek(i * tamañoReg, SeekOrigin.Begin)

      Dim referencia As String
      Dim precio As Double
      ' Leer la información correspondiente al registro i.
      referencia = br.ReadString()
      precio = br.ReadDouble()

      ' Devolver el objeto CRegistro correspondiente.
      Return New CRegistro(referencia, precio)
    Else
      Console.WriteLine("número de registro fuera de límites")
      Return Nothing
    End If
  End Function

  Public Function buscar(str As String, nreg As Integer) As Integer
    ' Buscar un registro por una subcadena de la referencia
    ' a partir de un registro determinado. Si se encuentra,
    ' se devuelve el número de registro, o -1 en otro caso.
    Dim obj As CRegistro
    Dim refer As String
    If (str = Nothing) Then Return -1
    If (nreg < 0) Then nreg = 0

    Dim reg_i As Integer
    For reg_i = nreg To nregs - 1
      ' Obtener el registro reg_i
      obj = valorEn(reg_i)
      ' Obtener su referencia
      refer = obj.obtenerReferencia()
      ' ¿str está contenida en referencia?
      If (refer.IndexOf(str) > -1) Then
        Return reg_i ' devolver el número de registro
      End If
    Next
    Return -1 ' la búsqueda falló
  End Function

  Public Function eliminar(refer As String) As Boolean
    Dim obj As CRegistro
    ' Buscar la referencia y marcar el registro correspondiente
    ' para poder eliminarlo en otro proceso.
    Dim reg_i As Integer
    For reg_i = 0 To nregs - 1
      ' Obtener el registro reg_i
      obj = valorEn(reg_i)
      ' ¿Tiene la referencia refer?
      If (refer.CompareTo(obj.obtenerReferencia()) = 0) Then
        ' Marcar el registro con la referencia "borrar"
        obj.asignarReferencia("borrar")
        borrar = True
        ' Grabarlo
        ponerValorEn(reg_i, obj)
        Return True
      End If
    Next
    Return False
  End Function

  Public Function tieneRegsEliminados() As Boolean
    Return borrar
  End Function

  Public Sub actualizar()
    ' Crear un fichero temporal.
    Dim ficheroTemp As String = "articulos.tmp"
    Dim ftemp As CBaseDeDatos = New CBaseDeDatos(ficheroTemp)

    ' Copiar en el fichero temporal todos los registros del
    ' fichero actual que no estén marcados para "borrar"
    Dim obj As CRegistro
    Dim reg_i As Integer
    For reg_i = 0 To nregs - 1
      obj = valorEn(reg_i)
      If (obj.obtenerReferencia().CompareTo("borrar") <> 0) Then
        ftemp.añadir(obj)
      End If
    Next

    ' Cerrar ambos ficheros, copiar el fichero temporal sobre
    ' el actual y borrar el fichero temporal
    Me.cerrar()          ' cerrar el fichero actual
    ftemp.cerrar()       ' cerrar el fichero temporal
    File.Copy(ficheroTemp, ficheroActual, True)
    File.Delete(ficheroTemp)
  End Sub
End Class
