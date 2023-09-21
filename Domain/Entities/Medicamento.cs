using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Medicamento : BaseEntity
    {
        public string NombreMedicamento { get; set; }
        public Double PrecioMedicamento {get; set; }
        public bool RequiereReceta {get; set;}
        public int Stock {get; set;}
        public DateTime FechaExpiracion {get; set;}
        public int IdProveedorFK {get; set;}
        public Proveedor Proveedor {get; set;}
        public int IdMarcaFK {get; set;}
        public Marca Marca {get; set;}
        public ICollection<MedicamentoCompra> MedicamentosCompras { get; set; }
        public ICollection<MedicamentoVenta> MedicamentoVentas {get; set;}


        
    }

}