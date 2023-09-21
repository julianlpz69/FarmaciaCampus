using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MedicamentoVenta : BaseEntity
    {
        public int IdFacturaVentaFK { get; set; }
        public FacturaVenta FacturaVenta { get; set; }
        public int IdMedicamentoFK { get; set; }
        public Medicamento Medicamento { get; set; }
        public int CantidadVendida { get; set; }
        public double Precio {get; set;}
    }
}