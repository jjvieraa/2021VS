Imports System
Imports System.IO

Module CopiarFichero
  Public Sub copiar(fichFuente As String, fichDestino As String)
    ' Si el fichero fuente y el destino son el mismo fichero ...
    If (fichFuente.CompareTo(fichDestino) = 0) Then
        Throw New IOException("No se puede copiar un fichero " + _
                              "sobre sí mismo")
    End If

    ' Definiciones de variables, referencias y objetos
    Dim fFuente As FileStream = Nothing
    Dim fDestino As FileStream = Nothing

    Try
      ' Asegurarse de que el fichero "fichFuente" existe
      If (Not File.Exists(fichFuente)) Then
        Throw New IOException("No existe el fichero " + fichFuente)
      End If

      ' Si "fichDestino" existe, asegurarse de que no está
      ' protegido contra escritura y preguntar si se quiere
      ' sobreescribir.
      If (File.Exists(fichDestino)) Then
        Dim atributos As FileAttributes = File.GetAttributes(fichDestino)
        If ((atributos And FileAttributes.ReadOnly) <> 0) Then
          Throw New IOException("No se puede escribir en " + _
                                "el fichero " + fichDestino)
        End If
        ' Indicar que el fichero ya existe y preguntar si se
        ' desea sobreescribir.
        Console.Write("El fichero " + fichDestino + " existe. " + _
                      "¿Desea sobreescribirlo? (s/n): ")
        ' Leer la respuesta
        Dim resp As Char = Convert.ToChar(Console.Read())
        Console.ReadLine() ' limpiar el buffer de entrada
        If (resp = "n"c Or resp = "N"c) Then
          Throw New IOException("Copia cancelada")
        End If
      Else
        ' Si se ha introducido una ruta absoluta, por ejemplo:
        ' c:\ejemplos\vb\mifichero
        ' y "mifichero" no existe verificar que el directorio
        ' padre "c:\ejemplos\vb" existe y no está protegido
        ' contra escritura
        Dim infoDir As DirectoryInfo ' información sobre el directorio
        infoDir = Directory.GetParent(fichDestino)
        ' Ruta del directorio padre de fichDestino
        Dim dirPadre As String = infoDir.FullName
        If (Not Directory.Exists(dirPadre)) Then
          Throw New IOException("El directorio " + dirPadre + _
                                " no existe")
        End If
        Dim atributos As FileAttributes = File.GetAttributes(dirPadre)
        If ((atributos And FileAttributes.ReadOnly) <> 0) Then
          Throw New IOException("No se puede escribir en el " + _
                                "directorio " + dirPadre)
        End If
      End If

      ' Para realizar la copia, abrir un flujo de entrada desde
      ' el fichero fuente y otro de salida hacia el destino.
      fFuente = New FileStream(fichFuente, FileMode.Open, _
                               FileAccess.Read)
      fDestino = New FileStream(fichDestino, FileMode.Create, _
                                FileAccess.Write)

      ' Copiar el fichero fuente en el destino
      Dim buffer(1024) As Byte
      Dim nbytes As Integer
      While (True)
        nbytes = fFuente.Read(buffer, 0, 1024)
        If (nbytes = 0) Then Exit While ' se llegó al final del fichero
        fDestino.Write(buffer, 0, nbytes)
      End While
    Catch e As ArgumentException
      Console.WriteLine("El nombre del directorio o del fichero " + _
                        "no es válido")
    Finally
      ' Cerrar los flujos que estén abiertos
      If (Not fFuente Is Nothing) Then fFuente.Close()
      If (Not fDestino Is Nothing) Then fDestino.Close()
    End Try
  End Sub

  Public Sub Main(args() As String)
    ' Main debe recibir dos parámetros: el fichero fuente y
    ' el destino.
    If (args.Length <> 2) Then
      Console.WriteLine("Sintaxis: CopiarFichero " + _
                        "<fichero fuente> <fichero destino>")
    Else
      Try
        copiar(args(0), args(1)) ' realizar la copia
      Catch e As IOException
        Console.WriteLine("Error: " + e.Message)
      End Try
    End If
  End Sub
End Module
