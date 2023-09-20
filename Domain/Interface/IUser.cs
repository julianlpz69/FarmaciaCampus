using Domain.Entities;


namespace Domain.Interface;

    public interface IUser :IGenericRepository<User>
    {
        
    Task<User> GetByUsernameAsync(string username);
    Task<User> GetByRefreshTokenAsync(string username);
    }
