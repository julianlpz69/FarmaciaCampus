

namespace Domain.Entities;

public class FacturaBase : BaseEntity
{
    public int Total { get; set; }
    public int TotalIva { get; set; }
    public string CodigoCompra { get; set; }
    public DateTime FechaSalida { get; set; }
    public ICollection<FacturaCompra> FacturaCompras { get; set; }
    public ICollection<FacturaVenta> FacturaVentas { get; set; }
    public int IdMetodoCompra {get; set;}
    public MetodoCompra MetodoCompra {get; set;}
}
