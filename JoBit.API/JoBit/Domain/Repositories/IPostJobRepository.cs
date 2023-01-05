using JoBit.API.JoBit.Domain.Models;

namespace JoBit.API.JoBit.Domain.Repositories;

public interface IPostJobRepository
{
    public Task<IEnumerable<PostJob>> ListAllAsync();
    public Task<IEnumerable<PostJob>> ListAllByContainingJobName(String jobName);
    public Task<PostJob> FindByPostJobIdAsync(long postJobId);
    public Task AddAsync(PostJob newPostJob);
    public void Remove(PostJob toDeletePostJob);
    public void Update(PostJob updatedPostJob);
    
}