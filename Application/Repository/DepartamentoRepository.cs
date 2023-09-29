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
        public override async Task<Departamento> GetById(int id)
        {
            var datos = await _context.Set<Departamento>().Include(e => e.Ciudades).ToListAsync();
            return datos.Where(e => e.Id == id).FirstOrDefault();
        }
    }
}