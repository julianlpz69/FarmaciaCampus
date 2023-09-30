using Domain.Entities;
namespace API.Dtos;
public class UpdateProveedorDto
{
    public int IdDireccionFK { get; set; }
    public string NombreProveedor { get; set; }
    public string ContactoProveedor {get; set;}
    public Direccion Direccion { get; set; }
}
