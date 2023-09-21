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
	IRol Roles { get; }
    IUser Users { get; }
    IFacturaBase FacturaBases {get;}
    Task<int> SaveAsync(); 
}
