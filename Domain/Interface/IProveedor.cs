using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interface;

    public interface IProveedor : IGenericRepository<Proveedor>
    {
        Task<IEnumerable<Proveedor>> GetListWithName(string name);
        void Add(Proveedor entity, int IdDireccionFK);
        Task<IEnumerable<Proveedor>> GetPerProvSinFactura();
        Task<IEnumerable<Proveedor>> GetMedFrom2023();
        Task<IEnumerable<Proveedor>> GetOnlyWithMedLessThan50();
        Task<IEnumerable<Proveedor>> GetProveedoresCon5MedicamentosVendidos();
        Task<IEnumerable<Proveedor>> GetProveedorsConMasMedicamentosVendidos();
        void Update(Proveedor old, Proveedor nuevo);
    }
