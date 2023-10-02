

namespace Domain.Entities;

public class FacturaCompra : BaseEntity
{
    public double ValorTotal { get; set; }
    public DateTime FechaCompra { get; set; }
    public int IdMetodoPagoFK {get; set;}
    public MetodoPago MetodoPago {get; set;}
    public ICollection<MedicamentoCompra> MedicamentosComprados{get; set;}
    public int IdProveedorFk {get; set;}
    public Proveedor Proveedor {get; set;}

}
