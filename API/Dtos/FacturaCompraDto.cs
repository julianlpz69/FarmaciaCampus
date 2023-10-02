using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class FacturaCompraDto
    {
        public int Id { get; set; }
        public double ValorTotal { get; set; }
        public DateTime FechaCompra { get; set; }
        public MetodoPagoDto MetodoPago { get; set; }
        public List<MedicamentoCompraDto> MedicamentosComprados { get; set; }
        public AllProveedorDto Proveedor { get; set; }

    }
}