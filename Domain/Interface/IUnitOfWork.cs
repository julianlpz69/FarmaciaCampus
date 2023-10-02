namespace Domain.Interface;

public interface IUnitOfWork
{
    IProveedor Proveedores {get;}
    IMedicamentoVenta MedicamentoVentas {get;}
    IMedicamentoCompras MedicamentoCompras {get;}
    IMedicamento Medicamentos {get;}
    ITipoDocumento TiposDocumento {get;}
    ICargoEmpleado CargosEmpleado{get;}
    ICliente Clientes {get;}
    IFacturaVenta FacturaVentas {get;}
    IFacturaCompra FacturaCompras {get;}
    IMetodoPago MetodosPago { get; }
    IEmpleado Empleados {get;}
    IDireccion Direcciones {get;}
    IMarca Marcas {get;}
    IPais Paises {get;}
    IDepartamento Departamentos {get;}
    ICiudad Ciudades {get;}
	IRol Roles { get; }
    IUser Users { get; }
    Task<int> SaveAsync(); 
}
