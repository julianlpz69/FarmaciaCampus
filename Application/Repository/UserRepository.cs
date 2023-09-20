
using Domain.Entities;
using Domain.Interface;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;
namespace Application.Repository;
public class UserRepository : GenericRepository<User>, IUser
{
    private readonly FarmaciaDBContext _context;

    public UserRepository(FarmaciaDBContext context) : base(context)
    {
        _context = context;
    }

    public async Task<User> GetByRefreshTokenAsync(string refreshToken)
    {
        return await _context.Users
            .Include(u => u.Rols)
            .Include(u => u.RefreshTokens)
            .FirstOrDefaultAsync(u => u.RefreshTokens.Any(t => t.Token == refreshToken));
    }

    public async Task<User> GetByUsernameAsync(string username)
    {
        return await _context.Users
            .Include(u => u.Rols)
            .Include(u => u.RefreshTokens)
            .FirstOrDefaultAsync(u => u.UserName.ToLower() == username.ToLower());
    }
}