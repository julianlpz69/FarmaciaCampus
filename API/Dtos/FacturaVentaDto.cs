using Domain.Entities;
namespace API.Dtos
{
    public class FacturaVentaDto
    {
        public int Id { get; set; }
        public int IdEmpleadoFK { get; set; }
        public int IdClienteFK { get; set; }
        public List<MedicamentoVentaDto> MedicamentosVendidos { get; set; }
        public List<RecetaDto> Recetas { get; set; }
        public Double ValorTotal { get; set;}
        public double ValorTotalMasIva { get; set; }
        public DateTime FechaVenta { get; set; }
        public MetodoPago MetodoPago { get; set; }
    }
}