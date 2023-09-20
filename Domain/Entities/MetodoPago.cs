using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;

public class MetodoPago : BaseEntity
{
    public string Descripcion {get; set;}
    public ICollection<FacturaBase> FacturasBase{get; set;}
}
