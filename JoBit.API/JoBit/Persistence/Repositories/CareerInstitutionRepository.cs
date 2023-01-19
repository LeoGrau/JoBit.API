using JoBit.API.JoBit.Domain.Models.Intermediate;
using JoBit.API.JoBit.Domain.Repositories;
using JoBit.API.Shared.Persistence.Context;
using JoBit.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JoBit.API.JoBit.Persistence.Repositories;

public class CareerInstitutionRepository : BaseRepository, ICareerInstitutionRepository
{
    public CareerInstitutionRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }

    public async Task<IEnumerable<CareerInstitution>> ListAllAsync()
    {
        return await AppDbContext.CareerInstitutions.ToListAsync();
    }

    public async Task<IEnumerable<CareerInstitution>> ListByApplicantIdAsync(long applicantId)
    {
        return await AppDbContext.CareerInstitutions
            .Where(careerInstitution => careerInstitution.ApplicantId == applicantId).ToListAsync();
    }

    public async Task<CareerInstitution> FindByCareerInstitutionIdAsync(long careerInstitutionId)
    {
        return await AppDbContext.CareerInstitutions.FindAsync(careerInstitutionId);
    }

    public async Task AddAsync(CareerInstitution newCareerInstitution)
    {
        await AppDbContext.CareerInstitutions.AddAsync(newCareerInstitution);
    }

    public void Update(CareerInstitution updatedCareerInstitution)
    {
        AppDbContext.CareerInstitutions.Update(updatedCareerInstitution);
    }

    public void Remove(CareerInstitution toDeleteCareerInstitution)
    {
        AppDbContext.CareerInstitutions.Remove(toDeleteCareerInstitution);
    }
}