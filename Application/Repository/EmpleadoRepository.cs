

using Domain.Entities;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;

public class EmpleadoRepository : GenericRepository<Empleado>, IEmpleado
{
    private readonly FarmaciaDBContext _context;
    public EmpleadoRepository(FarmaciaDBContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<Empleado>> GetAllAsync()
    {
        return await _context.Empleados
            .Include(p => p.Direccion)
            .Include(p => p.CargoEmpleado)
            .ToListAsync();
    }
    public async Task<IEnumerable<Empleado>> EmpleadosMas5Ventas()
    {
        var empleados = await _context.Empleados
        .Where(fv => fv.FacturaVentas.Count() >= 5)
        .ToListAsync();

        return empleados;
    }
    public async Task<IEnumerable<Empleado>> EmpleadosMenos5Ventas()
    {
        var empleados = await _context.Empleados
        .Where(fv => fv.FacturaVentas.Where(f => f.FechaVenta.Year == 2023).Count() < 5)
        .ToListAsync();

        return empleados;
    }

    public async Task<IEnumerable<Empleado>> EmpleadosSinVentasAsync()
    {
        var empleadosSinVentas = await _context.Empleados
            .Where(e => !e.FacturaVentas
                .Any(v => v.FechaVenta.Year == 2023))
            .ToListAsync();

        return empleadosSinVentas;
    }
    public async Task<IEnumerable<Empleado>> EmpleadosSinVentasAbril2023Async()
    {
        var empleadosSinVentas = await _context.Empleados
            .Where(e => !e.FacturaVentas
                .Any(v => v.FechaVenta.Year == 2023 && v.FechaVenta.Month == 4))
            .ToListAsync();

        return empleadosSinVentas;
    }
    public async Task<Empleado> EmpleadoConMasMedicamentosDistintosVendidosEn2023Async()
    {
        var ventas = await _context.FacturaVentas
            .Where(f => f.FechaVenta.Year == 2023)
            .Include(f => f.Empleado)
            .Include(f => f.MedicamentosVendidos)
            .ThenInclude(mv => mv.Medicamento)
            .ToListAsync();

        var empleado = ventas
            .SelectMany(f => f.MedicamentosVendidos.Select(mv => new { f.Empleado, mv.Medicamento }))
            .GroupBy(x => x.Empleado)
            .Select(g => new { Empleado = g.Key, CantidadMedicamentosDistintos = g.Select(x => x.Medicamento).Distinct().Count() })
            .OrderByDescending(x => x.CantidadMedicamentosDistintos)
            .FirstOrDefault();

        return empleado?.Empleado;
    }





}
