using JoBit.API.JoBit.Domain.Models;
using JoBit.API.JoBit.Domain.Repositories;
using JoBit.API.Shared.Persistence.Context;
using JoBit.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JoBit.API.JoBit.Persistence.Repositories;

public class CareerRepository : BaseRepository, ICareerRepository
{
    public CareerRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }

    public async Task<IEnumerable<Career>> ListAllAsync()
    {
        return await AppDbContext.Careers.ToListAsync();
    }

    public async Task<Career> FindByCareerIdAsync(int careerId)
    {
        return await AppDbContext.Careers.FindAsync(careerId);
    }

    public async Task<IEnumerable<Career>> ListByContainingCareerName(string careerName)
    {
        return await AppDbContext.Careers.Where(career => career.CareerName == careerName).ToListAsync();
    }
}