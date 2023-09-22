

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
    public async Task<IEnumerable<Empleado>> EmpleadosMas5Ventas()
    {
        var empleados = await _context.Empleados
        .Where(fv => fv.FacturaVentas.Count() >= 5)
        .ToListAsync();

        return empleados;
    }
    public async Task<IEnumerable<Empleado>> EmpleadosMenos5Ventas()
    {
        DateTime fechaInicio2023 = new DateTime(2023, 1, 1);
        DateTime fechaFin2023 = new DateTime(2023, 12, 31);
        var empleados = await _context.Empleados
        .Where(fv => fv.FacturaVentas.Where(f => f.FechaVenta >= fechaInicio2023 && f.FechaVenta <= fechaFin2023).Count() < 5)
        .ToListAsync();

        return empleados;
    }

}
