Module MiCoche
  public sub Main()
    Dim micoche As Coche = New Coche()
    micoche.Marca = "BMW"
    micoche.Color = "Negro metalizado"
    micoche.Modelo = "descapotable"
    micoche.ArrancarMotor()
    micoche.Acelerar()
    micoche.SubirMarcha()
    micoche.Acelerar()
    micoche.SubirMarcha()
    micoche.Acelerar()
    micoche.SubirMarcha()      
    micoche.Frenar()
    micoche.BajarMarcha()
    micoche.Frenar()
    micoche.BajarMarcha()
    micoche.Frenar()
    micoche.BajarMarcha()
    micoche.PararMotor()
    micoche.DescribirCoche()
  end sub
end module
