using Domain.Entities;
using Domain.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using System.Linq;


namespace Application.Repository;

public class MedicamentoRepository : GenericRepository<Medicamento>, IMedicamento
{
    private readonly FarmaciaDBContext _context;
    public MedicamentoRepository(FarmaciaDBContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Medicamento>> GetStock_50()
    {   

        var medicamentosEscasos = await _context.Medicamentos.Where(m => m.Stock < 50).ToListAsync();
        return medicamentosEscasos;
                

    }

    public async Task<IEnumerable<Medicamento>> GetExpiracion2024()
    {   
        DateTime fechaLimite = new DateTime(2024, 1, 1);
        var medicamentosEscasos = await _context.Medicamentos.Where(m => m.FechaExpiracion < fechaLimite).ToListAsync();
        return medicamentosEscasos;
                

    }

}
