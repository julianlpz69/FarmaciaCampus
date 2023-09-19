
using Domain.Interface;

namespace Application.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    public IProveedor Proveedores => throw new NotImplementedException();

    public IMedicamento Medicamentos => throw new NotImplementedException();

    public IPaciente Pacientes => throw new NotImplementedException();

    public IVenta Ventas => throw new NotImplementedException();

    public ICompras Compras => throw new NotImplementedException();

    public IEmpleado Empleados => throw new NotImplementedException();

    public Task<int> SaveAsync()
    {
        throw new NotImplementedException();
    }
}
