using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MedicamentoCompra : BaseEntity
    {
        public int IdFacturaCompraFK { get; set; }
        public FacturaCompra FacturaCompra { get; set; }
        public int IdMedicamentoFK { get; set; }
        public Medicamento Medicamento { get; set; }
        public int CantidadComprada {get; set;}
        public double PrecioCompra {get; set;}
    }
}