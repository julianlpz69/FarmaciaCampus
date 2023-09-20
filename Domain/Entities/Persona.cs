

namespace Domain.Entities;

public class Persona : BaseEntity
{
    public string Nombre { get; set; }
    public string Apellido {get; set;}
    public string Cedula {get; set;}
    public string Telefono {get; set;}
    public DateTime FechaContratacion {get; set;}
    public int IdDireccionFk {get; set;}
    public Direccion Direccion {get; set;}
    public int IdTipoPersonaFk {get; set;}
    public TipoPersona TipoPersona {get; set;}
    public int IdCargoFk {get; set;}
    public Cargo Cargo {get; set;}
    public ICollection<FacturaVenta> FacturaVentas {get; set;}
}
