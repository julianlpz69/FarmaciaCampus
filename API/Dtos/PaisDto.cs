using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class PaisDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<DepartamentoDto> Departamentos { get; set; }

    }
}