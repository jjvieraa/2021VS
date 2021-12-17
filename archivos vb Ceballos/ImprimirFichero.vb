Imports System
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Printing

Namespace MisClases.ES ' espacio de nombres

  Public Class ImprimirFichero
    Private fuente As Font
    Private sr As StreamReader

    ' Imprimir el contenido de un fichero
    Public Sub ImprimirDocumento(ByVal fichero As String)
      Try
        sr = New StreamReader(fichero)
        Try
          fuente = New Font("Arial", 10)
          Dim pd As PrintDocument = New PrintDocument
          AddHandler pd.PrintPage, AddressOf Me.ImprimirPagina
          pd.Print()
        Finally
          sr.Close()
        End Try
      Catch ex As Exception
        Console.Out.WriteLine(ex.Message)
      End Try
    End Sub

    ' Respuesta al evento PrintPage producido por Print()
    Private Sub ImprimirPagina(ByVal obj As Object, ByVal ev As PrintPageEventArgs)
      Dim lineasPorPag As Single
      Dim pos_Y As Single
      Dim cuenta As Integer
      Dim margenIzq As Single = ev.MarginBounds.Left
      Dim margenSup As Single = ev.MarginBounds.Top
      Dim linea As String

      ' Calcular el número de líneas por página
      Dim altoFuente As Single = fuente.GetHeight(ev.Graphics)
      lineasPorPag = ev.MarginBounds.Height / altoFuente

      ' Imprimir cada una de las líneas del fichero
      linea = sr.ReadLine()
      While (cuenta < lineasPorPag And (Not linea Is Nothing))
        pos_Y = margenSup + (cuenta * altoFuente)
        ev.Graphics.DrawString(linea, fuente, Brushes.Black, _
                               margenIzq, pos_Y, New StringFormat)
        cuenta += 1
        linea = sr.ReadLine()
      End While

      ' Si hay más líneas, imprimir otra página
      If (Not linea Is Nothing) Then
        ev.HasMorePages = True
      Else
        ev.HasMorePages = False
      End If
    End Sub
  End Class
End NameSpace
