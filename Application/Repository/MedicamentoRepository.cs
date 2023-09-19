using Domain.Entities;
using Domain.Interface;
using Persistence.Data;

namespace Application.Repository;

public class MedicamentoRepository : GenericRepository<Medicamento>, IMedicamento
{
    private readonly FarmaciaDBContext _context;
    public MedicamentoRepository(FarmaciaDBContext context) : base(context)
    {
        _context = context;
    }
}
