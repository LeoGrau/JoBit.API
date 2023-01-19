using JoBit.API.JoBit.Domain.Models;
using JoBit.API.JoBit.Domain.Repositories;
using JoBit.API.Shared.Persistence.Context;
using JoBit.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JoBit.API.JoBit.Persistence.Repositories;

public class EducationalInstitutionRepository : BaseRepository, IEducationalInstitutionRepository
{
    public EducationalInstitutionRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }

    public async  Task<IEnumerable<Institution>> ListAllAsync()
    { 
        return await AppDbContext.EducationalInstitutions.ToListAsync();
    }

    public async Task<IEnumerable<Institution>> ListByContainingInstitutionName(string institutionName)
    {
        return await AppDbContext.EducationalInstitutions
            .Where(institution => institution.InstitutionName == institutionName).ToListAsync();
    }

    public async Task<Institution> FindByInstitutionIdAsync(int institutionId)
    {
        return await AppDbContext.EducationalInstitutions.FindAsync(institutionId);
    }
}