using JoBit.API.Security.Domain.Models;
using JoBit.API.Security.Domain.Repositories;
using JoBit.API.Security.Domain.Services.Communication.Requests;
using JoBit.API.Shared.Persistence.Context;
using JoBit.API.Shared.Persistence.Repositories;

namespace JoBit.API.Security.Repositories;

public class UserRepository : BaseRepository, IUserRepository
{
    public UserRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
    
    public async Task<User> FindUserByIdAsync(long userId)
    {
        return await AppDbContext.Users.FindAsync(userId);
    }

    public async Task RegisterUserAsync(User newUser)
    {
        await AppDbContext.Users.AddAsync(newUser);
    }
}