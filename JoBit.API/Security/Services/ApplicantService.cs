using JoBit.API.Security.Domain.Models;
using JoBit.API.Security.Domain.Services;

namespace JoBit.API.Security.Services;

public class ApplicantService : IApplicantService
{
    public Task<Applicant> FindByApplicantIdAsync(long userId)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Applicant newApplicant)
    {
        throw new NotImplementedException();
    }
}