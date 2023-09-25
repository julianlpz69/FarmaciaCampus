using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interface;

public interface IFacturaVenta : IGenericRepository<FacturaVenta>
{
    public Task<string> TotalVentas();
    public  Task<int> VentasMarzoAsync();
    public Task<Medicamento> MedicamentoMenosVendidoAsync();

    public Task<int> VentasEmpleado2023Async(int empleadoId);

}
