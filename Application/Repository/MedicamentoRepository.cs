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
}
}