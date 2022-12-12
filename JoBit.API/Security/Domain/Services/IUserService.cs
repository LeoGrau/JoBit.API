using JoBit.API.Security.Domain.Models;

namespace JoBit.API.Security.Domain.Services;

public interface IUserService
{
    public Task<User> FindUserAsync(long userId);
    public Task RegisterUserAsync(User registerRequest);
}