using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos;

public class AllProveedorDto
{
    public string NombreProveedor { get; set; }
    public string ContactoProveedor {get; set;}
    public DireccionDto Direccion { get; set; }
}
