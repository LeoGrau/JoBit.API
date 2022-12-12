using JoBit.API.Security.Domain.Models;

namespace JoBit.API.Security.Domain.Services;

public interface IRecruiterService
{
    public Task<Recruiter> FindByApplicantIdAsync(long userId);
    public Task AddAsync(Recruiter newApplicant);
}