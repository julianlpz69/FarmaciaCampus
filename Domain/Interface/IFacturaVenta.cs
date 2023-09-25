using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interface;

public interface IFacturaVenta : IGenericRepository<FacturaVenta>
{
    public Task<string> TotalVentas();
    public Task<int> VentasMarzoAsync();
    public Task<Medicamento> MedicamentoMenosVendidoAsync();

    public Task<int> VentasEmpleado2023Async(int empleadoId);
    public Task<int> TotalVentasPorMesEn2023Async(int numeroMes);
    public Task<IEnumerable<Medicamento>> MedicamentosVendidosCadaMesEn2023Async();
    public Task<int> VentasPrimerTrimestre2023Async();

}
