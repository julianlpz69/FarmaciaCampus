using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;

public class CargoEmpleado : BaseEntity
{
    public string NombreCargo { get; set; }
    public ICollection<Empleado> Empleados {get; set;}
}
