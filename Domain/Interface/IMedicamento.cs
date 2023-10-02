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
         Task<IEnumerable<Medicamento>> GetExpiracionAntes2024();
         Task<IEnumerable<Medicamento>> ValorMas50StockMenor100();
         Task<IEnumerable<Medicamento>> MasCaros();
         void ActualizarStock(Medicamento medicamento);
         Task<Medicamento> GetByNombreAsync(string nombreMedicamento);
         
}
