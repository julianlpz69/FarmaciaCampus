using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interface;

public interface IFacturaCompra : IGenericRepository<FacturaCompra>
{
    public Task<int> ProveedoresVendieronMedicamentosEn2023Async();
    public Task<IEnumerable<MedicamentoCompra>> GetMedicamentosCompradosAlProveedor(string nombreProveedor);

}
