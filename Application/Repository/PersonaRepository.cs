using System.Linq.Expressions;
using Domain.Interface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class PersonaRepository : GenericRepository<Persona>, IPersona
    {
     private readonly FarmaciaDBContext _context;
        public PersonaRepository(FarmaciaDBContext context) : base(context)
        {
            _context = context;
        }

   public override async Task<IEnumerable<Persona>> GetAllAsync()
{
 return await _context.Personas.ToListAsync();
}  
}
}