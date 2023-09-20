using System.Linq.Expressions;
using Domain.Interface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class MarcaRepository : GenericRepository<Marca>, IMarca
    {
     private readonly FarmaciaDBContext _context;
        public MarcaRepository(FarmaciaDBContext context) : base(context)
        {
            _context = context;
        }

   public override async Task<IEnumerable<Marca>> GetAllAsync()
{
 return await _context.Marcas.ToListAsync();
}  
}
}