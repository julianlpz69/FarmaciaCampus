
using Application.Repository;
using CsvHelper;
using Domain.Entities;
using Domain.Interface;
using Persistence.Data;

namespace Application.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private FacturaCompraRepository _facturaCompra;
    private FacturaVentaRepository _facturaVenta;
    private MedicamentoCompraRepository _medicamentoCompra;
    private ClienteRepository _cliente;
    private DireccionRepository _direccion;
    private EmpleadoRepository _empleado;
    private MedicamentoRepository _medicamento;
    private ProveedorRepository _proveedor;
    private MedicamentoVentaRepository _medicamentoVenta;
    private PaisRepository _pais;
    private MarcaRepository _marca;
    private DepartamentoRepository _departamento;
    private CiudadRepository _ciudad;
    private MetodoPagoRepository _metodoPago;
    private CargoEmpleadoRepository _cargoEmpleado;
    private TipoDocumentoRepository _tipoDoc;
    private readonly FarmaciaDBContext _context; 
	private IRol _roles;
    private IUser _users;
    public UnitOfWork(FarmaciaDBContext context){
        _context = context;
    }

    public ITipoDocumento TiposDocumento
    {
        get
        {
            if (_tipoDoc == null)
            {
                _tipoDoc = new(_context);
            }
            return _tipoDoc;
        }
    }
    public ICargoEmpleado CargosEmpleado
    {
        get
        {
            if (_cargoEmpleado == null)
            {
                _cargoEmpleado = new(_context);
            }
            return _cargoEmpleado;
        }
    }
    public IMetodoPago MetodosPago
    {
        get
        {
            if (_metodoPago == null)
            {
                _metodoPago = new(_context);
            }
            return _metodoPago;
        }
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

    public IDepartamento Departamentos
    {
        get
        {
            if (_departamento == null)
            {
                _departamento = new(_context);
            }
            return _departamento;
        }
    }
    public IPais Paises
    {
        get
        {
            if (_pais == null)
            {
                _pais = new(_context);
            }
            return _pais;
        }
    }
    public ICiudad Ciudades
    {
        get
        {
            if (_ciudad == null)
            {
                _ciudad = new(_context);
            }
            return _ciudad;
        }
    }

    public IMarca Marcas
    {
        get
        {
            if (_marca == null)
            {
                _marca = new(_context);
            }
            return _marca;
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
