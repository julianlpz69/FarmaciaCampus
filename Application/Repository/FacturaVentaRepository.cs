using Domain.Entities;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;

public class FacturaVentaRepository : GenericRepository<FacturaVenta>, IFacturaVenta
{
    private readonly FarmaciaDBContext _context;
    public FacturaVentaRepository(FarmaciaDBContext context) : base(context)
    {
        _context = context;
    }

    public override async Task<IEnumerable<FacturaVenta>> GetAllAsync()
    {
        return await _context.FacturaVentas
            .Include(p => p.MedicamentosVendidos)
            .ToListAsync();
    }

    public async Task<string> TotalVentas()
    {
        var facturasVentas = await _context.FacturaVentas.ToListAsync();
        decimal totalVentasConIVA = facturasVentas.Sum(fv => (decimal)fv.ValorTotalMasIva);
        totalVentasConIVA = Math.Round(totalVentasConIVA, 3);

        return $"El total recaudado por las ventas es: $ {totalVentasConIVA}";
    }
    public async Task<int> VentasMarzoAsync()
    {
        DateTime InicioMarzo = new DateTime(2023, 3, 1);
        DateTime FinMarzo = new DateTime(2023, 3, 31);

        int medicamentos = await _context.FacturaVentas
            .Where(fv => fv.FechaVenta >= InicioMarzo && fv.FechaVenta <= FinMarzo)
            .SelectMany(fv => fv.MedicamentosVendidos)
            .SumAsync(mv => mv.CantidadVendida);

        return medicamentos;
    }

    public async Task<Medicamento> MedicamentoMenosVendidoAsync()
    {
        DateTime fechaInicio2023 = new DateTime(2023, 1, 1);
        DateTime fechaFin2023 = new DateTime(2023, 12, 31);

        var medicamentoMenosVendido = await _context.Medicamentos
            .OrderBy(m => m.MedicamentoVentas
                .Where(mv => mv.FacturaVenta.FechaVenta >= fechaInicio2023 && mv.FacturaVenta.FechaVenta <= fechaFin2023)
                .Sum(mv => mv.CantidadVendida))
            .FirstOrDefaultAsync();
        return medicamentoMenosVendido;
    }

    public async Task<int> VentasEmpleado2023Async(int empleadoId)
    {
        DateTime fechaInicio2023 = new DateTime(2023, 1, 1);
        DateTime fechaFin2023 = new DateTime(2023, 12, 31);

        var cantidadVentas = await _context.FacturaVentas
            .CountAsync(fv => fv.IdEmpleadoFK == empleadoId && fv.FechaVenta >= fechaInicio2023 && fv.FechaVenta <= fechaFin2023);

        return cantidadVentas;
    }


}

