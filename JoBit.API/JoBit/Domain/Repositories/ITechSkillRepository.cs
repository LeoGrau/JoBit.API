using JoBit.API.JoBit.Domain.Models;

namespace JoBit.API.JoBit.Domain.Repositories;

public interface ITechSkillRepository
{
    Task<IEnumerable<TechSkill>> ListAllAsync();
    Task<TechSkill> FindByTechSkillIdAsync(short techSkillId);
    Task<TechSkill> FindByTechNameAsync(String techName);
    Task<IEnumerable<TechSkill>> ListByContainingTechSkillName(String word);
}
