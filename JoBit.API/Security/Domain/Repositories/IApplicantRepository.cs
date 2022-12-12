using JoBit.API.Security.Domain.Models;

namespace JoBit.API.Security.Domain.Repositories;

public interface IApplicantRepository
{
    Task<IEnumerable<Applicant>> ListAllAsync();
    Task<Applicant> FindByApplicantIdAsync(long applicantId);
    Task AddAsync(Applicant newApplicant);
    void Update(Applicant updatedApplicant);
    void Remove(Applicant toDeleteApplicant);

}