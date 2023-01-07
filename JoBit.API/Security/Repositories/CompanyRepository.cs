using JoBit.API.Security.Domain.Models;
using JoBit.API.Security.Domain.Repositories;
using JoBit.API.Shared.Persistence.Context;
using JoBit.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JoBit.API.Security.Repositories;

public class CompanyRepository : BaseRepository, ICompanyRepository
{
    public CompanyRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }

    public async Task<IEnumerable<Company>> ListAllAsync()
    {
        return await AppDbContext.Companies.ToListAsync();
    }

    public async Task<Company> FindByCompanyIdAsync(long applicantId)
    {
        return await AppDbContext.Companies.FindAsync(applicantId);
    }

    public async Task AddAsync(Company newApplicant)
    {
        await AppDbContext.Companies.AddAsync(newApplicant);
    }

    public void Update(Company updatedApplicant)
    {
        AppDbContext.Companies.Update(updatedApplicant);
    }

    public void Remove(Company toDeleteApplicant)
    {
        AppDbContext.Companies.Remove(toDeleteApplicant);
    }
}