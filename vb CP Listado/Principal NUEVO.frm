VERSION 5.00
Begin VB.Form PN 
   Caption         =   "2013 Listados Jefatura"
   ClientHeight    =   7395
   ClientLeft      =   120
   ClientTop       =   450
   ClientWidth     =   6555
   BeginProperty Font 
      Name            =   "Tahoma"
      Size            =   8.25
      Charset         =   0
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   LinkTopic       =   "Form1"
   ScaleHeight     =   7395
   ScaleWidth      =   6555
   ShowInTaskbar   =   0   'False
   StartUpPosition =   3  'Windows Default
   Begin VB.TextBox Text2 
      Height          =   495
      Left            =   3480
      TabIndex        =   7
      Top             =   2040
      Width           =   1215
   End
   Begin VB.TextBox Text1 
      Height          =   495
      Left            =   1080
      TabIndex        =   6
      Top             =   2040
      Width           =   1095
   End
   Begin VB.CommandButton cmdContinuar 
      Caption         =   "CONTINUAR"
      Height          =   600
      Left            =   480
      TabIndex        =   5
      Top             =   5040
      Width           =   2000
   End
   Begin VB.PictureBox pb 
      Height          =   255
      Left            =   240
      ScaleHeight     =   195
      ScaleWidth      =   3915
      TabIndex        =   4
      Top             =   2760
      Width           =   3975
   End
   Begin VB.CommandButton cmdSalir 
      Caption         =   "FIN"
      Height          =   615
      Left            =   2640
      TabIndex        =   1
      Top             =   5040
      Width           =   2000
   End
   Begin VB.Label Label4 
      Caption         =   "AÑO:"
      Height          =   495
      Left            =   2520
      TabIndex        =   9
      Top             =   2040
      Width           =   1215
   End
   Begin VB.Label Label3 
      Caption         =   "MES:"
      Height          =   495
      Left            =   240
      TabIndex        =   8
      Top             =   2040
      Width           =   1215
   End
   Begin VB.Label Label2 
      AutoSize        =   -1  'True
      BackStyle       =   0  'Transparent
      Caption         =   "1"
      Height          =   195
      Left            =   240
      TabIndex        =   3
      Top             =   3120
      Width           =   90
   End
   Begin VB.Label Label1 
      AutoSize        =   -1  'True
      BackStyle       =   0  'Transparent
      Caption         =   "Label1"
      Height          =   1155
      Left            =   600
      TabIndex        =   2
      Top             =   600
      Width           =   5265
   End
   Begin VB.Label lblAtenciónPreviamente 
      AutoSize        =   -1  'True
      BackStyle       =   0  'Transparent
      BeginProperty Font 
         Name            =   "Arial"
         Size            =   9
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H000000C0&
      Height          =   225
      Left            =   480
      TabIndex        =   0
      Top             =   480
      Width           =   165
   End
End
Attribute VB_Name = "PN"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'+++++++++++++++++++++++++++++++
'07/03/2018 Estructura de archivos
'+++++++++++++++++++++++++++++++
'Archivo de entrada: Raaaamm.txt
'Archivo de salida: Naaaamm.txt
'Estructura del archivo Naaaamm.txt:
'3 Litera   S02
'8 Unidad   04016000
'6 Código descuento  000416
'15 documento de identidad sin codigo verificador 0000 0000 x xxx xxx   000000001700653
'8 importe (6 enteros 2 decimales)  $16345 es 01634500
'4 moneda pesos 0000 dolares 1111




'++++++++++++++++++++++++++++++++
'03/10/2013 Nuevo archivo para Jefatura
'++++++++++++++++++++++++++++++++
'Archivo de entrada: Raaaammtxt
'Estructura del Raaammtxt:
'0416
'presupuesto aaaamm
'documento sin cfra verif nnnnnnn
'valor 10 (las dos ultimas decimales) 123,5=0000012350

'Archivo de salida: Naaaamm.txt

'Archivo de salida: Oaaaamm.txt
'Estructura Oaaaamm.txt:
' Cédula
'Nombre completo
'Valor del descuento
'Al final va el total a descontar

'+++++++++++++++++++++++++++++++
'11/01/2013 Nuevo archivo para jefatura
'+++++++++++++++++++++++++++++++
'Archivo de entrada: Raaaamm.txt
'Archivo de salida: Naaaamm.txt
'Estructura del archivo Naaaamm.txt:
'S0204016000000416 Identifica al Circula
'000000002818424 CI (15 lugares)
'01133000 Valor (8 lugares, los 2 ultimos son los decimales)
'0000 (moneda)

