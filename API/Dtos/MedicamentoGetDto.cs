using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class MedicamentoGetDto
    {
        public int Id { get; set;}
        public string NombreMedicamento { get; set; }
        public bool RequiereReceta { get; set; }
        public Double PrecioMedicamento {get; set; }
        public int Stock {get; set;}
        public DateTime FechaExpiracion {get; set;}
        public ProveedorjjDto Proveedor {get; set;}
        public MarcaDto Marca {get; set;}
    }
}