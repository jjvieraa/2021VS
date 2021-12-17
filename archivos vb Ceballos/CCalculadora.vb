' Este programa utiliza la clase Leer del espacio de nombres
' MisClases.ES
Imports System
Imports System.Environment 'para NewLine
Imports MisClases.ES

Public Class CCalculadora
  ' Simulación de una calculadora
  Private m_operando1 As Double
  Private m_operando2 As Double
  Private m_resultado As Double

  Public Sub EstablecerOperandos(op1 As Double, op2 As Double)
    m_operando1 = op1
    m_operando2 = op2
  End Sub

  Public Function Resultado() As Double
    Return m_resultado
  End Function

  Public Function menú() As Integer
    Dim op As Integer
    Do
      Console.WriteLine("  1. sumar")
      Console.WriteLine("  2. restar")
      Console.WriteLine("  3. multiplicar")
      Console.WriteLine("  4. dividir")
      Console.WriteLine("  5. salir")
      Console.Write(NewLine & "Seleccione la operación deseada: ")
      op = Leer.datoInt()
    Loop While (op < 1 Or op > 5)
    Return op
  End Function

  Public Function Sumar() As Double
    m_resultado = m_operando1 + m_operando2
    Return m_resultado
  End Function

  Public Function Restar() As Double
    m_resultado = m_operando1 - m_operando2
    Return m_resultado
  End Function

  Public Function Multiplicar() As Double
    m_resultado = m_operando1 * m_operando2
    Return m_resultado
  End Function

  Public Function Dividir() As Double
    m_resultado = m_operando1 / m_operando2
    Return m_resultado
  End Function
End Class

