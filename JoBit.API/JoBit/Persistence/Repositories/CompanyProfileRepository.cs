using JoBit.API.JoBit.Domain.Models;
using JoBit.API.JoBit.Domain.Repositories;
using JoBit.API.Shared.Persistence.Context;
using JoBit.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JoBit.API.JoBit.Persistence.Repositories;

public class CompanyProfileRepository : BaseRepository, ICompanyProfileRepository
{
    public CompanyProfileRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }

    public async Task<IEnumerable<CompanyProfile>> ListAllAsync()
    {
        return await AppDbContext.CompanyProfiles.ToListAsync();
    }

    public async Task<CompanyProfile> FindByCompanyIdAsync(long companyId)
    {
        return await AppDbContext.CompanyProfiles.FindAsync(companyId);
    }

    public async Task AddAsync(CompanyProfile newCompanyProfile)
    {
        await AppDbContext.CompanyProfiles.AddAsync(newCompanyProfile);
    }
}