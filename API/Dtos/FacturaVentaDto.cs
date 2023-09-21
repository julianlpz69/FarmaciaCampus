using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class FacturaVentaDto
    {
    public ICollection<MedicamentoVenta> MedicamentoVentas {get; set;}  
    public int IdEmpleadoFK {get;set;}
    public Empleado Empleado {get; set;}
    public int IdClienteFK {get;set;}
    public Cliente Cliente {get; set;}
    }
} 