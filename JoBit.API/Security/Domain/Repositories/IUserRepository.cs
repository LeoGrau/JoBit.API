using JoBit.API.Security.Domain.Models;

namespace JoBit.API.Security.Domain.Repositories;

public interface IUserRepository
{
    Task<User> FindUserByIdAsync(long userId);
    Task RegisterUserAsync(User newUser);
}