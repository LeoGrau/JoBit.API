using JoBit.API.Security.Domain.Models;
using JoBit.API.Security.Domain.Services;

namespace JoBit.API.Security.Services;

public class RecruiterService : IRecruiterService
{
    public Task<Recruiter> FindByApplicantIdAsync(long userId)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Recruiter newApplicant)
    {
        throw new NotImplementedException();
    }
}