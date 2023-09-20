using Domain.Entities;
using Domain.Interface;
using Persistence.Data;

namespace Application.Repository;

public class FacturaBaseRepository : GenericRepository<FacturaBase>, IFacturaBase
{
    public FacturaBaseRepository(FarmaciaDBContext context) : base(context)
    {
    }
}
