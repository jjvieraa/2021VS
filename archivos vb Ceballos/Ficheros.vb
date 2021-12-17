Imports System
Imports System.IO

Public Class CFicheros
  Private Class CRegistro
    Public nombre As String
    Public nota As Single
  End Class

  ' Flujos
  Private br1 As BinaryReader = Nothing  ' entrada de datos desde el fichero1
  Private fichero1 As String = Nothing   ' nombre del fichero1
  Private br2 As BinaryReader = Nothing  ' entrada de datos desde el fichero2
  Private fichero2 As String = Nothing   ' nombre del fichero2
  Private bw As BinaryWriter = Nothing   ' salida de datos hacia el fichero final
  Private fichero As String = Nothing    ' nombre del fichero final

  Public Sub abrir(ByVal nomFichero1 As String, ByVal nomFichero2 As String)
    fichero1 = nomFichero1
    fichero2 = nomFichero2

    ' Verificar si el fichero existe
    If (File.Exists(fichero1)) Then
      ' Si existe, abrir un flujo desde el mismo para leer
      br1 = New BinaryReader(New FileStream( _
                    fichero1, FileMode.Open, FileAccess.Read))
    Else
      Console.WriteLine("El fichero " + fichero1 + " no existe")
      Return
    End If

    ' Verificar si el fichero existe
    If (File.Exists(fichero2)) Then
      ' Si existe, abrir un flujo desde el mismo para leer
      br2 = New BinaryReader(New FileStream( _
                    fichero2, FileMode.Open, FileAccess.Read))
    Else
      Console.WriteLine("El fichero " + fichero2 + " no existe")
      Return
    End If

    ' Fichero final
    fichero = "temporal"

    ' Abrir un flujo hacia el mismo
    bw = New BinaryWriter(New FileStream( _
                  fichero, FileMode.Create, FileAccess.Write))
  End Sub

  Public Sub fusionar()
    ' Variable para leer desde el fichero1
    Dim regF1 As CRegistro = New CRegistro()
    Dim finFichero1 As Boolean = False

    ' Variable para leer desde el fichero2
    Dim regF2 As CRegistro = New CRegistro()
    Dim finFichero2 As Boolean = False

    Dim i As Integer ' resultado de una comparación

    Try
      ' Leer un un nombre y una nota desde el fichero1.
      ' Cuando se alcance el final del fichero VB
      ' lanzará una excepción del tipo EndOfStreamException.
      regF1.nombre = br1.ReadString()
      regF1.nota = br1.ReadSingle()

      ' Leer un un nombre y una nota desde el fichero2.
      ' Cuando se alcance el final del fichero VB
      ' lanzará una excepción del tipo EndOfStreamException.
      regF2.nombre = br2.ReadString()
      regF2.nota = br2.ReadSingle()

      While (True)
        If (finFichero1 And finFichero2) Then Exit While

        i = regF1.nombre.CompareTo(regF2.nombre)

        ' Forzar el resultado de la comparación a un valor
        ' determinado si alguno de los dos ficheros finalizó, 
        ' para que lea y grabe del que aún no finalizó.
        If (finFichero1) Then
          i = 1
        ElseIf (finFichero2) Then
          i = -1
        End If

        If (i = 0) Then ' regF1.nombre = regF2.nombre
          ' El mismo alumno. Grabar regF2
          bw.Write(regF2.nombre)
          bw.Write(regF2.nota)

          ' Leer de nuevo de ambos ficheros
          Try
            regF1.nombre = br1.ReadString()
            regF1.nota = br1.ReadSingle()
          Catch e As EndOfStreamException
            Console.WriteLine("Fin del fichero1")
            finFichero1 = True
          End Try

          Try
            regF2.nombre = br2.ReadString()
            regF2.nota = br2.ReadSingle()
          Catch e As EndOfStreamException
            Console.WriteLine("Fin del fichero2")
            finFichero2 = True
          End Try
        ElseIf (i > 0) Then ' regF1.nombre > regF2.nombre
          ' Grabar regF2
          bw.Write(regF2.nombre)
          bw.Write(regF2.nota)

          ' Leer de nuevo de fichero2
          Try
            regF2.nombre = br2.ReadString()
            regF2.nota = br2.ReadSingle()
          Catch e As EndOfStreamException
            Console.WriteLine("Fin del fichero2")
            finFichero2 = True
          End Try
        Else ' regF2.nombre > regF1.nombre
          ' Grabar regF1
          bw.Write(regF1.nombre)
          bw.Write(regF1.nota)

          ' Leer de nuevo de fichero1
          Try
            regF1.nombre = br1.ReadString()
            regF1.nota = br1.ReadSingle()
          Catch e As EndOfStreamException
            Console.WriteLine("Fin del fichero1")
            finFichero1 = True
          End Try
        End If
      End While

    Catch e As EndOfStreamException
      Console.WriteLine("Fin del fichero1 y fichero2")
    Finally
      ' Cerrar flujos
      If (Not br1 Is Nothing) Then br1.Close()
      If (Not br2 Is Nothing) Then br2.Close()
      If (Not bw Is Nothing) Then bw.Close()
      ' Copiar en el fichero alumnos todos los registros del temporal
      ' excepto los que en el campo nota tengan -1.
      copiar("alumnos", "temporal")
    End Try
  End Sub

  Public Sub copiar(ByVal fichero1 As String, ByVal fichero2 As String)
    ' Copiar fichero2 en fichero1

    ' Verificar si el fichero existe
    If (File.Exists(fichero2)) Then
      ' Si existe, abrir un flujo desde el mismo para leer
      br2 = New BinaryReader(New FileStream( _
                    fichero2, FileMode.Open, FileAccess.Read))
    Else
      Console.WriteLine("El fichero " + fichero2 + " no existe")
      Return
    End If

    ' Abrir un flujo hacia el fichero1
    bw = New BinaryWriter(New FileStream( _
                  fichero1, FileMode.Create, FileAccess.Write))

    ' Variable para leer desde el fichero2
    Dim regF2 As CRegistro = New CRegistro()

    Try
      While (True)
        ' Leer del fichero2
        regF2.nombre = br2.ReadString()
        regF2.nota = br2.ReadSingle()

        ' Escribir en el fichero1
        If (regF2.nota <> -1) Then
          bw.Write(regF2.nombre)
          bw.Write(regF2.nota)
        End If
      End While
    Catch e As EndOfStreamException
      Console.WriteLine("Fin de la copia")
    Finally
      ' Cerrar flujos
      If (Not br2 Is Nothing) Then br2.Close()
      If (Not bw Is Nothing) Then bw.Close()
      ' Borrar el fichero temporal
      File.Delete(fichero2)
    End Try
  End Sub
End Class
