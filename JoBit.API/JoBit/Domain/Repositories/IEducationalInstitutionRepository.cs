using JoBit.API.JoBit.Domain.Models;

namespace JoBit.API.JoBit.Domain.Repositories;

public interface IEducationalInstitutionRepository
{
    public Task<IEnumerable<Institution>> ListAllAsync();
    public Task<IEnumerable<Institution>> ListByContainingInstitutionName(string institutionName);
    public Task<Institution> FindByInstitutionIdAsync(int institutionId);
}