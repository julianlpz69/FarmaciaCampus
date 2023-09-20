using System.Linq.Expressions;
using Domain.Interface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class FacturaBaseRepository : GenericRepository<FacturaBase>, IFacturaBase
    {
     private readonly FarmaciaDBContext _context;
        public FacturaBaseRepository(FarmaciaDBContext context) : base(context)
        {
            _context = context;
        }

   public override async Task<IEnumerable<FacturaBase>> GetAllAsync()
{
 return await _context.FacturaBases.ToListAsync();
}  
}
}