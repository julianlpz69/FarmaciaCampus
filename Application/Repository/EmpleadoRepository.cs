

using Domain.Entities;
using Domain.Interface;
using Persistence.Data;

namespace Application.Repository;

public class EmpleadoRepository : GenericRepository<Empleado>, IEmpleado
{
    public EmpleadoRepository(FarmaciaDBContext context) : base(context)
    {
    }
}
