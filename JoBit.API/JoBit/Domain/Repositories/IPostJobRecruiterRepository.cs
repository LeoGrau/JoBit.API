using JoBit.API.JoBit.Domain.Models.Composite;
using JoBit.API.Security.Domain.Models.Intermediate;

namespace JoBit.API.JoBit.Domain.Repositories;

public interface IPostJobRecruiterRepository
{
    Task<IEnumerable<PostJobRecruiter>> ListAllAsync();
    Task<PostJobRecruiter> FindByPostJobIdAndRecruiterId(PostJobRecruiterPk postJobRecruiterPk);
    Task AddAsync(PostJobRecruiter newPostJobRecruiter);
    void Update(PostJobRecruiter updatedPostJobRecruiter);
    void Remove(PostJobRecruiter toDeletePostJobRecruiter);
}