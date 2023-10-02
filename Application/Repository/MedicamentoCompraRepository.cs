

using Domain.Entities;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;

public class MedicamentoCompraRepository : GenericRepository<MedicamentoCompra>, IMedicamentoCompras
{
    private readonly FarmaciaDBContext _context;
    public MedicamentoCompraRepository(FarmaciaDBContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<MedicamentoCompra>> GetAllAsync()
    {
        return await _context.MedicamentosCompras
            .Include(p => p.Medicamento)
            .ToListAsync();
    }
    public override async Task<MedicamentoCompra> GetById(int id)
    {
        return await _context.Set<MedicamentoCompra>().Include(p => p.Medicamento).FirstOrDefaultAsync(p => p.Id == id);
    }
}
