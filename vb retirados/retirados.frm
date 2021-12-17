VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Form1"
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
   Begin VB.PictureBox pb 
      Height          =   255
      Left            =   480
      ScaleHeight     =   195
      ScaleWidth      =   3915
      TabIndex        =   5
      Top             =   3600
      Width           =   3975
   End
   Begin VB.CommandButton cmdSalir 
      Caption         =   "Salir"
      Height          =   255
      Left            =   2040
      TabIndex        =   2
      Top             =   1680
      Width           =   735
   End
   Begin VB.CommandButton cmdSigue 
      Caption         =   "Sigue"
      Height          =   255
      Left            =   1080
      TabIndex        =   1
      Top             =   1680
      Width           =   735
   End
   Begin VB.Label Label2 
      AutoSize        =   -1  'True
      BackStyle       =   0  'Transparent
      Caption         =   "Label1"
      Height          =   615
      Left            =   360
      TabIndex        =   4
      Top             =   2400
      Width           =   4665
   End
   Begin VB.Label Label1 
      AutoSize        =   -1  'True
      BackStyle       =   0  'Transparent
      Caption         =   "Label1"
      Height          =   435
      Left            =   480
      TabIndex        =   3
      Top             =   4080
      Width           =   3585
   End
   Begin VB.Label lblAtenciónPreviamente 
      AutoSize        =   -1  'True
      BackStyle       =   0  'Transparent
      Caption         =   $"retirados.frx":0000
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
      Height          =   675
      Left            =   0
      TabIndex        =   0
      Top             =   0
      Width           =   5790
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False


Dim adoConn As New ADODB.Connection
Dim adoI As New ADODB.Command
Dim adoM As New ADODB.Recordset
Dim adoExced As New ADODB.Recordset 'tabla con los excedidos
Dim adoOrden As New ADODB.Recordset 'tabla momentanea con los registros de un excedido
Dim adoAux As New ADODB.Recordset    'auxiliar
Dim adoAux2 As New ADODB.Recordset
Dim sMes As String
Dim mplanilla As Object


Dim HayError As Boolean
Dim iOrden As Integer




Private Sub cmdSegundaParte_Click()

End Sub

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
'conectar
Set adoConn = New ADODB.Connection
adoConn.CursorLocation = adUseClient
adoConn.Open "dsn=jimmy;Jet OLEDB:Database Password=cp7;"""
MsgBox "Conexión satisfactoria" & Chr(13) & " Ingresando al Sistema... "
Me.Show


'mComando.ActiveConnection = adoConn
'mComando.CommandType = adCmdText

        'smes = MMAA  <<<<<<=========================  RETIRADOS CAMBIAR AQUI
        sMes = "1121"
        Label1.Caption = ""
        Label2.Caption = "Atención: Previamente debe guardar los datos en c:\cp\r\Retirados.xls ." & vbNewLine & _
            "La salida es en  c:\cp\r\515.txt " & vbNewLine & vbNewLine & _
            "Mes operación MMAA:  " & sMes
         pb.Enabled = False
        nSigue = 1
End Sub




'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
Private Sub cmdSalir_Click()
'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        Unload Me
End Sub


'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
Private Sub cmdSigue_Click()
'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
       ms1Einicio
        
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
Private Sub Form_Unload(Cancel As Integer)
'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        'cierra todo
        Close #1
        mplanilla.Workbooks.Close
        Set cRecib = Nothing
        Set mplanilla = Nothing
End Sub

'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
Private Sub Mensaje3(sPrm As String)
'XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        Label1.Caption = sPrm
        DoEvents
  End Sub


