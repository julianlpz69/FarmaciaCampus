using System.Linq.Expressions;
using Domain.Interface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class DireccionRepository : GenericRepository<Direccion>, IDireccion
    {
     private readonly FarmaciaDBContext _context;
        public DireccionRepository(FarmaciaDBContext context) : base(context)
        {
            _context = context;
        }

   public override async Task<IEnumerable<Direccion>> GetAllAsync()
{
 return await _context.Direcciones.ToListAsync();
}  
}
}