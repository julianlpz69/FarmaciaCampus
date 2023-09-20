using System.Linq.Expressions;
using Domain.Interface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class DepartamentoRepository : GenericRepository<Departamento>, IDepartamento
    {
     private readonly FarmaciaDBContext _context;
        public DepartamentoRepository(FarmaciaDBContext context) : base(context)
        {
            _context = context;
        }

   public override async Task<IEnumerable<Departamento>> GetAllAsync()
{
 return await _context.Departamentos.ToListAsync();
}  
}
}