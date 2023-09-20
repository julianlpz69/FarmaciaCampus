using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Proveedor : BaseEntity
    {
        public string NombreProveedor { get; set; }
        public string ContactoProveedor { get; set; }
        public int IdDireccionFK { get; set; }
        public Direccion Direccion { get; set; }
        public ICollection<FacturaCompra> FacturaCompras { get; set; }
        public ICollection<Medicamento> Medicamentos { get; set; }
    }
}