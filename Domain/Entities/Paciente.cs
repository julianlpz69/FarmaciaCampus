using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Paciente : BaseEntity
    {
        public string NombrePaciente { get; set; }
        public string DireccionPaciente { set; get; }
        public string TelefonoPaciente {set; get; }
        public ICollection<Venta> Ventas {get; set; }
    }
}