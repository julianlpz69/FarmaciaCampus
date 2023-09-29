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



    public override async Task<IEnumerable<Medicamento>> GetAllAsync()
    {
        return await _context.Medicamentos
            .Include(p => p.Marca)
            .Include(p => p.Proveedor)
            .ToListAsync();
    }
    public override async Task<Medicamento> GetById(int id)
    {
        return await _context.Set<Medicamento>().Include(p => p.Marca).Include(p => p.Proveedor).FirstOrDefaultAsync(p => p.Id == id);
    }


    public async Task<IEnumerable<Medicamento>> GetStock_50()
    {   

        var medicamentosEscasos = await _context.Medicamentos.Where(m => m.Stock < 50).Include(p => p.Marca).Include(p => p.Proveedor).ToListAsync();
        return medicamentosEscasos;
                

    }

    public async Task<IEnumerable<Medicamento>> GetExpiracion2024()
    {   
        DateTime fechaLimite = new DateTime(2024, 1, 1);
        DateTime fechaLimite2 = new DateTime(2025, 1, 1);
        var medicamentosEscasos = await _context.Medicamentos.Where(m => m.FechaExpiracion >= fechaLimite && m.FechaExpiracion < fechaLimite2).Include(p => p.Marca).Include(p => p.Proveedor).ToListAsync();
        return medicamentosEscasos;
                

    }
    

    public async Task<IEnumerable<Medicamento>> GetExpiracionAntes2024()
    {   
        DateTime fechaLimite = new DateTime(2024, 1, 1);
        var medicamentosEscasos = await _context.Medicamentos.Where(m => m.FechaExpiracion < fechaLimite).Include(p => p.Marca).Include(p => p.Proveedor).ToListAsync();
        return medicamentosEscasos;
                

    }

    public async Task<IEnumerable<Medicamento>> ValorMas50StockMenor100()
    {   
    
        var medicamentosEscasos = await _context.Medicamentos.Where(m => m.PrecioMedicamento > 50.00 && m.Stock < 100).Include(p => p.Marca).Include(p => p.Proveedor).ToListAsync();
        return medicamentosEscasos;
                

    }

    public async Task<Medicamento> MasCaro()
    {   
    
        var medicamentosEscasos =  await _context.Medicamentos.OrderByDescending(p => p.PrecioMedicamento).Include(p => p.Marca).Include(p => p.Proveedor).FirstOrDefaultAsync();
        return medicamentosEscasos;
                

    }
}
