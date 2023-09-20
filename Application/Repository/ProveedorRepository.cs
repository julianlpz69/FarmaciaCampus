using System.Linq.Expressions;
using Domain.Interface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class ProveedorRepository : GenericRepository<Proveedor>, IProveedor
    {
     private readonly FarmaciaDBContext _context;
        public ProveedorRepository(FarmaciaDBContext context) : base(context)
        {
            _context = context;
        }

   public override async Task<IEnumerable<Proveedor>> GetAllAsync()
{
 return await _context.Proveedores.ToListAsync();
}  
}
}