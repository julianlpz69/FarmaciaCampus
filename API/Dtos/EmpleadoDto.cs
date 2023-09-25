using Domain.Entities;

namespace API.Dtos;

    public class EmpleadoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public int IdDireccionFk { get; set; }
        public int IdCargoEmpleadoFK { get; set; }
    }
