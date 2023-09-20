namespace Domain.Entities;

public class FacturaVenta : BaseEntity
{
    public int IdFacturaBaseFk {get;set;}
    public FacturaBase FacturaBase {get;set;}
    public ICollection<MedicamentoVenta> MedicamentoVentas {get; set;}  
    public int IdPacienteFk {get; set;}
    public Persona Paciente {get; set;}
}
