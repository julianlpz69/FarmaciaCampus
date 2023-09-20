using System.Linq.Expressions;
using Domain.Interface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class FacturaCompraRepository : GenericRepository<FacturaCompra>, IFacturaCompra
    {
     private readonly FarmaciaDBContext _context;
        public FacturaCompraRepository(FarmaciaDBContext context) : base(context)
        {
            _context = context;
        }

   public override async Task<IEnumerable<FacturaCompra>> GetAllAsync()
{
 return await _context.FacturaCompras.ToListAsync();
}  
}
}