'++++++++++++++++++++++++++
'DATOS
'++++++++++++++++++++++++++
'Directorio de trabajo C:\CP


Dim sMes As String
Dim sMnsj As String


Dim HayError As Boolean
Dim iOrden As Integer

'***********************************************
Private Sub Form_Load()
'***********************************************

' EVITA QUE SE EJECUTE 2 VECES
If App.PrevInstance Then
    MsgBox "Este programa YA se está ejecutando"
    End
End If
On Error Resume Next

'Inicializa el mensaje 2
sMnsj = ""

'CONECTA LA BD
'ODBC: jimmy
'ubicacion: C:\program files\cp\circulo.mdb

MsgBox "Conexión satisfactoria" & Chr(13) & " Ingresando al Sistema... "
Me.Show
        
'Esconde otros objetos
Label2.Caption = ""
pb.Visible = False

'Muestra objetos de mes y año
Label3.Visible = True
Label4.Visible = True
Text1.Visible = True
Text2.Visible = True

'Deshabilita el botón CONTINUAR
cmdContinuar.Enabled = False

'Muestra mensaje inicial arriba
Mensaje1 "LISTADOS PARA ENVIAR A JEFATURA" & vbNewLine & vbNewLine & _
             "Carpeta de trabajo: C:\CP" & vbNewLine & _
             "Archivo de ENTRADA:  Raaaamm.txt" & vbNewLine & _
            "Archivo de SALIDA:  Naaaamm.txt" & vbNewLine & _
          "Archivo de SALIDA:  Oaaaamm.txt"

Mensaje2 "Ingrese mes y años (4 cifras) y pulse CONTINUAR"

'Coloca el puntero en cuadro de texto MES
Text2.Text = ""
Text1.Text = ""
Text1.SetFocus


End Sub


'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
Private Sub Form_Unload(Cancel As Integer)
'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        'cierra todo
        Close #1
        Set cRecib = Nothing
        Set mplanilla = Nothing
End Sub

'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
Private Sub Mensaje1(sPrm As String)
'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        Label1.Caption = sPrm
        DoEvents
  End Sub

'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
Private Sub Mensaje2(sPrm As String)
'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        sMnsj = sMnsj & vbNewLine & sPrm
        Label2.Caption = sMnsj
        
        DoEvents
  End Sub

'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
Private Sub cmdContinuar_Click()
'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
       msProcesa
End Sub

'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
Private Sub Text1_Validate(Cancel As Boolean)
'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
'VALIDANDO EL MES
Dim NBYTE As Byte
'ES UN NUMERO
If Not IsNumeric(Text1.Text) Then
        Cancel = True
Else
    'ENTRE 1 Y 12
    NBYTE = CInt(Text1.Text)
    If NBYTE < 1 Or NBYTE > 12 Then
        Cancel = True
    End If
End If
End Sub

'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
Private Sub Text2_Validate(Cancel As Boolean)
'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
'VALIDANDO EL AÑO
'ES UN NUMERO
If Not IsNumeric(Text2.Text) Then
        Cancel = True
Else
    'TIENE 4 CIFRAS
    If Len(Text2.Text) <> 4 Then
        Cancel = True
    Else
        'el mes y año estan validados, entcs ACTIVA el boton CONTINUAR
        cmdContinuar.Enabled = True
    End If
End If

End Sub


'***********************************************
Private Sub msProcesa()
'***********************************************

Dim strBuffer As String
Dim strText As String
Dim strDocum As String
Dim strValor As String
Dim strSalida As String
Dim nEntero As Integer
Dim sMome As String
Dim sMome2 As String
Dim sNombre As String
Dim dMome4 As Double
Dim dTot As Double

Mensaje1 "LISTADOS PARA ENVIAR A JEFATURA"

Mensaje2 ""

'Esconde los objetos
Label3.Visible = False
Label4.Visible = False
Text1.Visible = False
Text2.Visible = False


'No permite escribir. Reloj arena.
Screen.MousePointer = vbHourglass

'Mes operacion  aaaamm
sMes = Text2.Text

nEntero = CInt(Text1.Text)
If nEntero < 10 Then
    sMes = sMes & "0" & Text1.Text
Else
    sMes = sMes & Text1.Text
End If


Mensaje2 "Abriendo Archivo entrada..."
sMome = "LISTADO2017.txt"
Mensaje2 "Abriendo Archivo entrada..." & sMome
'verifica que existe el archivo
sMome2 = Dir$(sMome)
If sMome2 = "" Then
    MsgBox ("No se ha encontrado el archivo:" & sMome)
    Exit Sub
End If
'Abre el archivo de Entrada

