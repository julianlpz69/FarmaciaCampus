using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interface;

public interface IMedicamentoVenta : IGenericRepository<MedicamentoVenta> 
{

    public Task<string> CantidadVentasParacetamol();
    public Task<IEnumerable<Cliente>> GetPacientesParacetamolAsync();
}
