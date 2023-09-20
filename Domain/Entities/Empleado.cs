using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Empleado : Persona
    {
        public int IdCargoEmpleadoFK { get; set; }  
        public CargoEmpleado CargoEmpleado {get; set; }
    }
}