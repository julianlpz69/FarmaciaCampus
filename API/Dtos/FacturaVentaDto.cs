using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class FacturaVentaDto
    {
    public int Id { get; set; }
    public int IdFacturaBaseFk {get;set;}
    public int IdEmpleadoFK {get;set;}
    public int IdClienteFK {get;set;}
    public List<MedicamentoVenta> medicamentoVentas{get; set;}
    }
}