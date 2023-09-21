using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Receta : BaseEntity
    {
        public string Remitente {get; set;}
        public string Descripcion {get; set;}
        public int IdFacturaVentaFK {get; set;}
        public FacturaVenta FacturaVenta {get; set;}
    }
}