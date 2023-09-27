

namespace Domain.Entities;

public class Persona : BaseEntity
{
    public string Nombre { get; set; }
    public string Apellido {get; set;}
    public string Cedula {get; set;}
    public string Telefono {get; set;}
    public int IdTipoDocumentoFK {get; set;}
        public TipoDocumento TipoDocumento { get; set; }
    public int IdDireccionFk {get; set;}
    public Direccion Direccion {get; set;}
    public ICollection<FacturaVenta> FacturaVentas {get; set;}
}
 