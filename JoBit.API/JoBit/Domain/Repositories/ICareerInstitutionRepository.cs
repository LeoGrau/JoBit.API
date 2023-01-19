using JoBit.API.JoBit.Domain.Models.Intermediate;

namespace JoBit.API.JoBit.Domain.Repositories;

public interface ICareerInstitutionRepository
{
    Task<IEnumerable<CareerInstitution>> ListAllAsync();
    Task<IEnumerable<CareerInstitution>> ListByApplicantIdAsync(long applicantId);
    Task<CareerInstitution> FindByCareerInstitutionIdAsync(long careerInstitutionId);
    Task AddAsync(CareerInstitution newCareerInstitution);
    void Update(CareerInstitution updatedCareerInstitution);
    void Remove(CareerInstitution toDeleteCareerInstitution);
}