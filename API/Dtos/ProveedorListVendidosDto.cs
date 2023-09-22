using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos;
public class ListaProd{
    public string NombreMedicamento { get; set; }
    public int Cantidad { get; set; }
}
public class ProveedorListVendidosDto
{
    public string NombreProveedor {get;set;}
    public IEnumerable<ListaProd> listaProds {get; set;} 
}
