using System.Linq.Expressions;
using Domain.Interface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class MedicamentoVentaRepository : GenericRepository<MedicamentoVenta>, IMedicamentoVenta
    {
     private readonly FarmaciaDBContext _context;
        public MedicamentoVentaRepository(FarmaciaDBContext context) : base(context)
        {
            _context = context;
        }

   public override async Task<IEnumerable<MedicamentoVenta>> GetAllAsync()
{
 return await _context.MedicamentosVentas.ToListAsync();
}  
}
}