

using Domain.Entities;
using Domain.Interface;
using Persistence.Data;

namespace Application.Repository;

public class EmpleadoRepository : GenericRepository<Persona>, IEmpleado
{
    public EmpleadoRepository(FarmaciaDBContext context) : base(context)
    {
    }
}
