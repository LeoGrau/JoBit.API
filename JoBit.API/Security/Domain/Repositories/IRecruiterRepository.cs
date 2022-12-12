using JoBit.API.Security.Domain.Models;

namespace JoBit.API.Security.Domain.Repositories;

public interface IRecruiterRepository
{
    Task<IEnumerable<Recruiter>> ListAllAsync();
    Task<Recruiter> FindByApplicantIdAsync(long recruiterId);
    Task AddAsync(Recruiter newRecruiter);
    void Update(Recruiter updatedRecruiter);
    void Remove(Recruiter toDeleteRecruiter);
}