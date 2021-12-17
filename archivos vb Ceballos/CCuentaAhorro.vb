Class CCuentaAhorro
  Inherits CCuenta
  ' Atributos
  Private _cuotaMantenimiento As Double

  ' Métodos
  Public Sub New() ' constructor sin parámetros
  End Sub

  Public Sub New(ByVal nom As String, ByVal cue As String, _
                 ByVal sal As Double, ByVal tipo As Double, ByVal mant As Double)
    MyBase.New(nom, cue, sal, tipo) ' invoca al constructor de
    ' CCuenta; esto es, al de la clase base.
    CuotaMantenimiento = mant ' inicia _cuotaMantenimiento
  End Sub

  Public Property CuotaMantenimiento() As Double
    Get
      Return _cuotaMantenimiento
    End Get
    Set(ByVal cantidad As Double)
      If cantidad < 0 Then
        System.Console.WriteLine("Error: cantidad negativa")
      Else
        _cuotaMantenimiento = cantidad
      End If
    End Set
  End Property

  Public Overloads Sub reintegro(ByVal cantidad As Double)
    Dim saldo As Double = Me.Saldo
    Dim tipoDeInteres As Double = Me.TipoDeInteres

    If tipoDeInteres >= 3.5 Then
      If saldo - cantidad < 1500 Then
        System.Console.WriteLine("Error: no dispone de esa cantidad")
        Return
      End If
    End If
    MyBase.reintegro(cantidad) ' método reintegro de la clase base,
    ' también llamada superclase
  End Sub
End Class
