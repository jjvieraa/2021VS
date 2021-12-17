VERSION 5.00
Begin VB.Form Principal 
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
Attribute VB_Name = "pRINCIPAL"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
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

Dim adoConn As New ADODB.Connection
Dim adoI As New ADODB.Command
Dim adoM As New ADODB.Recordset
Dim adoExced As New ADODB.Recordset 'tabla con los excedidos
Dim adoOrden As New ADODB.Recordset 'tabla momentanea con los registros de un excedido
Dim adoAux As New ADODB.Recordset    'auxiliar
Dim adoAux2 As New ADODB.Recordset
Dim sMes As String
Dim mplanilla As Object
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
Set mComando = New ADODB.Command
On Error Resume Next

'Inicializa el mensaje 2
sMnsj = ""

'CONECTA LA BD
'ODBC: jimmy
'ubicacion: C:\program files\cp\circulo.mdb

Set adoConn = New ADODB.Connection
adoConn.CursorLocation = adUseClient
adoConn.Open "dsn=jimmy;Jet OLEDB:Database Password=cp7;"""
MsgBox "Conexión satisfactoria" & Chr(13) & " Ingresando al Sistema... "
mComando.ActiveConnection = adoConn
mComando.CommandType = adCmdText
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
sMome = "C:\CP\R" & sMes & ".txt"
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
sMome2 = "C:\CP\N" & sMes & ".txt"
Open sMome2 For Output As #2
Mensaje2 "Creando archivo " & sMome2 & "..."

'Completa el PRIMER Archivo de SALIDA
Do While Not EOF(1)
            Line Input #1, strBuffer
            'Debug.Print strBuffer
            strDocum = Mid$(strBuffer, 11, 7)
            strValor = Mid$(strBuffer, 18, 10)
            'salida documento con 15 lugares (agrego los 8 ceros) y el valor con 8 lugares en vez de 10
            strSalida = "S020401600000001600000000" & strDocum & Right$(strValor, 8) & "0000"
            Debug.Print strDocum, strValor, strSalida
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
sMome2 = "C:\CP\O" & sMes & ".txt"
Open sMome2 For Output As #2
Mensaje2 "Creando archivo " & sMome2 & "..."

' Abre la tabla SOCIOS ordenada por NroCobro
If adoAux.State = adStateOpen Then adoAux.Close
adoAux.Open "SELECT * FROM TBL_Socios ORDER by CI", adoConn, adOpenForwardOnly, adLockReadOnly
     

'Completa el SEGUNDO Archivo de SALIDA
Do While Not EOF(1)
            Line Input #1, strBuffer
            'Debug.Print strBuffer
            strDocum = Mid$(strBuffer, 11, 7)
            strValor = Mid$(strBuffer, 18, 10)
            'salida documento con 15 lugares (agrego los 8 ceros) y el valor con 8 lugares en vez de 10
            'BUSCA EL NOMBRE
            sNombre = mfBuscaNombrePorCedula(strDocum)
            
            strSalida = "S020401600000001600000000" & strDocum & Right$(strValor, 8) & "0000"
            Debug.Print strDocum, strValor, strSalida
            'strText = strText & strBuffer & vbCrLf
            Print #2, strSalida
Loop
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

