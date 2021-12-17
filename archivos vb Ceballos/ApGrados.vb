' Conversión de grados centígrados a fahrenheit:
' F = 9/5 * C + 32
'
Option Strict On
Imports System   ' utilizar el espacio de nombres System

Module ApGrados
  ' Definición de constantes
  Const limInferior As Integer = -30
  Const limSuperior As Integer = 100
  Const incremento As Integer = 6

  Public Sub Main()
    ' Declaración de variables
    Dim grados As CGrados = New CGrados() ' objeto grados
    Dim gradosCent As Integer = limInferior
    Dim gradosFahr As Single = 0

    While (gradosCent <= limSuperior) ' mientras ... hacer:
      ' Asignar al objeto grados el valor en grados centígrados
      grados.AsignarCentígrados(gradosCent)
      ' Obtener del objeto grados los grados fahrenheit
      gradosFahr = grados.ObtenerFahrenheit()
      ' Escribir la siguiente línea de la tabla
      Console.WriteLine("{0, 8:d} C {1, 8:f2} F", gradosCent, gradosFahr)
      ' Siguiente valor
      gradosCent += incremento
        End While
        Console.ReadLine()

    End Sub
End Module

      ' {0, 8:d} indica: mostrar el parámetro 0 (gradosCent) en
      ' un ancho de 8 posiciones ajustado a la derecha (-8) sería
      ' ajustado a la izquierda.
      ' {1, 8:f2} indica: mostrar el parámetro 1 (gradosFahr) en
      ' un ancho de 8 posiciones ajustado a la derecha, formato
      ' coma fija con dos decimales.

