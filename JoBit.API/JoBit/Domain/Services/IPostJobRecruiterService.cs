using JoBit.API.JoBit.Domain.Models.Composite;
using JoBit.API.JoBit.Domain.Services.Communication;
using JoBit.API.Security.Domain.Models.Intermediate;

namespace JoBit.API.JoBit.Domain.Services;

public interface IPostJobRecruiterService
{
    Task<IEnumerable<PostJobRecruiter>> ListAllAsync();
    Task<PostJobRecruiterResponse> FindByPostJobIdAndRecruiterId(PostJobRecruiterPk postJobRecruiterPk);
    Task<PostJobRecruiterResponse> AddAsync(PostJobRecruiter newPostJobRecruiter);
    Task<PostJobRecruiterResponse> Update(PostJobRecruiterPk postJobRecruiterPk, PostJobRecruiter updatedPostJobRecruiter);
    Task<PostJobRecruiterResponse> RemoveAsync(PostJobRecruiterPk postJobRecruiterPk);
}