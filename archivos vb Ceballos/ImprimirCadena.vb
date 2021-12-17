Imports System
Imports System.Drawing
Imports System.Drawing.Printing

Public Class Test
  Private cadena As String
  Private fuente As Font

  Public Sub ImprimirCadena(ByRef datos As String)
    Dim pd As PrintDocument = New PrintDocument
    fuente = New Font("Times New Roman", 10)
    cadena = datos
    ' Indicar que el evento PrintPage se controlará con el
    ' método Imprimir    
    AddHandler pd.PrintPage, AddressOf Me.Imprimir
    pd.Print() ' invoca al método Imprimir
  End Sub

  Private Sub Imprimir(ByVal obj As Object, ByVal ev As PrintPageEventArgs)
    Dim pos_X As Single = 10
    Dim pos_Y As Single = 20
    ev.Graphics.DrawString(cadena, fuente, Brushes.Black, _
                           pos_X, pos_Y, New StringFormat)
  End Sub

  Public Shared Sub Main()
    Dim ap As Test = New Test

    ap.ImprimirCadena("Hola mundo." & Environment.NewLine)
  End Sub
End Class
