using JoBit.API.JoBit.Domain.Models;
using JoBit.API.JoBit.Domain.Repositories;
using JoBit.API.Shared.Persistence.Context;
using JoBit.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JoBit.API.JoBit.Persistence.Repositories;

public class TechSkillRepository : BaseRepository, ITechSkillRepository
{
    public TechSkillRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }

    public async Task<IEnumerable<TechSkill>> ListAllAsync()
    {
        return await AppDbContext.TechSkills.ToListAsync();
    }

    public async Task<TechSkill> FindByTechSkillIdAsync(short techSkillId)
    {
        return await AppDbContext.TechSkills.FindAsync(techSkillId);
    }

    public async Task<TechSkill> FindByTechNameAsync(String techName)
    {
        return await AppDbContext.TechSkills.FirstOrDefaultAsync(techSkill => techSkill.TechName == techName);
    }

    public async Task<IEnumerable<TechSkill>> ListByContainingTechSkillName(string word)
    {
        return await AppDbContext.TechSkills.Where(techSkill => techSkill.TechName.Contains($"{word}")).ToListAsync();
    }
}