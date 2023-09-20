using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;

public class MetodoCompra : BaseEntity
{
    public string Descripcion {get; set;}
    public ICollection<FacturaVenta> Facturas{get; set;}
}
