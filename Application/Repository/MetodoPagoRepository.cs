

using Domain.Entities;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;

public class MetodoPagoRepository : GenericRepository<MetodoPago>, IMetodoPago
{
    private readonly FarmaciaDBContext _context;
    public MetodoPagoRepository(FarmaciaDBContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<MetodoPago>> GetAllAsync()
    {
        return await _context.MetodoCoPagos
            .ToListAsync();
    }
    public override async Task<MetodoPago> GetById(int id)
    {
        return await _context.Set<MetodoPago>().FirstOrDefaultAsync(p => p.Id == id);
    }
}
