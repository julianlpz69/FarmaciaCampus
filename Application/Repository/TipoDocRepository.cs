using System.Linq.Expressions;
using Domain.Interface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository
{
    public class TipoDocumentoRepository : GenericRepository<TipoDocumento>, ITipoDocumento
    {
     private readonly FarmaciaDBContext _context;
        public TipoDocumentoRepository(FarmaciaDBContext context) : base(context)
        {
            _context = context;
        }

   public override async Task<IEnumerable<TipoDocumento>> GetAllAsync()
{
 return await _context.TipoDocumentos.ToListAsync();
}  
}
}