snume= mid(sprm,0,1) &"."&mid(sprm(2,3) &"."& mid(sprm,
           
        
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




'***********************************************
Private Sub msProcesa_old()
'***********************************************

Dim strBuffer As String
Dim strText As String
Dim strDocum As String
Dim strValor As String
Dim strSalida As String

'0) Esconde puntero
Screen.MousePointer = vbHourglass


'1) PIDE MES Y AÑO
Label3.Visible = True
Label4.Visible = True
Text1.Visible = True
Text2.Visible = True
cmdAceptar.Visible = True

'esconde el boton de continuar
cmdContinuar.Visible = False

Label2.Caption = "Ingrese mes y año (4 cifras) y pulse ACEPTAR"


'2) RECORRE Raaaamm.txt


Mensaje3 "Abriendo 515.txt..."
Open "C:\CP\R201309.txt" For Input As #1
Open "C:\CP\NUEVO.txt" For Output As #2


 Do While Not EOF(1)
            Line Input #1, strBuffer
            'Debug.Print strBuffer
            strDocum = Mid$(strBuffer, 11, 7)
            strValor = Mid$(strBuffer, 18, 10)
            'salida documento con 15 lugares (agrego los 8 ceros) y el valor con 8 lugares en vez de 10
            strSalida = "S020401600000001600000000" & strDocum & Right$(strValor, 8) & "0000"
            Debug.Print strDocum, strValor, strSalida
            'strText = strText & strBuffer & vbCrLf
            Print #2, strSalida
Loop

            'pb.Value = adoExced.AbsolutePosition
            'Print #1, Format(lSocio, "0000000"), Format(tM1, "#,#0.00")
            'Print #1, "Total: ", Format(sTot, "#,#0.00")
            'sMome1 = Format(adoExced!sValor, "00000000.00")
            'xxx (3) 510 jubilado 520 pensionista
            'xxxxxxx (7) Numero pasivo
            'xx (2) Coparticipe COP , si es jubilado es cero
            'xxx (3) rubro 521 es cpr
            'Importe 8 + 2 (8 enteros 2 decimales)
            ' (4) mmaa mes y año del descuento
            ' (11) documento
            '(12) Numero de solicitud
            
            'Si tiene nro. solicitud: Numero = 0 NroSolicitud=NroSolicitud SINO NroSolicitud =0000000
                 
            'sMome = Format(adoExced!iClase, "000") & sNumero & _
                            Format(nMome, "00") & "515" & _
                            Left(sMome1, 8) & Right(sMome1, 2) & Format(sMes, "0000") & _
                            Format(adoExced!sCedul, "00000000000") & sSolicitud
            'Print #1, sMome


DoEvents
Screen.MousePointer = vbDefault


Mensaje3 "Cerrando ...."



Close #1
Close #2
Mensaje3 "Terminado"
End Sub




'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
Private Sub cmdSalir_Click()
'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        Unload Me
End Sub



'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
Private Sub ms1Einicio()
'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        '1=jefatura
        '2=Circulo
        
        'vefica que ya no se haya realizado
        HayError = False
       
        Mensaje3 "Abriendo planilla Excedidos..."
        If Not mf1Einicio_1AbrePlanilla Then
         
            Exit Sub
        End If
        
        Mensaje3 "Creando archivo..."
        mf1Einicio_2SumaExcedidos
         cmdArchivCentro
        
End Sub






'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
Private Function mf1Einicio_1AbrePlanilla() As Boolean
'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        On Error GoTo mError
        
        'abre la planilla pero no la carga
        Mensaje3 "Creando aplicación Excel..."
        Set mplanilla = CreateObject("excel.application")
        Mensaje3 "Abriendo aplicación Excel..."
        mplanilla.Workbooks.Open ("c:\cp\r\Retirados.xls")
        Mensaje3 "Activando aplicación..."
        mplanilla.Workbooks("Retirados.xls").Activate
        mf1Einicio_1AbrePlanilla = True
        Exit Function
mError:
        MsgBox "Error 356b: Al abrir la planilla Retirados.xls " & vbCrLf & "Debe encontrarse en el directorio C:\CP\R de esta máquina" & vbCrLf & Err.Number & Err.Description
        mf1Einicio_1AbrePlanilla = False
End Function

 
'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
Private Function mf1Einicio_2SumaExcedidos() As Single
'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        ' suma excedidos y guarda resultado en
        ' cptexto.tmp
        
        Dim sTot As Double
        Dim nPrmEx As Byte
        Dim sMome As Double
        Dim nia As Integer
        Dim lSocio As Long          'No Cobro
        Dim tM1 As String
        'Este es un archivo auxiliar, solo sirve para que pueda ver que sacó todos los registros de la planilla excel
        Mensaje3 "Abriendo Archivo de Salida c:\cp\r\RetiradosAAMM.txt..."
        Open "c:\cp\r\Retirados" & Right(sMes, 2) & _
        Left(sMes, 2) & _
        ".txt" For Output As 1
        
        Mensaje3 "Creando ado auxiliar..."
        Set adoExced.ActiveConnection = adoConn
        Set adoExced = New ADODB.Recordset
        ' con 2 campos: No cobro y valor
        adoExced.Fields.Append "sCobro", adSingle
       adoExced.Fields.Append "sClase", adSingle
         adoExced.Fields.Append "iRubro", adInteger
       adoExced.Fields.Append "iClase", adInteger
        adoExced.Fields.Append "sValor", adSingle
        adoExced.Fields.Append "sCedul", adChar, 10
        adoExced.Fields.Append "sSolic", adChar, 15
        adoExced.Open
        
        Mensaje3 "Recorriendo planilla ..."
        ' Graba titulos del archivo de salida: cptexto.tmp
        Print #1, Label1.Caption & vbCrLf & "No Cobro", " Valor", "Docum", "Solicitud"
        nia = 2     'SEGUNDA FILA
        ' Toma el valor
        nPrmEx = 1
        adoExced.AddNew
        iOrden = mplanilla.Workbooks("Retirados.xls").Sheets(nPrmEx).Cells(nia, 1)
        adoExced!iClase = mplanilla.Workbooks("Retirados.xls").Sheets(nPrmEx).Cells(nia, 2)
         adoExced!sCobro = mplanilla.Workbooks("Retirados.xls").Sheets(nPrmEx).Cells(nia, 3)
        adoExced!iRubro = mplanilla.Workbooks("Retirados.xls").Sheets(nPrmEx).Cells(nia, 4)
        adoExced!sValor = mplanilla.Workbooks("Retirados.xls").Sheets(nPrmEx).Cells(nia, 5)
        adoExced!sCedul = mplanilla.Workbooks("Retirados.xls").Sheets(nPrmEx).Cells(nia, 7)
        adoExced!sSolic = mplanilla.Workbooks("Retirados.xls").Sheets(nPrmEx).Cells(nia, 8)
        adoExced.Update
        sTot = adoExced!sValor
       
        ' Hasta que no encuentre 0
        Do While Not iOrden = 0
                            If nia = 231 Then
                                    Debug.Print nia
                            End If
                            Print #1, Format(adoExced!sCobro, "0000000"), Format(adoExced!sValor, "#,#0.00"), _
                             Format(adoExced!sCedul, "00000000"), Format(adoExced!sSolic, "00000000")
                             ' Agregar un registro nuevo
                             adoExced.AddNew
                             adoExced.Update
                             'Debug.Print "[" & Space(2 * (10 - Len(CStr(lSocio)))) & lSocio & "]"
                             nia = nia + 1
                             ' Otra vez toma el valor
                             Debug.Print nPrmEx, nia, iOrden
                             iOrden = mplanilla.Workbooks("Retirados.xls").Sheets(nPrmEx).Cells(nia, 1)
                             If iOrden <> 0 Then
                                              adoExced!iClase = mplanilla.Workbooks("Retirados.xls").Sheets(nPrmEx).Cells(nia, 2)
                    
                                                adoExced!sCobro = mplanilla.Workbooks("Retirados.xls").Sheets(nPrmEx).Cells(nia, 3)
                                               adoExced!iRubro = mplanilla.Workbooks("Retirados.xls").Sheets(nPrmEx).Cells(nia, 4)
                                               adoExced!sValor = mplanilla.Workbooks("Retirados.xls").Sheets(nPrmEx).Cells(nia, 5)
                                               adoExced!sCedul = mplanilla.Workbooks("Retirados.xls").Sheets(nPrmEx).Cells(nia, 7)
                                               adoExced!sSolic = mplanilla.Workbooks("Retirados.xls").Sheets(nPrmEx).Cells(nia, 8)
                                               adoExced.Update
                           
                                            sMome = adoExced!sCedul
                                            Debug.Print sMome
                                            ' Va sumando los valores
                                            sTot = sTot + adoExced!sValor
                             End If
        Loop
        'Label2.Caption = "Total excedidos: " & Format(sTot, "#,#0.00")
        'Label2.Refresh
        Mensaje3 "Cerrando temporarios..."
        Print #1, "Total: ", Format(sTot, "#,#0.00")
        
        mf1Einicio_2SumaExcedidos = sTot
        
        'vENTANA MUY BUENA para buscar errores
        'Set fjMome.DataGrid1.DataSource = adoExced
        'fjMome.Show vbModal
        'MsgBox "Probando...."
        
        
        Mensaje3 "Cerrando Excel..."
        mplanilla.Workbooks.Close
        
       Close #1
       
End Function


'
'==================================
Private Sub cmdArchivCentro()
'==================================
'Crea el archivo R521.txt para ser enviado al circulo
' Ver la estructura mas adelante

Dim sCadena As String

'COMIENZA
Screen.MousePointer = vbHourglass
pb.Visible = True


'ATENCION la carpeta es CP y no /ARCHIVOS DE PROGRAMA/CP
Mensaje3 "Abriendo 515.txt..."
Open "C:\CP\R\515.txt" For Output As 1


'Print #1, Label1.Caption & vbCrLf & "No Cobro", " Valor"

'recorre DTO.dbf´
'pb.Min = 0
'pb.Max = adoExced.RecordCount

adoExced.MoveFirst

Dim sMome As String
Dim nMome As Integer
Dim sMome1 As String
Dim sSolicitud As String
Dim sNumero As String

Do While Not adoExced.EOF
            If adoExced.AbsolutePosition Mod 100 = 0 Then Mensaje3 "Recorriendo Registros   " & CStr(adoExced.AbsolutePosition)
            'pb.Value = adoExced.AbsolutePosition
            'Print #1, Format(lSocio, "0000000"), Format(tM1, "#,#0.00")
            'Print #1, "Total: ", Format(sTot, "#,#0.00")
            sMome1 = Format(adoExced!sValor, "00000000.00")
            'xxx (3) 510 jubilado 520 pensionista
            'xxxxxxx (7) Numero pasivo
            'xx (2) Coparticipe COP , si es jubilado es cero
            'xxx (3) rubro 521 es cpr
            'Importe 8 + 2 (8 enteros 2 decimales)
            ' (4) mmaa mes y año del descuento
            ' (11) documento
            '(12) Numero de solicitud
            
            'Si tiene nro. solicitud: Numero = 0 NroSolicitud=NroSolicitud SINO NroSolicitud =0000000
        
           If CLng(0 & adoExced!sSolic) <> 0 Then
                sSolicitud = Format(adoExced!sSolic, "000000000000")
                sNumero = "0000000"
           Else
                sSolicitud = "000000000000"
                sNumero = Format(adoExced!sCobro, "0000000")
           End If
           
            sMome = Format(adoExced!iClase, "000") & sNumero & _
                            Format(nMome, "00") & "515" & _
                            Left(sMome1, 8) & Right(sMome1, 2) & Format(sMes, "0000") & _
                            Format(adoExced!sCedul, "00000000000") & sSolicitud
            Print #1, sMome
            adoExced.MoveNext
Loop

DoEvents
Screen.MousePointer = vbDefault


Mensaje3 "Cerrando ...."
adoExced.Close
Set adoExced = Nothing


Close #1
Mensaje3 "Terminado"
End Sub


'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
Private Function mf1Einicio_3VerificaSocios() As Boolean
'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        Mensaje3 "Verificando Socios..."
        pb.Enabled = True
        pb.Min = 0
        pb.Max = adoExced.RecordCount
        ' Abre la tabla SOCIOS ordenada por NroCobro
        If adoAux.State = adStateOpen Then adoAux.Close
        adoAux.Open "SELECT * FROM TBL_Socios ORDER by clng(NroCob);", adoConn, adOpenForwardOnly, adLockReadOnly
        
        ' Recorre el recordset adoExced, Solo para verificar que existen todos los socios que se van a descontar
        adoExced.MoveFirst
        Do While Not adoExced.EOF
            pb.Value = adoExced.AbsolutePosition
            pb.Refresh
            ' Busca al socio
            adoAux.MoveFirst
            adoAux.Find ("NroCob =" & adoExced!lcobr)
            If adoAux.EOF Then
                MsgBox "Atención" & vbCrLf & "No encuentro en la tabla socios" & vbCrLf & "El Nro de Cobro " & _
                adoExced!lcobr & "  por un valor de " & adoExced!sVal & vbCrLf & "Verifique este cliente y si está mal, elimínelo de la planilla cpExcedidos.xls en la carpeta C:\CP" & _
                vbCrLf & "Esta operación se interrumpirá"
                HayError = True
            End If
            adoExced.MoveNext
        Loop
        
        pb.Value = 0
        pb.Refresh
        Mensaje3 "Cerrando tbl_socios..."
        If adoAux.State = adStateOpen Then adoAux.Close
        mf1Einicio_3VerificaSocios = True
End Function












