using Domain.Entities;

namespace API.Dtos;

    public class EmpleadoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public DireccionDto Direccion{ get; set; }
        public CargoEmpleadoDto CargoEmpleado { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
    }
