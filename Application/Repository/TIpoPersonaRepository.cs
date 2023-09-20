using System.Linq.Expressions;
using Domain.Interface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class TipoPersonaRepository : GenericRepository<TipoPersona>, ITipoPersona
    {
     private readonly FarmaciaDBContext _context;
        public TipoPersonaRepository(FarmaciaDBContext context) : base(context)
        {
            _context = context;
        }

   public override async Task<IEnumerable<TipoPersona>> GetAllAsync()
{
 return await _context.TiposPersonas.ToListAsync();
}  
}
}