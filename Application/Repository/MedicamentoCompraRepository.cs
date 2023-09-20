

using Domain.Entities;
using Domain.Interface;
using Persistence.Data;

namespace Application.Repository;

public class MedicamentoCompraRepository : GenericRepository<MedicamentoCompra>, IMedicamentoCompras
{
    public MedicamentoCompraRepository(FarmaciaDBContext context) : base(context)
    {
    }
}
