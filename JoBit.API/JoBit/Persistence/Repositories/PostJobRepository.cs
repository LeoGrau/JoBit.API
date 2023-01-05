using JoBit.API.JoBit.Domain.Models;
using JoBit.API.JoBit.Domain.Repositories;
using JoBit.API.Shared.Persistence.Context;
using JoBit.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JoBit.API.JoBit.Persistence.Repositories;

public class PostJobRepository : BaseRepository, IPostJobRepository
{
    public PostJobRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }

    public async Task<IEnumerable<PostJob>> ListAllAsync()
    {
        return await AppDbContext.PostJobs.ToListAsync();
    }

    public async Task<IEnumerable<PostJob>> ListAllByContainingJobName(string jobName)
    {
        return await AppDbContext.PostJobs.Where(postJob => postJob.JobName!.Contains(jobName)).ToListAsync();
    }

    public async Task<PostJob> FindByPostJobIdAsync(long postJobId)
    { 
        return await AppDbContext.PostJobs.FindAsync(postJobId);
    }

    public async Task AddAsync(PostJob newPostJob)
    {
        await AppDbContext.PostJobs.FindAsync(newPostJob);
    }

    public void Remove(PostJob toDeletePostJob)
    {
        AppDbContext.PostJobs.Remove(toDeletePostJob);
    }

    public void Update(PostJob updatedPostJob)
    {
        AppDbContext.PostJobs.Update(updatedPostJob);
    }
}