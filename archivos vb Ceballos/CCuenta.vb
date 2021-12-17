Class CCuenta
  ' Atributos
  Private _nombre As String
  Private _cuenta As String
  Private _saldo As Double
  Private _tipoDeInteres As Double

  ' Métodos
  Public Sub New()
  End Sub

  Public Sub New(ByVal nom As String, ByVal cue As String, _
                 ByVal sal As Double, ByVal tipo As Double)
    Nombre = nom
    Cuenta = cue
    ingreso(sal)
    TipoDeInteres = tipo
  End Sub

  Public Property Nombre() As String
    Get
      Return _nombre
    End Get
    Set(ByVal nom As String)
      If nom.Length = 0 Then
        System.Console.WriteLine("Error: cadena vacía")
      Else
        _nombre = nom
      End If
    End Set
  End Property

  Public Property Cuenta() As String
    Get
      Return _cuenta
    End Get
    Set(ByVal cue As String)
      If cue.Length = 0 Then
        System.Console.WriteLine("Error: cuenta no válida")
      Else
        _cuenta = cue
      End If
    End Set
  End Property

  Public ReadOnly Property Saldo() As Double
    Get
      Return _saldo
    End Get
  End Property

  Public Sub ingreso(ByVal cantidad As Double)
    If cantidad < 0 Then
      System.Console.WriteLine("Error: cantidad negativa")
    Else
      _saldo = _saldo + cantidad
    End If
  End Sub

  Public Sub reintegro(ByVal cantidad As Double)
    If _saldo - cantidad < 0 Then
      System.Console.WriteLine("Error: no dispone de saldo")
    Else
      _saldo = _saldo - cantidad
    End If
  End Sub

  Public Property TipoDeInteres() As Double
    Get
      Return _tipoDeInteres
    End Get
    Set(ByVal tipo As Double)
      If tipo < 0 Then
        System.Console.WriteLine("Error: tipo no válido")
      Else
        _tipoDeInteres = tipo
      End If
    End Set
  End Property
End Class