Open sMome For Input As #1
DoEvents

'Abriendo el PRIMER ARCHIVO DE SALIDA
sMome2 = "Nsalida.txt"
Open sMome2 For Output As #2
Mensaje2 "Creando archivo " & sMome2 & "..."
'+++++++++++++++++++++++++++++++
'07/03/2018 Estructura de archivos
'+++++++++++++++++++++++++++++++
'Archivo de entrada: Raaaamm.txt
'Archivo de salida: Naaaamm.txt
'Estructura del archivo Naaaamm.txt:
'3 Litera   S02
'8 Unidad   04016000
'6 Código descuento  000416
'15 documento de identidad sin codigo verificador 0000 0000 x xxx xxx   000000001700653
'8 importe (6 enteros 2 decimales)  $16345 es 01634500
'4 moneda pesos 0000 dolares 1111
'S02 04016000 000416 00000000 4006167 13627400 0000


'Completa el PRIMER Archivo de SALIDA
Do While Not EOF(1)
            Line Input #1, strBuffer
            'Debug.Print strBuffer
            strDocum = Mid$(strBuffer, 1, 1) & Mid$(strBuffer, 3, 3) & Mid$(strBuffer, 7, 3)
            dMome4 = CDbl(Mid$(strBuffer, 65, 10))
            'MsgBox dMome4
            'sMome1 = Format(adoExced!sValor, "00000000.00")
            strValor = Format(dMome4, "000000")
            'MsgBox strValor
            'salida documento con 15 lugares (agrego los 8 ceros) y el valor con 8 lugares en vez de 10
            strSalida = "S020401600000041600000000" & strDocum & strValor & "000000"
            Debug.Print strDocum, strValor, strSalida
            'Right$(strValor, 8)
            'strText = strText & strBuffer & vbCrLf
            Print #2, strSalida
Loop
Close #2
Close #1
DoEvents

'Abre otra vez el Archivo de entrada
Mensaje2 "Abriendo Archivo entrada..." & sMome

'Abre el archivo de Entrada
Open sMome For Input As #1
DoEvents

'Abriendo el SEGUNDO Archivo de Salida
'2.710.901-7        250,00   GARCIA MONTEJO LUIS EMIR
sMome2 = "Osalida.txt"
Open sMome2 For Output As #2
Mensaje2 "Creando archivo " & sMome2 & "..."

' Abre la tabla SOCIOS ordenada por NroCobro
'If adoAux.State = adStateOpen Then adoAux.Close
'adoAux.Open "SELECT * FROM TBL_Socios ORDER by CI", adoConn, adOpenForwardOnly, adLockReadOnly
     
dTot = 0
'Completa el SEGUNDO Archivo de SALIDA
Do While Not EOF(1)
            Line Input #1, strBuffer
            'Debug.Print strBuffer
            strDocum = Mid$(strBuffer, 1, 11)
            dMome4 = CDbl(Mid$(strBuffer, 65, 10))
            strValor = Format(dMome4, "     #,#0.00")
            'strValor = Mid$(strBuffer, 18, 10)
            'salida documento con 15 lugares (agrego los 8 ceros) y el valor con 8 lugares en vez de 10
            'BUSCA EL NOMBRE
            'sNombre = mfBuscaNombrePorCedula(strDocum)
            
            strSalida = strDocum & strValor & "     " & Mid$(strBuffer, 15, 15) & "     " & Mid$(strBuffer, 40, 15)
            'Debug.Print strDocum, strValor, strSalida
            'strText = strText & strBuffer & vbCrLf
            Print #2, strSalida
            dTot = dTot + dMome4
Loop
Mensaje2 "Finalizando"
Mensaje2 "Pronto"

Print #2, "   TOTAL   " & Format(dTot, "     #,#0.00")
Close #2
DoEvents

Screen.MousePointer = vbDefault


'Mensaje2 "Cerrando ...."



Close #1

'Mensaje2 "Terminado"
End Sub

'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
Private Function mfBuscaNombrePorCedula(sPrm As String) As String
'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
Dim sCriterio As String
Dim sNume As String

'snume= mid(sprm,0,1) &"."&mid(sprm(2,3) &"."& mid(sprm,
           
        
            sCriterio = "CI =" & sPrm
            ' Busca al socio
            adoAux.MoveFirst
            Debug.Print adoAux!CI
            adoAux.Find (sCriterio)
            
            If adoAux.EOF Then
            Else
                        Debug.Print adoAux!CI
                        mfBuscaNombrePorCedula = adoAux!CI
            End If

End Function







'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
Private Sub cmdSalir_Click()
'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        Unload Me
End Sub














