using JoBit.API.JoBit.Domain.Models;
using JoBit.API.JoBit.Domain.Repositories;
using JoBit.API.Shared.Persistence.Context;
using JoBit.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JoBit.API.JoBit.Persistence.Repositories;

public class ApplicantProfileRepository : BaseRepository, IApplicantProfileRepository
{
    public ApplicantProfileRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
    
    public async Task<IEnumerable<ApplicantProfile>> ListAllAsync()
    {
        return await AppDbContext.ApplicantProfiles.ToListAsync();
    }

    public async Task<ApplicantProfile> FindByApplicantIdAsync(long applicantId)
    {
        return await AppDbContext.ApplicantProfiles.FindAsync(applicantId);
    }

    public async Task AddAsync(ApplicantProfile newApplicantProfile)
    {
        await AppDbContext.ApplicantProfiles.AddAsync(newApplicantProfile);
    }

    public void Update(ApplicantProfile updatedApplicantProfile)
    {
        AppDbContext.ApplicantProfiles.Update(updatedApplicantProfile);
    }

    public void Remove(ApplicantProfile toDeleteApplicantProfile)
    {
        AppDbContext.ApplicantProfiles.Remove(toDeleteApplicantProfile);
    }

}