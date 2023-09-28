using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class EmpleadoCrearDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public DireccionDto Direccion { get; set; }
        public int IdCargoEmpleadoFK { get; set; }
        public int IdTipoDocumentoFK { get; set; }
    }
}