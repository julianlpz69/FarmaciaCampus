using Domain.Entities;
using Domain.Interface;
using Persistence.Data;

namespace Application.Repository;

public class VentaRepository : GenericRepository<Venta>, IVenta
{
    private readonly FarmaciaDBContext _context;
    public VentaRepository(FarmaciaDBContext context) : base(context)
    {
        _context = context;
    }
}
