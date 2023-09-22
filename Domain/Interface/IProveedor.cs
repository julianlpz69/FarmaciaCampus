using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interface;

    public interface IProveedor : IGenericRepository<Proveedor>
    {
        Task<IEnumerable<Proveedor>> GetListWithName(string name);
        Task<IEnumerable<Proveedor>> GetPerProvSinFactura();
        Task<IEnumerable<Proveedor>> GetMedFrom2023();
        Task<IEnumerable<Proveedor>> GetOnlyWithMedLessThan50();
        
    }
