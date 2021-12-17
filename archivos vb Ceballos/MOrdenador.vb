Module MOrdenador
  Public Sub Main()
    Dim miOrdenador As COrdenador = New COrdenador()
    miOrdenador.Marca = "Toshiba"
    miOrdenador.Procesador = "Intel Centrino"
    miOrdenador.Peso = 3
    miOrdenador.EncenderOrdenador()
    miOrdenador.Estado()
    miOrdenador.DesactivarPantalla()
    miOrdenador.Estado()
    miOrdenador.ApagarOrdenador()
  End Sub
End Module

