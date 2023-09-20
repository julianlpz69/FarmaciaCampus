namespace Domain.Interface;

public interface IUnitOfWork
{
    Task<int> SaveAsync(); 
}
