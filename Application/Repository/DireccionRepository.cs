

using Domain.Entities;
using Domain.Interface;
using Persistence.Data;

namespace Application.Repository;

public class DireccionRepository : GenericRepository<Direccion>, IDireccion
{
    public DireccionRepository(FarmaciaDBContext context) : base(context)
    {
    }
}
