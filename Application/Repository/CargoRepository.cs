using System.Linq.Expressions;
using Domain.Interface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class CargoRepository : GenericRepository<Cargo>, ICargo
    {
        private readonly FarmaciaDBContext _context;
        public CargoRepository(FarmaciaDBContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Cargo>> GetAllAsync()
        {
            return await _context.Cargos.ToListAsync();
        }
    }
}