using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Empleado : BaseEntity
    {
        public string NombreEmpleado {get; set;}
        public string CargoEmpleado {get; set;}
        public DateTime FechaContratacopn {get; set;}
        public ICollection<Venta> Ventas {get; set;}
    }
}