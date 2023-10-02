using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class MedicamentoCompraDto
    {
        public int Id { get; set; }
        public int IdFacturaCompraFk { get; set; }
        public MedicamentoDto Medicamento { get; set; }
        public int CantidadComprada { get; set; }
        public double PrecioCompra { get; set; }
    }
}