using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Venta : BaseEntity
    {
        public DateTime FechaVenta { get; set; }
        public int IdPacienteFK { get; set; }
        public Paciente Paciente { get; set; }
        public int IdEmpleadoFK { get; set; }
        public Empleado Empleado { get; set; }
        public ICollection<MedicamentoVenta> MedicamentoVentas { get; set; }

    }
}