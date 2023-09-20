using System.Linq.Expressions;
using Domain.Interface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class MedicamentoRepository : GenericRepository<Medicamento>, IMedicamento
    {
        private readonly FarmaciaDBContext _context;
        public MedicamentoRepository(FarmaciaDBContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Medicamento>> GetAllAsync()
        {
            return await _context.Medicamentos.ToListAsync();
        }
        public async Task<IEnumerable<Medicamento>> GetMenos50UnidadesAsync()
        {
            return await _context.Medicamentos
                .Where(m => m.Stock < 50)
                .ToListAsync();
        }
        public async Task<Medicamento> ObtenerMedicamentoMasCaroAsync()
        {
            return await _context.Medicamentos
                .OrderByDescending(m => m.PrecioMedicamento)
                .FirstOrDefaultAsync();
        }
    }
}