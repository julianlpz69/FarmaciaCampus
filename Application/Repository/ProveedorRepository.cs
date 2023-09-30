

using Domain.Entities;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;

public class ProveedorRepository : GenericRepository<Proveedor>, IProveedor
{
    private readonly FarmaciaDBContext _context;
    public ProveedorRepository(FarmaciaDBContext context) : base(context)
    {
        _context = context;
    }
    // Obtener todos los datos de los proveedores
    public override async Task<IEnumerable<Proveedor>> GetAllAsync()
    {
        return await _context.Set<Proveedor>()
        .Include(e => e.Direccion)
        .ToListAsync();
    }
    public void Add(Proveedor entity, int IdDireccionFK)
    {
        entity.IdDireccionFK = IdDireccionFK;
        base.Add(entity);
    }
    // obtener los datos de los proveedores excluyendo la factura
    public async Task<IEnumerable<Proveedor>> GetPerProvSinFactura(){
        return await  _context.Set<Proveedor>()
        .Include(e => e.Medicamentos)
        .ThenInclude(e => e.MedicamentosCompras)
        .ToListAsync();
    }
    // Obtener Ganancias totales por proveedor
    public async Task<IEnumerable<Proveedor>> GetMedFrom2023(){
        return await  _context.Set<Proveedor>()
        .Include(e => e.FacturaCompras)
        .ToListAsync();
    }
    // total de medicamentos por cada proveedor
    public async Task<IEnumerable<Proveedor>> GetListWithName(string name){
        var datos = await  _context.Set<Proveedor>()
        .Include(e => e.Medicamentos)
        .Where(e => e.NombreProveedor == name)
        .ToListAsync();
        return datos;
    }
    public async Task<IEnumerable<Proveedor>> GetOnlyWithMedLessThan50(){
        var datos = await _context.Set<Proveedor>()
        .Include(e => e.Medicamentos)
        .ToListAsync();
        return datos.Where(e => e.Medicamentos.Where(e => e.Stock < 50).Any()).ToList();
    }
    public async Task<IEnumerable<Proveedor>> GetProveedoresCon5MedicamentosVendidos(){
        var data = await _context.Set<Proveedor>()
        .Include(e => e.FacturaCompras)
        .Include(e => e.Medicamentos)
        .ThenInclude(e => e.MedicamentosCompras)
        .ToListAsync();
        return data
        .Where(e => e.Medicamentos
            .Where(e => e.MedicamentosCompras.Any())
            .ToList().Count > 4)
        .Where(e => e.FacturaCompras
            .Where(e => e.FechaCompra> new DateTime(2023,1,1) && e.FechaCompra < new DateTime(2023,12,31)).Any()).ToList();
    }
    public async Task<IEnumerable<Proveedor>> GetProveedorsConMasMedicamentosVendidos(){
        var datos = await _context.Set<Proveedor>()
        .Include(e => e.Medicamentos)
        .ThenInclude(e => e.MedicamentosCompras)
        .ToListAsync();
        return datos.OrderByDescending(e => e.Medicamentos
        .Select(e => e.MedicamentosCompras.Select(e => e.CantidadComprada).Sum()).Sum()).ToList();
    }
    public override async Task<Proveedor> GetById(int id)
    {
        var dato = await _context.Set<Proveedor>().Include(e => e.Direccion).ToListAsync();
        return dato.Find(e => e.Id == id);
    }
    public void Update(Proveedor old, Proveedor nuevo)
    {
        old.NombreProveedor = nuevo.NombreProveedor;
        old.ContactoProveedor = nuevo.ContactoProveedor;
        
    }
}
