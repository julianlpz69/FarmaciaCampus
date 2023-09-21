using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interface;

public interface IMedicamento : IGenericRepository<Medicamento>
{
         Task<IEnumerable<Medicamento>> GetStock_50();
         Task<IEnumerable<Medicamento>> GetExpiracion2024();
}
