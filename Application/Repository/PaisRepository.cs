using System.Linq.Expressions;
using Domain.Interface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;

    public class PaisRepository : GenericRepository<Pais>, IPais
    {
     private readonly FarmaciaDBContext _context;
        public PaisRepository(FarmaciaDBContext context) : base(context)
        {
            _context = context;
        }

   public override async Task<IEnumerable<Pais>> GetAllAsync()
    {
        return await _context.Paises.Include(p => p.Departamentos).ThenInclude(d => d.Ciudades).ToListAsync();
    }
    public override async Task<Pais> GetById(int id)
    {
        var datos = await _context.Set<Pais>().Include(e => e.Departamentos).ToListAsync();
        return datos.Where(e => e.Id == id).FirstOrDefault();
    }
    }
