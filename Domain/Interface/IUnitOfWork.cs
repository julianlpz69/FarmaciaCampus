namespace Domain.Interface;

public interface IUnitOfWork
{
    IProveedor Proveedores {get;}
    IMedicamento Medicamentos {get;}
    IPaciente Pacientes {get;}
    IVenta Ventas {get;}
    ICompras Compras {get;}
    IEmpleado Empleados {get;}
    Task<int> SaveAsync(); 
}
