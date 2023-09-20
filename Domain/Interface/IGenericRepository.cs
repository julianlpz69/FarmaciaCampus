using System.Linq.Expressions;
using Domain.Entities;

namespace Domain.Interface;

public interface IGenericRepository<T> where T : BaseEntity
{
    void Add(T entity);
    void AddRange(IEnumerable<T> entities);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
    void Update(T entity);
    Task<IEnumerable<T>> GetAllAsync();
    IEnumerable<T> Find(Expression<Func<T,bool>> expression);
    Task<T> GetById(int id);

}
