

using Domain.Entities;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;

public class FacturaCompraRepository : GenericRepository<FacturaCompra>, IFacturaCompra
{
    private readonly FarmaciaDBContext _context;
    public FacturaCompraRepository(FarmaciaDBContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<FacturaCompra>> GetAllAsync()
    {
        return await _context.FacturaCompras
            .Include(p => p.MedicamentosComprados)
            .ThenInclude(a => a.Medicamento)
            .Include(e => e.MetodoPago)
            .Include(p => p.Proveedor)
            .ToListAsync();
    }
    public override async Task<FacturaCompra> GetById(int id)
    {
        return await _context.Set<FacturaCompra>().Include(p => p.MedicamentosComprados)
        .ThenInclude(a => a.Medicamento)
        .Include(p => p.Proveedor)
        .Include(p => p.MetodoPago).FirstOrDefaultAsync(p => p.Id == id);
    }
    public async Task<int> ProveedoresVendieronMedicamentosEn2023Async()
    {
        var facturasCompra2023 = await _context.FacturaCompras
            .Where(f => f.FechaCompra.Year == 2023)
            .Include(f => f.Proveedor) 
            .ToListAsync();

        var proveedoresEn2023 = facturasCompra2023
            .Select(f => f.Proveedor)
            .Distinct()
            .ToList();

        return proveedoresEn2023.Count;
    }
    public async Task<IEnumerable<MedicamentoCompra>> GetMedicamentosCompradosAlProveedor(string nombreProveedor)
    {
        var query = _context.FacturaCompras
            .Include(fc => fc.MedicamentosComprados)
                .ThenInclude(mc => mc.Medicamento)
                    .ThenInclude(m => m.Proveedor)
            .Where(fc => fc.MedicamentosComprados.Any(mc => mc.Medicamento.Proveedor.NombreProveedor == nombreProveedor));

        var facturasConMedicamentosProveedor = await query.ToListAsync();

        var medicamentosProveedor = facturasConMedicamentosProveedor
            .SelectMany(fc => fc.MedicamentosComprados)
            .Where(mc => mc.Medicamento.Proveedor.NombreProveedor == nombreProveedor)
            .ToList();

        return medicamentosProveedor;
    }

}
