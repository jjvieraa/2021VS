'Clase para operar con números racionales. El objeto para el que
'se invoca el método (el objeto que recibe el mensaje) está
'accesible en dicho método por Me.
'Por ejemplo: r1.sumar(r2)
'             cuando se ejecuta sumar, r1 está referenciado por
'             Me, que se omite y r2 por el parámetro r.
'
Public Class CRacional
  'Atributos
  Private numerador As Long
  Private denominador As Long

  'Métodos
  Protected Sub Simplificar()
    'Máximo común divisor
    Dim mcd, temp, resto As Long

    mcd = System.Math.Abs(numerador)
    temp = System.Math.Abs(denominador)
    While temp > 0
      resto = mcd Mod temp
      mcd = temp
      temp = resto
    End While

    'Simplificar
    If mcd > 1 Then
      numerador = numerador \ mcd
      denominador = denominador \ mcd
    End If
  End Sub

  Public Sub New()
    numerador = 0
    denominador = 1
  End Sub

  Public Sub New(num As Long) 'constructor
    numerador = num
    denominador = 1
  End Sub

  Public Sub New(num As Long, den As Long)
    numerador = num
    denominador = den
    If denominador = 0 Then
      System.Console.WriteLine("Error: denominador 0. Se asigna 1.")
      denominador = 1
    End If
    If denominador < 0 Then
      numerador = -numerador
      denominador = -denominador
    End If
    Simplificar()
  End Sub

  Public Sub New(r As CRacional) 'constructor copia
     numerador = r.numerador
     denominador = r.denominador
  End Sub

  'Sumar números racionales
  Public Function Sumar(r As CRacional) As CRacional
    Return New CRacional(numerador * r.denominador + _
                         denominador * r.numerador, _
                         denominador * r.denominador)
  End Function

  'Restar números racionales
  Public Function Restar(r As CRacional) As CRacional
    Return New CRacional(numerador * r.denominador - _
                         denominador * r.numerador, _
                         denominador * r.denominador)
  End Function

  'Multiplicar números racionales
  Public Function Multiplicar(r As CRacional) As CRacional
    Return New CRacional(numerador * r.numerador, _
                         denominador * r.denominador)
  End Function

  'Dividir números racionales
  Public Function Dividir(r As CRacional) As CRacional
    Return New CRacional(numerador * r.denominador, _
                         denominador * r.numerador)
  End Function

  'Verificar si dos números racionales son iguales
  Public Overloads Function Equals(r As CRacional) As Boolean

    Return (numerador * r.denominador = _
             denominador * r.numerador)
  End Function

  'Verificar si un racional es menor que otro
  Public Function Menor(r As CRacional) As Boolean
    Return (numerador * r.denominador < _
             denominador * r.numerador)
  End Function

  'Verificar si un racional es mayor que otro
  Public Function Mayor(r As CRacional) As Boolean
    Return (numerador * r.denominador > _
             denominador * r.numerador)
  End Function

  'Devolver un número racional como cadena
  Public Overrides Function ToString() As String
    If numerador = 0 Then
      Return "0"
    Else
      Return numerador & "/" & denominador
    End If
  End Function

  'Copiar un racional en otro
  Public Sub Copiar(r As CRacional)
     numerador = r.numerador
     denominador = r.denominador
  End Sub

  'Verificar si es 0
  Public Function EsCero() As Boolean
    Return numerador = 0
  End Function
End Class

