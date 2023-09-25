using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos;

public class ProveedorVentasAnualesDto
{
    public string NombreProveedor {get; set;}
    public double totalAnual{get; set;} 
}
