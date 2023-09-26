using System.Globalization;
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
        decimal totalVentasConIVA = facturasVentas.Sum(fv => (decimal)fv.ValorTotal * (decimal)1.19);
        totalVentasConIVA = Math.Round(totalVentasConIVA, 3);

        return $"El total recaudado por las ventas es: $ {totalVentasConIVA}";
    }
    public async Task<int> VentasMarzoAsync()
    {
        int medicamentos = await _context.FacturaVentas
            .Where(fv => fv.FechaVenta.Year == 2023 && fv.FechaVenta.Month == 3)
            .Select(fv => fv.MedicamentosVendidos)
            .CountAsync();


        return medicamentos;
    }

    public async Task<Medicamento> MedicamentoMenosVendidoAsync()
    {
        var medicamentoMenosVendido = await _context.Medicamentos
            .OrderBy(m => m.MedicamentoVentas
                .Where(mv => mv.FacturaVenta.FechaVenta.Year == 2023)
                .Sum(mv => mv.CantidadVendida))
            .FirstOrDefaultAsync();
        return medicamentoMenosVendido;
    }

    public async Task<int> VentasEmpleado2023Async(int empleadoId)
    {
        var cantidadVentas = await _context.FacturaVentas
            .CountAsync(fv => fv.IdEmpleadoFK == empleadoId && fv.FechaVenta.Year == 2023);

        return cantidadVentas;
    }

    public async Task<int> TotalVentasPorMesEn2023Async(int numeroMes)
    {
        var totalMedicamentosVendidos = await _context.FacturaVentas
            .Where(f => f.FechaVenta.Year == 2023 && f.FechaVenta.Month == numeroMes)
            .SelectMany(f => f.MedicamentosVendidos)
            .SumAsync(m => m.CantidadVendida);

        return totalMedicamentosVendidos;
    }

    public async Task<IEnumerable<Medicamento>> MedicamentosVendidosCadaMesEn2023Async()
    {
        var medicamentosVendidos = await _context.FacturaVentas
            .Where(f => f.FechaVenta.Year == 2023)
            .SelectMany(f => f.MedicamentosVendidos)
            .GroupBy(m => m.Medicamento)
            .Where(g => g.Select(m => m.FacturaVenta.FechaVenta.Month).Distinct().Count() == 12)
            .Select(g => g.Key)
            .ToListAsync();

        return medicamentosVendidos;
    }

    public async Task<int> VentasPrimerTrimestre2023Async()
    {
        int medicamentos = await _context.FacturaVentas
            .Where(fv => fv.FechaVenta.Year == 2023 && fv.FechaVenta.Month >= 1 && fv.FechaVenta.Month <= 3)
            .Select(fv => fv.MedicamentosVendidos)
            .CountAsync();


        return medicamentos;
    }

    public async Task<IEnumerable<Medicamento>> MedicamentosNoVendidosAsync()
    {
        var medicamentosVendidos = await _context.MedicamentosVentas
            .Select(mv => mv.IdMedicamentoFK)
            .ToListAsync();

        var medicamentosNoVendidos = await _context.Medicamentos
            .Where(m => !medicamentosVendidos.Contains(m.Id))
            .ToListAsync();

        return medicamentosNoVendidos;
    }
    public async Task<double> PromedioMedicamentosCompradosPorVentaAsync()
    {
        var promedio = await _context.FacturaCompras
            .Where(fc => fc.FechaCompra.Year == 2023)
            .Select(fc => fc.MedicamentosComprados.Count)
            .DefaultIfEmpty(0)
            .AverageAsync();

        return promedio;
    }
    
    public async Task<IEnumerable<Receta>> RecetasEmitidas2023Async()
    {
        var fechaLimite = new DateTime(2023, 1, 1);

        var recetas = await _context.Recetas
            .Where(r => r.FacturaVenta.FechaVenta > fechaLimite)
            .ToListAsync();

        return recetas;
    }

}

