using JoBit.API.JoBit.Domain.Models;
using JoBit.API.JoBit.Domain.Services.Communication;

namespace JoBit.API.JoBit.Domain.Services;

public interface IApplicantProfileService
{
    Task<IEnumerable<ApplicantProfile>> ListAllAsync();
    Task<ApplicantProfileResponse> FindByApplicantId(long applicantId);
    Task<ApplicantProfileResponse> AddAsync(ApplicantProfile applicantProfile);
    Task<ApplicantProfileResponse> UpdateAsync(long applicantId, ApplicantProfile updatedApplicantProfile);
    Task<ApplicantProfileResponse> RemoveAsync(long applicantId);
}