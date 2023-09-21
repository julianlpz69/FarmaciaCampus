
using Application.Repository;
using CsvHelper;
using Domain.Interface;
using Persistence.Data;

namespace Application.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private FacturaBaseRepository _facturaBase;
    private FacturaCompraRepository _facturaCompra;
    private FacturaVentaRepository _facturaVenta;
    private MedicamentoCompraRepository _medicamentoCompra;
    private ClienteRepository _cliente;
    private DireccionRepository _direccion;
    private EmpleadoRepository _empleado;
    private MedicamentoRepository _medicamento;
    private ProveedorRepository _proveedor;
    private MedicamentoVentaRepository _medicamentoVenta;
    private readonly FarmaciaDBContext _context; 
	private IRol _roles;
    private IUser _users;
    public UnitOfWork(FarmaciaDBContext context){
        _context = context;
    }
    public IProveedor Proveedores {
        get{
            if(_proveedor == null){
                _proveedor = new (_context);
            }
            return _proveedor;
        }   
    }

    public IMedicamentoVenta MedicamentoVentas {
        get{
            if(_medicamentoVenta == null){
                _medicamentoVenta = new(_context);
            }
            return _medicamentoVenta;
        }
    }

    public IMedicamentoCompras MedicamentoCompras
    {
        get{
            if(_medicamentoCompra ==null){
                _medicamentoCompra = new(_context);
            }
            return _medicamentoCompra;
        }
    }

    public IMedicamento Medicamentos 
    {
        get{
            if(_medicamento == null){
                _medicamento = new (_context);
            }
            return _medicamento;
        }
    }

    public ICliente Clientes
    {
        get{
            if(_cliente == null){
                _cliente = new (_context);
            }
            return _cliente;
        }
    }

    public IFacturaVenta FacturaVentas 
    {
        get{
            if(_facturaVenta == null){
                _facturaVenta = new (_context);
            }
            return _facturaVenta;
        }
    }

    public IFacturaCompra FacturaCompras 
    {
        get{
            if(_facturaCompra == null){
                _facturaCompra = new (_context);
            }
            return _facturaCompra;
        }
    }

    public IEmpleado Empleados
    {
        get{
            if(_empleado == null){
                _empleado = new (_context);
            }
            return _empleado;
        }
    }

    public IDireccion Direcciones
    {
        get{
            if(_direccion == null){
                _direccion = new (_context);
            }
            return _direccion;
        }
    }

    public IFacturaBase FacturaBases
    {
        get{
            if(_facturaBase == null){
                _facturaBase = new(_context);
            }
            return _facturaBase;
        }
    }

 public IRol Roles
    {
        get
        {
            if (_roles == null)
            {
                _roles = new RolRepository(_context);
            }
            return _roles;
        }
    }

    public IUser Users
    {
        get
        {
            if (_users == null)
            {
                _users = new UserRepository(_context);
            }
            return _users;
        }
    }


    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
