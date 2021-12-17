' Definición de la clase CPersona
'
public class CPersona
  ' Atributos
  Private m_nombre As String
  Private m_dirección As String
  Private m_teléfono As Long

  ' Métodos
  Public Sub New()
  End Sub

  Public Sub New(ByVal nom As String, ByVal dir As String, ByVal tel As Long)
    m_nombre = nom
    m_dirección = dir
    m_teléfono = tel
  End Sub

  Public Property Nombre() As String
    Get
      Return m_nombre
    End Get
    Set(ByVal Value As String)
      m_nombre = Value
    End Set
  End Property

  Public Property Dirección() As String
    Get
      Return m_dirección
    End Get
    Set(ByVal Value As String)
      m_dirección = Value
    End Set
  End Property

  Public Property Teléfono() As Long
    Get
      Return m_teléfono
    End Get
    Set(ByVal Value As Long)
      m_teléfono = Value
    End Set
  End Property
End Class
