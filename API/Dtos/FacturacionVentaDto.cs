using System;
namespace API.Dtos;

    public class FacturacionVentaDto
    {
        public int IdEmpleadoFK {get;set;}
        public int IdClienteFK {get; set;}
        public double ValorTotal {get; set;}
        public double ValorTotalMasIva {get; set;}
        public DateTime FechaVenta {get; set;}
        public int IdMetodoPagoFk {get; set;}
        public List<MedicamentoVentaDto> MedicamentoVentas {get; set;}
    }
