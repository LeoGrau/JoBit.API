using JoBit.API.Security.Domain.Models;
using JoBit.API.Security.Domain.Repositories;
using JoBit.API.Shared.Persistence.Context;
using JoBit.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JoBit.API.Security.Repositories;

public class RecruiterRepository : BaseRepository, IRecruiterRepository
{
    public RecruiterRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }

    public async Task<IEnumerable<Recruiter>> ListAllAsync()
    {
        return await AppDbContext.Recruiters.ToListAsync();
    }

    public async Task<Recruiter> FindByApplicantIdAsync(long recruiterId)
    {
        return await AppDbContext.Recruiters.FindAsync(recruiterId);
    }

    public async Task AddAsync(Recruiter newRecruiter)
    {
        await AppDbContext.Recruiters.AddAsync(newRecruiter);
    }

    public void Update(Recruiter updatedRecruiter)
    {
        throw new NotImplementedException();
    }

    public void Remove(Recruiter toDeleteRecruiter)
    {
        throw new NotImplementedException();
    }
}