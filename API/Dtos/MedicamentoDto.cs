using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class MedicamentoDto
    {
        public int Id { get; set;}
        public string NombreMedicamento { get; set; }
        public Double PrecioMedicamento {get; set; }
        public int Stock {get; set;}
        public DateTime FechaExpiracion {get; set;}
        public int IdProveedorFK {get; set;}
        public int IdMarcaFK {get; set;}

    }
}