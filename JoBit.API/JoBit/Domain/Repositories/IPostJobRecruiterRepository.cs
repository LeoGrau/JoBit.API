using JoBit.API.JoBit.Domain.Models.Composite;
using JoBit.API.JoBit.Domain.Models.Intermediate;
using JoBit.API.Security.Domain.Models.Intermediate;

namespace JoBit.API.JoBit.Domain.Repositories;

public interface IPostJobRecruiterRepository
{
    Task<IEnumerable<PostJobRecruiter>> ListAllAsync();
    Task<IEnumerable<PostJobRecruiter>> ListAllByPostJobIdAsync(long postId);
    Task<PostJobRecruiter> FindByPostJobIdAndRecruiterIdAsync(PostJobRecruiterPk postJobRecruiterPk);
    Task AddAsync(PostJobRecruiter newPostJobRecruiter);
    void Update(PostJobRecruiter updatedPostJobRecruiter);
    void Remove(PostJobRecruiter toDeletePostJobRecruiter);
}