using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos;
public class Vendidos
{
    public string NombreProducto {get; set;}
}
public class MedicamentoWithName
{
    public string NombreProveedor{get; set;}
    public IEnumerable<Vendidos> Vendidos {get; set;}
}
