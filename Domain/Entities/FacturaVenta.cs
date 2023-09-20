namespace Domain.Entities;

public class FacturaVenta : BaseEntity
{
    public int IdFacturaBaseFk {get;set;}
    public FacturaBase FacturaBase {get;set;}
    public ICollection<MedicamentoVenta> MedicamentoVentas {get; set;}  
    public int IdEmpleadoFK {get;set;}
    public Empleado Empleado {get; set;}
    public int IdClienteFK {get;set;}
    public Cliente Cliente {get; set;}
}
