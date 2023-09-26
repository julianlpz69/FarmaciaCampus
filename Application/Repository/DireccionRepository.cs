

using Domain.Entities;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;

public class DireccionRepository : GenericRepository<Direccion>, IDireccion
{
    private readonly FarmaciaDBContext _context;
    public DireccionRepository(FarmaciaDBContext context) : base(context)
    {
        _context = context;
    }
    public override void Add(Direccion entity)
    {
        base.Add(entity);
    }
    public async Task<int> LastId(){
        var data=  await _context.Set<Direccion>().OrderByDescending(e => e.Id).LastAsync();
        return data.Id;
    }
}
