using JoBit.API.Security.Domain.Models;

namespace JoBit.API.Security.Domain.Services;

public interface IApplicantService
{
    public Task<Applicant> FindByApplicantIdAsync(long userId);
    public Task AddAsync(Applicant newApplicant);
}