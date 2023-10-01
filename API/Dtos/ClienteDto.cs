using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class ClienteDto
    {
    public int Id { get; set;}  
    public string Nombre { get; set; }
    public string Apellido {get; set;}
    public string Cedula {get; set;}
    public string Telefono {get; set;}
    public DireccionDto Direccion {get; set;}
    public List<FacturaVentaDto> FacturaVentas {get; set;}
    }
}