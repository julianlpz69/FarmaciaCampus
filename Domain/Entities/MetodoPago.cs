using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;

public class MetodoPago : BaseEntity
{
    public string Descripcion {get; set;}
    public ICollection<FacturaCompra> FacturasCompras{get; set;}
    public ICollection<FacturaVenta> FacturasVentas{get; set;}
}
