using JoBit.API.Security.Domain.Models;
using JoBit.API.Security.Domain.Repositories;
using JoBit.API.Shared.Persistence.Context;
using JoBit.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JoBit.API.Security.Repositories;

public class ApplicantRepository : BaseRepository, IApplicantRepository
{
    public ApplicantRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }

    public async Task<IEnumerable<Applicant>> ListAllAsync()
    {
        return await AppDbContext.Applicants.ToListAsync();
    }

    public async Task<Applicant> FindByApplicantIdAsync(long applicantId)
    {
        return await AppDbContext.Applicants.FindAsync(applicantId);
    }

    public async Task AddAsync(Applicant newApplicant)
    {
        await AppDbContext.Applicants.AddAsync(newApplicant);
    }

    public void Update(Applicant updatedApplicant)
    {
        throw new NotImplementedException();
    }

    public void Remove(Applicant toDeleteApplicant)
    {
        throw new NotImplementedException();
    }
}