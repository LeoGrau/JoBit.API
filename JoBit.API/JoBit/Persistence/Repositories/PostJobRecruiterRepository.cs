using JoBit.API.JoBit.Domain.Models.Composite;
using JoBit.API.JoBit.Domain.Models.Intermediate;
using JoBit.API.JoBit.Domain.Repositories;
using JoBit.API.Security.Domain.Models.Intermediate;
using JoBit.API.Shared.Persistence.Context;
using JoBit.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JoBit.API.JoBit.Persistence.Repositories;

public class PostJobRecruiterRepository : BaseRepository, IPostJobRecruiterRepository
{
    public PostJobRecruiterRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }

    public async Task<IEnumerable<PostJobRecruiter>> ListAllAsync()
    {
        return await AppDbContext.PostJobRecruiters.ToListAsync();
    }

    public async Task<IEnumerable<PostJobRecruiter>> ListAllByPostJobIdAsync(long postId)
    {
        return await AppDbContext.PostJobRecruiters.Where(postJobRecruiter => postJobRecruiter.PostId == postId).ToListAsync();
    }

    public async Task<PostJobRecruiter> FindByPostJobIdAndRecruiterIdAsync(PostJobRecruiterPk postJobRecruiterPk)
    {
        return await AppDbContext.PostJobRecruiters.FindAsync(postJobRecruiterPk.PostId, postJobRecruiterPk.RecruiterId);
    }

    public async Task AddAsync(PostJobRecruiter newPostJobRecruiter)
    {
        await AppDbContext.AddAsync(newPostJobRecruiter);
    }

    public void Update(PostJobRecruiter updatedPostJobRecruiter)
    {
        AppDbContext.Update(updatedPostJobRecruiter);
    }

    public void Remove(PostJobRecruiter toDeletePostJobRecruiter)
    {
        AppDbContext.Remove(toDeletePostJobRecruiter);
    }
}