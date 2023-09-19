using Domain.Entities;
using Domain.Interface;
using Persistence.Data;

namespace Application.Repository;

public class EmpleadoRepository : GenericRepository<Empleado>, IEmpleado
{
    private readonly FarmaciaDBContext _context;
    public EmpleadoRepository(FarmaciaDBContext context) : base(context)
    {
        _context = context;
    }
}
