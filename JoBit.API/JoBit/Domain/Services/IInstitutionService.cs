using JoBit.API.JoBit.Domain.Models;
using JoBit.API.JoBit.Domain.Services.Communication;

namespace JoBit.API.JoBit.Domain.Services;

public interface IInstitutionService
{
    public Task<IEnumerable<Institution>> ListAllAsync();
    public Task<IEnumerable<Institution>> ListByContainingInstitutionName(string institutionName);
    public Task<EducationalInstitutionResponse> FindByInstitutionIdAsync(int institutionId);
}