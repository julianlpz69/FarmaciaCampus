using Domain.Entities;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;

public class MedicamentoVentaRepository : GenericRepository<MedicamentoVenta>, IMedicamentoVenta
{
    private readonly FarmaciaDBContext _context;

    public MedicamentoVentaRepository(FarmaciaDBContext context) : base(context)
    {
        _context = context;
    }

    public double CalcularTotalVentasParacetamol()
    {
        string nombreMedicamento = "Paracetamol";

        var totalVentas = _context.MedicamentosVentas
            .Where(mv => mv.Medicamento.NombreMedicamento.ToLower() == nombreMedicamento.ToLower())
            .Sum(mv => mv.Precio * mv.CantidadVendida);

        return totalVentas;
    }

    public double CalcularTotalDineroRecaudadoPorVentas()
    {
        var totalDineroRecaudado = _context.MedicamentosVentas
            .Sum(mv => mv.Precio * mv.CantidadVendida);

        return totalDineroRecaudado;
    }
    public async Task<IEnumerable<Cliente>> GetPacientesQueCompraronParacetamolAsync()
    {

        string nombreMedicamento = "Paracetamol";
        var pacientesQueCompraronParacetamol = await _context.MedicamentosVentas
            .Where(mv => mv.Medicamento.NombreMedicamento.ToLower() == nombreMedicamento.ToLower())
            .Select(mv => mv.FacturaVenta.Cliente) 
            .Distinct() 
            .ToListAsync(); 

        return pacientesQueCompraronParacetamol;
    }
}


