namespace Domain.Interface;

public interface IUnitOfWork
{
    IProveedor Proveedores {get;}
    IMedicamentoVenta MedicamentoVentas {get;}
    IMedicamentoCompras MedicamentoCompras {get;}
    IMedicamento Medicamentos {get;}
    IPaciente Pacientes {get;}
    IFacturaVenta FacturaVentas {get;}
    IFacturaCompra FacturaCompras {get;}
    IEmpleado Empleados {get;}
    IDireccion Direcciones {get;}
    IFacturaBase FacturaBases {get;}
    Task<int> SaveAsync(); 
}
