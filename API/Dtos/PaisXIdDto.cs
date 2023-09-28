using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class PaisXIdDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<DepartamentoXIdDto> Departamentos { get; set; }
    }
}