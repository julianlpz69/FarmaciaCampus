using System.Linq.Expressions;
using Domain.Entities;
using Domain.Interface;
using Persistence.Data;

namespace Application.Repository;

public class CompraRepository : GenericRepository<Compra>, ICompras
{
    private readonly FarmaciaDBContext _context;
    public CompraRepository(FarmaciaDBContext context) : base(context)
    {
        _context = context;
    }
    public override Task<IEnumerable<Compra>> GetAllAsync()
    {
        return base.GetAllAsync();
    }
    public override Task<Compra> GetById(int id)
    {
        return base.GetById(id);
    }
    public override void Add(Compra entity)
    {
        base.Add(entity);
    }
    public override void AddRange(IEnumerable<Compra> entities)
    {
        base.AddRange(entities);
    }
    public override IEnumerable<Compra> Find(Expression<Func<Compra, bool>> expression)
    {
        return base.Find(expression);
    }
}
