using JoBit.API.JoBit.Domain.Models;
using JoBit.API.JoBit.Domain.Repositories;
using JoBit.API.JoBit.Domain.Services.Communication;

namespace JoBit.API.JoBit.Domain.Services;

public interface ICareerService
{
    public Task<IEnumerable<Career>> ListAllAsync();
    public Task<IEnumerable<Career>> ListByContainingCareerName(string careerName);
    public Task<CareerResponse> FindByCareerIdAsync(int careerId);
}