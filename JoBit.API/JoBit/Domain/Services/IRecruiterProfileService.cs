using JoBit.API.JoBit.Domain.Models;
using JoBit.API.JoBit.Domain.Services.Communication;

namespace JoBit.API.JoBit.Domain.Services;

public interface IRecruiterProfileService
{
    Task<IEnumerable<RecruiterProfile>> ListAllAsync();
    Task<RecruiterProfileResponse> FindByRecruiterId(long recruiterId);
    Task<RecruiterProfileResponse> AddAsync(RecruiterProfile recruiterProfile);
    Task<RecruiterProfileResponse> UpdateAsync(long recruiterId, RecruiterProfile updatedRecruiterProfile);
    Task<RecruiterProfileResponse> RemoveAsync(long recruiterId);
}