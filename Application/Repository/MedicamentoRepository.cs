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


    public async Task<Medicamento> GetByNombreAsync(string nombreMedicamento)
    {
        return await _context.Medicamentos
            .FirstOrDefaultAsync(m => m.NombreMedicamento == nombreMedicamento);
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

    // public async Task<Medicamento> MasCaro()
    // {   
    
    //     var medicamentosEscasos =  await _context.Medicamentos.OrderByDescending(p => p.PrecioMedicamento).Include(p => p.Marca).Include(p => p.Proveedor).FirstOrDefaultAsync();
    //     return medicamentosEscasos;
                

    // }

    public void ActualizarStock(Medicamento medicamento){
        
    }

    public async Task<IEnumerable<Medicamento>> MasCaros()
{
    var medicamentosEscasos = await _context.Medicamentos.OrderByDescending(p => p.PrecioMedicamento)
        .Include(p => p.Marca)
        .Include(p => p.Proveedor)
        .ToListAsync();

    if (medicamentosEscasos.Count > 1 && medicamentosEscasos[0].PrecioMedicamento == medicamentosEscasos[1].PrecioMedicamento)
    {
        // Si hay más de un medicamento con el mismo precio más alto, devuelve todos ellos
        return medicamentosEscasos.TakeWhile(m => m.PrecioMedicamento == medicamentosEscasos[0].PrecioMedicamento).ToList();
    }
    else
    {
        // Si solo hay un medicamento con el precio más alto, devuelve ese medicamento
        return new List<Medicamento> { medicamentosEscasos[0] };
    }
}

}
