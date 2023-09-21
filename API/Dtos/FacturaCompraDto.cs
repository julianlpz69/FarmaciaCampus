using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class FacturaCompraDto
    {
   
    public ICollection<MedicamentoCompra> MedicamentoCompras {get; set;}
    public int IdProveedorFk {get; set;}
    
    }
}