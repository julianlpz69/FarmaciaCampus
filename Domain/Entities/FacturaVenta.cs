namespace Domain.Entities;

public class FacturaVenta : BaseEntity
{
    public ICollection<MedicamentoVenta> MedicamentosVendidos {get; set;}  
    public int IdEmpleadoFK {get;set;}
    public Empleado Empleado {get; set;}
    public int IdClienteFK {get;set;}
    public Cliente Cliente {get; set;}
    public double ValorTotal { get; set; }
    public double ValorTotalMasIva
    {
        get
        {
            return ValorTotal + (ValorTotal * 0.19); 
        }
        private set {}
    }
    public DateTime FechaVenta { get; set; }
    public int IdMetodoPagoFK {get; set;}
    public MetodoPago MetodoPago {get; set;}
 
}
