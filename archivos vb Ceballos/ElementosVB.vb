' La ejecución del programa comienza con el método Main().
' La llamada al constructor de clase no tiene lugar a menos
' que se cree un objeto del tipo 'CElementosSharp'
' en el método Main().
'
Option Strict On
Module ElementosVB
  Const cte1 As Integer = 1
  Const cte2 As String = "Pulse una tecla para continuar"
  Dim día, mes As Short, año As Short = 2001

  Public Sub Test()
    Const cte3 As Double = 3.1415926
    Dim contador As Integer
    Dim Nombre As String = "", Apellidos As String

    Apellidos = "Ceballos"
    System.Console.WriteLine(contador) ' correcto: contador es igual a 0
    System.Console.WriteLine(día)      ' correcto: día es igual a 0
  End Sub

  ' Punto de entrada a la aplicación
  '
  Public Sub Main()
    'Test()

    ' Conversión implícita
    'Dim bDato As SByte = 1, sDato As Short, iDato As Integer
    'Dim lDato As Long, fDato As Single, rDato As Double
    'Dim dDato As Decimal

    'sDato = bDato
    'iDato = sDato
    'lDato = iDato
    'dDato = lDato
    'fDato = dDato
    'rDato = fDato + lDato - iDato * sDato / bDato
    'System.Console.WriteLine(rDato) ' resultado: 1

    ' Conversión explícita
    'rDato = 2
    'fDato = CType(rDato, Single)  ' CSng(rDato) es equivalente
    'lDato = CType(fDato, Long)    ' CLng(fDato) es equivalente
    'iDato = CType(lDato, Integer) ' CInt(lDato) es equivalente
    'sDato = CType(iDato, Short)   ' CShort(iDato) es equivalente
    'dDato = CType(rDato, Decimal) ' CDec(rDato) es equivalente
    'bDato = CType(sDato + iDato - lDato * fDato / rDato, SByte) ' CByte(...) es equivalente
    'System.Console.WriteLine(bDato) ' resultado: 2

    'Dim r As Single
    'r = CType(System.Math.Sqrt(10), Single)
    'System.Console.WriteLine(r)

    ' Operadores aritméticos
    'Dim a As Integer = 10, b As Integer = 3, c As Integer
    'Dim x As Single = 2F, y As Single
    'y = x + a         ' El resultado es 12.0 de tipo Single
    'c = a \ b         ' El resultado es 3 de tipo Integer
    'c = a Mod b       ' El resultado es 1 de tipo Integer
    'y = a \ b         ' El resultado es 3 de tipo Integer. Se
                      ' convierte a Single para asignarlo a y
    'c = CInt(x / y)   ' El resultado es 0.6666667 de tipo Single. Se
                      ' convierte a Integer para asignarlo a c
                      ' redondeando el resultado (c = 1).
    'System.Console.WriteLine(x / y)

    ' Operadores de relación o de comparación
    'Dim x As Integer = 10, y As Integer = 0
    'Dim r As Boolean
    'r = x = y  ' da como resultado False
    'r = x > y  ' da como resultado True
    'r = x <> y ' da como resultado True
    'System.Console.WriteLine(r)

    ' Operadores lógicos
    'Dim p As Integer = 10, q As Integer = 0
    'Dim r As Boolean
    'r = p <> 0 And q <> 0   ' da como resultado False
    'r = p <> 0 Or q > 0     ' da como resultado True
    'r = q < p And p <= 10   ' da como resultado True
    'r = Not r               ' si r es True, el resultado es False

    ' Operadores unitarios
    'Dim a As Integer = 2, b As Integer = 0, c As Integer
    'c = -a      ' resultado c = -2
    'c = Not b   ' resultado c = -1

    ' Operadores a nivel de bits
    'Dim a As Integer = 255, r As Integer = 0, m As Integer = 32

    'r = a And &HF  ' r=15. Pone a cero todos los bits de a
                   ' excepto los 4 bits de menor peso.
    'r = r Or m     ' r=47. Pone a 1 todos los bits de r que
                   ' estén a 1 en m.
    'r = a Xor &H7  ' r=248. Suma lógica.

    ' Operadores de asignación
    'Dim x As Integer = 0, n As Integer = 10, i As Integer = 1

    'x += 1      ' Incrementa el valor de x en 1.
    'x -= 1      ' Decrementa el valor de x en 1.
    'x += 2      ' Realiza la operación x = x + 2.
    'i *= n - 3  ' Realiza la operación i = i * (n-3) y no
                ' i = i * n - 3.

    ' Operador de concatenación
    'Dim s1, s2, s3 As String, n As Integer = 3
    's2 = "Hola"
    's3 = " amigos"
    's1 = n & s3  ' s1 = "3 amigos"
    's1 = s2 + s3 ' s1 = "Hola amigos"

    ' Priopridad y orden de evaluación
    Dim x, y, z As Integer
    y = 20 : z = 15
    x = y - z \ 2 ' resultado x = 13
    System.Console.WriteLine("{0} {1} {2}", x, y, z)
  End Sub
End Module

