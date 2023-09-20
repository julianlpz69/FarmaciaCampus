

using Domain.Entities;
using Domain.Interface;
using Persistence.Data;

namespace Application.Repository;

public class FacturaCompraRepository : GenericRepository<FacturaCompra>, IFacturaCompra
{
    public FacturaCompraRepository(FarmaciaDBContext context) : base(context)
    {
    }
}
