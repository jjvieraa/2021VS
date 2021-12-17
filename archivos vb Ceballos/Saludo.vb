Imports System ' Clases fundamentales.
Imports System.Windows.Forms ' Clase Form.
Imports System.Drawing ' Objetos gr�ficos.

Public Class Form1
	Inherits Form
  ' Atributos
  Private etSaludo As Label
  Private btSaludo As Button
  Private ttToolTip1 As ToolTip

  ' M�todos
  Public Sub New()
	  MyBase.New()
    IniciarComponentes()
  End Sub

  Public Sub IniciarComponentes()
    ' Construir aqu� los controles
    etSaludo = New Label()
    btSaludo = New Button()
    ttToolTip1 = New ToolTip()

    ' Iniciar la etiqueta etSaludo
    etSaludo.Name = "etSaludo"
    etSaludo.Text = "etiqueta"

    etSaludo.Font = New Font("Microsoft Sans Serif", 14, FontStyle.Regular)
    etSaludo.TextAlign = ContentAlignment.MiddleCenter
    etSaludo.Location = New Point(53, 48)
    etSaludo.Size = New Size(187, 35)
    etSaludo.TabIndex = 1

    ' Iniciar el bot�n btSaludo
    btSaludo.Name = "btSaludo"
    btSaludo.Text = "Haga &clic aqu�"
    btSaludo.Location = New Point(53, 90)
    btSaludo.Size = New Size(187, 23)
    btSaludo.TabIndex = 0
    ttToolTip1.SetToolTip(btSaludo, "Bot�n de pulsaci�n")
    AddHandler btSaludo.Click, AddressOf btSaludo_Click

    ' Iniciar formulario: objeto de la clase Form1
    ClientSize = New Size(292, 191) ' tama�o
    Name = "Form1" ' nombre
    Text = "Saludo" ' t�tulo

    Controls.Add(etSaludo)
    Controls.Add(btSaludo)
  End Sub

  Protected Overrides Overloads Sub Dispose(ByVal eliminar As Boolean)
    If eliminar Then
    End If
    MyBase.Dispose(eliminar)
  End Sub

  Private Sub btSaludo_Click(ByVal sender As Object, ByVal e As EventArgs)
    etSaludo.Text = "���Hola mundo!!!"
  End Sub

  Public Shared Sub Main()
    Application.Run(New Form1())
  End Sub
End Class
