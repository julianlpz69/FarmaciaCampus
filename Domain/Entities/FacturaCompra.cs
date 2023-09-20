

namespace Domain.Entities;

public class FacturaCompra : BaseEntity
{
    public int IdFacturaBaseFk {get;set;}
    public FacturaBase FacturaBase {get;set;}
    public ICollection<MedicamentoCompra> MedicamentoCompras {get; set;}
    public int IdProveedorFk {get; set;}
    public Proveedor Proveedor {get; set;}
}
