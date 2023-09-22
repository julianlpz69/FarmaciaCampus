

using Domain.Entities;
using Domain.Interface;
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
        .Include(e => e.Medicamentos)
        .ToListAsync();
    }
    public async Task<IEnumerable<Proveedor>> GetPerProv(){
        return await  _context.Set<Proveedor>()
        .Include(e => e.FacturaCompras)
        .ThenInclude(e => e.MedicamentoCompras)
        .ThenInclude(e => e.Medicamento)
        .ToListAsync();
    }
    public async Task<IEnumerable<Proveedor>> GetListWithName(string name){
        var datos = await  _context.Set<Proveedor>()
        .Include(e => e.FacturaCompras)
        .ThenInclude(e => e.MedicamentoCompras)
        .ThenInclude(e => e.Medicamento)
        .Where(e => e.NombreProveedor == name)
        .ToListAsync();
        return datos;
    }
}
