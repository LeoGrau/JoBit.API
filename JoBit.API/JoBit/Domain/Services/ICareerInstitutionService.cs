
using JoBit.API.JoBit.Domain.Models.Intermediate;
using JoBit.API.JoBit.Domain.Services.Communication;

namespace JoBit.API.JoBit.Domain.Services;

public interface ICareerInstitutionService
{
    Task<IEnumerable<CareerInstitution>> ListAllAsync();
    Task<IEnumerable<CareerInstitution>> ListByApplicantIdAsync(long applicantId);
    Task<CareerInstitutionResponse> FindByCareerInstitutionIdAsync(long careerInstitutionId);
    Task<CareerInstitutionResponse> AddAsync(CareerInstitution newCareerInstitution);
    Task<CareerInstitutionResponse> Update(long careerInstitutionId, CareerInstitution updatedCareerInstitution);
    Task<CareerInstitutionResponse> RemoveAsync(long careerInstitutionId);
}