using Domain.Entities;
using Domain.Interface;
using Persistence.Data;

namespace Application.Repository;

public class MedicamentoVentaRepository : GenericRepository<MedicamentoVenta>, IMedicamentoVenta
{
    public MedicamentoVentaRepository(FarmaciaDBContext context) : base(context)
    {
    }
}
