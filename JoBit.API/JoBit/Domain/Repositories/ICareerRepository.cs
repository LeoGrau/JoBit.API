using JoBit.API.JoBit.Domain.Models;

namespace JoBit.API.JoBit.Domain.Repositories;

public interface ICareerRepository
{
    public Task<IEnumerable<Career>> ListAllAsync();
    public Task<Career> FindByCareerIdAsync(int careerId);
    public Task<IEnumerable<Career>> ListByContainingCareerName(string careerName);
}