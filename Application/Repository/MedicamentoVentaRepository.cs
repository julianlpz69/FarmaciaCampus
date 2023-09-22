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

    public async Task<string> CantidadVentasParacetamol()
    {
        string nombreMedicamento = "Paracetamol";
        int cantidadTotalVentas = await _context.MedicamentosVentas
            .Where(mv => mv.Medicamento.NombreMedicamento.ToLower() == nombreMedicamento.ToLower())
            .SumAsync(mv => mv.CantidadVendida);

        return "La cantidad total de veces que se ha vendido " + nombreMedicamento + " es: " + cantidadTotalVentas;
    }


    public async Task<IEnumerable<Cliente>> GetPacientesParacetamolAsync()
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



