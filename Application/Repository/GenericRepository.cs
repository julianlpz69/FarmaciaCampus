using System.Linq.Expressions;
using Domain.Entities;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly FarmaciaDBContext _context;
    public GenericRepository(FarmaciaDBContext context){
        _context = context;
    }
    public virtual void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public virtual void AddRange(IEnumerable<T> entities)
    {
        _context.Set<T>().AddRange(entities);
    }

    public virtual IEnumerable<T> Find(Expression<Func<T, bool>> expression)
    {
        return _context.Set<T>().Where(expression);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public virtual async Task<T> GetById(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public void Remove(T entity)
    {
        _context.Set<T>().Remove(entity);   
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        _context.Set<T>().AddRange(entities);
    }
}
