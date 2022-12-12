using JoBit.API.JoBit.Domain.Models;

namespace JoBit.API.JoBit.Domain.Repositories;

public interface IRecruiterProfileRepository
{
    Task<IEnumerable<RecruiterProfile>> ListAllAsync();
    Task<RecruiterProfile> FindByRecruiterIdAsync(long recruiterId);
    Task AddAsync(RecruiterProfile newRecruiterProfile);
    void Update(RecruiterProfile updatedRecruiterProfile);
    void Remove(RecruiterProfile toDeleteRecruiterProfile);
}