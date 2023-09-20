using System.Linq.Expressions;
using Domain.Interface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class FacturaVentaRepository : GenericRepository<FacturaVenta>, IFacturaVenta
    {
     private readonly FarmaciaDBContext _context;
        public FacturaVentaRepository(FarmaciaDBContext context) : base(context)
        {
            _context = context;
        }

   public override async Task<IEnumerable<FacturaVenta>> GetAllAsync()
{
 return await _context.FacturaVentas.ToListAsync();
}  
}
}