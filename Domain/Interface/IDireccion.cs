

using Domain.Entities;

namespace Domain.Interface;

public interface IDireccion : IGenericRepository<Direccion>
{
    Task<int> LastId();
}
