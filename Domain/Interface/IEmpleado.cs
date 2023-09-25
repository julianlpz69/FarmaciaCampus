using Domain.Entities;

namespace Domain.Interface;

public interface IEmpleado : IGenericRepository<Empleado>
{
    public Task<IEnumerable<Empleado>> EmpleadosMas5Ventas();
    public Task<IEnumerable<Empleado>> EmpleadosMenos5Ventas();
}
