using Domain.Entities;
using Domain.Interface;
using Persistence.Data;

namespace Application.Repository;

public class MedicamentoRepository : GenericRepository<Medicamento>, IMedicamento
{
    public MedicamentoRepository(FarmaciaDBContext context) : base(context)
    {
    }
}
