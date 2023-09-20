using System.Linq.Expressions;
using Domain.Interface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class CargoEmpleadoRepository : GenericRepository<CargoEmpleado>, ICargoEmpleado
    {
     private readonly FarmaciaDBContext _context;
        public CargoEmpleadoRepository(FarmaciaDBContext    context) : base(context)
        {
            _context = context;
        }

   public override async Task<IEnumerable<CargoEmpleado>> GetAllAsync()
{
 return await _context.CargosEmpleados.ToListAsync();
}  
}
}