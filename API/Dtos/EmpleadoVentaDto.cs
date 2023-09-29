namespace API.Dtos;

public class EmpleadoVentaDto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public CargoEmpleadoDto CargoEmpleado { get; set; }
    public int CantidadVentas { get; set; }
}
