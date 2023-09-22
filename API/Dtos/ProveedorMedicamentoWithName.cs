using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos;
public class VendidosDto
{
    public string NombreProducto {get; set;}
}
public class ProveedorMedicamentoWithName
{
    public string NombreProveedor{get; set;}
    public IEnumerable<VendidosDto> Vendidos {get; set;}
}
