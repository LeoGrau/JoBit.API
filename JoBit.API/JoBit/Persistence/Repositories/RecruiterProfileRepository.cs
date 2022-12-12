using JoBit.API.JoBit.Domain.Models;
using JoBit.API.JoBit.Domain.Repositories;
using JoBit.API.Shared.Persistence.Context;
using JoBit.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;


namespace JoBit.API.JoBit.Persistence.Repositories;

public class RecruiterProfileRepository : BaseRepository, IRecruiterProfileRepository
{
    public RecruiterProfileRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }

    public async Task<IEnumerable<RecruiterProfile>> ListAllAsync()
    {
        return await AppDbContext.RecruiterProfiles.ToListAsync();
    }

    public async Task<RecruiterProfile> FindByRecruiterIdAsync(long recruiterId)
    {
        return await AppDbContext.RecruiterProfiles.FindAsync(recruiterId);
    }

    public async Task AddAsync(RecruiterProfile newRecruiterProfile)
    {
        throw new NotImplementedException();
    }

    public void Update(RecruiterProfile updatedRecruiterProfile)
    {
        throw new NotImplementedException();
    }

    public void Remove(RecruiterProfile toDeleteRecruiterProfile)
    {
        throw new NotImplementedException();
    }
}