Class COrdenador
  Private _marca As String
  Private _procesador As String
  Private _peso As Integer = 0
  Private _encendido As Boolean = False
  Private _pantalla As Boolean = False

  Public Property Marca() As String
    Get
      Return _marca
    End Get
    Set(ByVal Dato As String)
      If (Dato = Nothing) Then
        _marca = "marca desconocida"
      Else
        _marca = Dato
      End If
    End Set
  End Property

  Public Property Procesador() As String
    Get
      Return _procesador
    End Get
    Set(ByVal Value As String)
      If (Value = Nothing) Then
        _procesador = "procesador desconocido"
      Else
        _procesador = Value
      End If
    End Set
  End Property

  Public Property Peso() As Integer
    Get
      Return _peso
    End Get
    Set(ByVal Value As Integer)
      If (Value < 0) Then
        _peso = 0
      Else
        _peso = Value
      End If
    End Set
  End Property

  Public Sub EncenderOrdenador()
    If _encendido = True Then
      System.Console.WriteLine("El ordenador ya está encendido")
    Else
      _encendido = True
      _pantalla = True
      System.Console.WriteLine("El ordenador ha sido encendido")
    End If
  End Sub

  Public Sub ApagarOrdenador()
    If _encendido = False Then
      System.Console.WriteLine("El ordenador ya está apagado")
    Else
      _encendido = False
      System.Console.WriteLine("El ordenador ha sido apagado")
    End If
  End Sub

  Public Sub ActivarPantalla()
    If _pantalla = True Then
      System.Console.WriteLine("La pantalla ya está activada")
    Else
      _pantalla = True
      System.Console.WriteLine("La pantalla ha sido activada")
    End If
  End Sub

  Public Sub DesactivarPantalla()
    If _pantalla = False Then
      System.Console.WriteLine("La pantalla ya está desactivada")
    Else
      _pantalla = False
      System.Console.WriteLine("La pantalla ha sido desactivada")
    End If
  End Sub

  Public Sub Estado()
    System.Console.WriteLine("El estado del ordenador es el siguiente:")
    System.Console.WriteLine("Marca: " & _marca)
    System.Console.WriteLine("Procesador: " & _procesador)
    System.Console.WriteLine("Peso: " & _peso & " Kg.")

    If _encendido = True Then
      System.Console.WriteLine("El ordenador está encendido")
    Else
      System.Console.WriteLine("El ordenador está apagado")
    End If

    If _pantalla = True Then
      System.Console.WriteLine("La pantalla está activada")
    Else
      System.Console.WriteLine("La pantalla está desactivada")
    End If

    System.Console.WriteLine()
  End Sub
End Class
