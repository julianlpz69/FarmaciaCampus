namespace Domain.Interface;

public interface IUnitOfWork
{
    IProveedor Proveedores {get;}
    IMedicamentoVenta MedicamentoVentas {get;}
    IMedicamentoCompras MedicamentoCompras {get;}
    IMedicamento Medicamentos {get;}
    ICliente Clientes {get;}
    IFacturaVenta FacturaVentas {get;}
    IFacturaCompra FacturaCompras {get;}
    IEmpleado Empleados {get;}
    IDireccion Direcciones {get;}
    IPais Paises {get;}
    IDepartamento Departamentos {get;}
    ICiudad Ciudades {get;}
	IRol Roles { get; }
    IUser Users { get; }
    Task<int> SaveAsync(); 
}
