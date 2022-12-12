using JoBit.API.JoBit.Domain.Models;

namespace JoBit.API.JoBit.Domain.Repositories;

public interface IApplicantProfileRepository
{
    Task<IEnumerable<ApplicantProfile>> ListAllAsync();
    Task<ApplicantProfile> FindByApplicantIdAsync(long applicantId);
    Task AddAsync(ApplicantProfile newApplicantProfile);
    void Update(ApplicantProfile updatedApplicantProfile);
    void Remove(ApplicantProfile toDeleteApplicantProfile);
}