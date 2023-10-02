namespace API.Dtos;
public class PostCompraNuevoDto
{
    public int Id { get; set; }
    public double ValorTotal { get; set; }
    public DateTime FechaCompra { get; set; }
    public int IdMetodoPagoFk { get; set; }
    public int IdProveedorFK { get; set; }
    public List<MedicamentoCompraDto> MedicamentosComprados { get; set; }
}