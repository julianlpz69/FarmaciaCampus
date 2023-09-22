

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
    public override async Task<IEnumerable<Proveedor>> GetAllAsync()
    {
        return await _context.Set<Proveedor>()
        .Include(e => e.Direccion)
        .ToListAsync();
    }
    public async Task<IEnumerable<Proveedor>> GetPerProvSinFactura(){
        return await  _context.Set<Proveedor>()
        .Include(e => e.Medicamentos)
        .ThenInclude(e => e.MedicamentosCompras)
        .ToListAsync();
    }
    public async Task<IEnumerable<Proveedor>> GetMedFrom2023(){
        return await  _context.Set<Proveedor>()
        .Include(e => e.FacturaCompras)
        .ToListAsync();
    }
    public async Task<IEnumerable<Proveedor>> GetListWithName(string name){
        var datos = await  _context.Set<Proveedor>()
        .Include(e => e.FacturaCompras)
        .ThenInclude(e => e.MedicamentosComprados)
        .ThenInclude(e => e.Medicamento)
        .Where(e => e.NombreProveedor == name)
        .ToListAsync();
        return datos;
    }
    public async Task<IEnumerable<Proveedor>> GetOnlyWithMedLessThan50(){
        return await _context.Set<Proveedor>()
        .Include(e => e.Medicamentos.Where(e => e.Stock < 50))
        .ToListAsync();
    }
}
