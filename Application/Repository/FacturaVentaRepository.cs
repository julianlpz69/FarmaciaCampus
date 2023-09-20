using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interface;
using Persistence.Data;

namespace Application.Repository;

public class FacturaVentaRepository : GenericRepository<FacturaVenta>, IFacturaVenta
{
    public FacturaVentaRepository(FarmaciaDBContext context) : base(context)
    {
    }
}
