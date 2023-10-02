using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class MedicamentoCompraNuevoDto
    {
        public int IdMedicamentoFK { get; set; }
        public string NombreMedicamento { get; set; }
        public bool RequiereReceta { get; set; }
        public Double PrecioMedicamento { get; set; }
        public int Stock { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public int IdProveedorFK { get; set; }
        public int IdMarcaFK { get; set; }
        public int CantidadComprada { get; set; }
        public double PrecioCompra { get; set; }
    }
}