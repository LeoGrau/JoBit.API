using JoBit.API.JoBit.Domain.Models;
using JoBit.API.JoBit.Domain.Services.Communication;

namespace JoBit.API.JoBit.Domain.Services;

public interface IPostJobService
{
    public Task<IEnumerable<PostJob>> ListAllAsync();
    public Task<IEnumerable<PostJob>> ListAllByContainingJobName(String jobName);
    public Task<PostJobResponse> FindByPostJobIdAsync(long postJobId);
    public Task<PostJobResponse> AddAsync(PostJob newPostJob);
    public Task<PostJobResponse> RemoveAsync(long postJobId);
    public Task<PostJobResponse> UpdateAsync(long postJobId, PostJob updatedPostJob);
}