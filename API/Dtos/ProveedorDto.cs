using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class ProveedorDto
    {
        public int Id { get; set;}
        public string NombreProveedor { get; set; }
        public string ContactoProveedor { get; set; }
        public int IdDireccionFK { get; set; }
        public ICollection<Medicamento> Medicamentos { get; set; }
    }
}