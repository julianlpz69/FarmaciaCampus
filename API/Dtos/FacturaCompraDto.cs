using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class FacturaCompraDto
    {
    public int Id { get; set; }
    public int IdFacturaBaseFk {get;set;}
    public ICollection<MedicamentoCompra> MedicamentoCompras {get; set;}
    public int IdProveedorFk {get; set;}
    
    }
}