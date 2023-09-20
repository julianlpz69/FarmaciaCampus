using System.Linq.Expressions;
using Domain.Interface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class MedicamentoCompraRepository : GenericRepository<MedicamentoCompra>, IMedicamentoCompras
    {
        private readonly FarmaciaDBContext _context;
        public MedicamentoCompraRepository(FarmaciaDBContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<MedicamentoCompra>> GetAllAsync()
        {
            return await _context.MedicamentosCompras.ToListAsync();
        }
    }
}