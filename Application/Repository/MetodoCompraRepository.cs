using System.Linq.Expressions;
using Domain.Interface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class MetodoCompraRepository : GenericRepository<MetodoCompra>, IMetodoCompra
    {
     private readonly FarmaciaDBContext _context;
        public MetodoCompraRepository(FarmaciaDBContext context) : base(context)
        {
            _context = context;
        }

   public override async Task<IEnumerable<MetodoCompra>> GetAllAsync()
{
 return await _context.MetodosCompras.ToListAsync();
}  
}
}