Class Coche
  Private _color As String
  Private _marca As String
  Private _modelo As String
  Private _marcha As Integer

  Public Property Color() As String
    Get
      Return _color
    End Get
    Set(ByVal Value As String)
      If Value = Nothing Then
        _color = "color desconocido"
      Else
        _color = Value
      End If
    End Set
  End Property

  Public Property Marca() As String
    Get
      Return _marca
    End Get
    Set(ByVal Value As String)
      If Value = Nothing Then
        _marca = "marca desconocida"
      Else
        _marca = Value
      End If
    End Set
  End Property

  Public Property Modelo() As String
    Get
      Return _modelo
    End Get
    Set(ByVal Value As String)
      If (Value = Nothing) Then
        _modelo = "modelo desconocido"
      Else
        _modelo = Value
      End If
    End Set
  End Property

  Public Sub ArrancarMotor()
    System.Console.WriteLine("BRrrrrrrrrummmmm...")
  End Sub

  Public Sub Acelerar()
    System.Console.WriteLine("Acelerando...")
  End Sub

  Public Sub SubirMarcha()
    If _marcha < 5 Then _marcha = _marcha + 1
    System.Console.WriteLine("Marcha: " & _marcha)
  End Sub

  Public Sub BajarMarcha()
    If _marcha > -1 Then _marcha = _marcha - 1
    ' -1 = marcha atrás
    System.Console.WriteLine("Marcha: " & _marcha)
  End Sub

  Public Sub Frenar()
    System.Console.WriteLine("Frenando...")
  End Sub

  Public Sub PararMotor()
    System.Console.WriteLine("Motor parado.")
  End Sub

  Public Sub DescribirCoche()
    System.Console.WriteLine(" -- Mi coche es un " & Marca & " " & Color & " " & Modelo)
  End Sub
End Class
