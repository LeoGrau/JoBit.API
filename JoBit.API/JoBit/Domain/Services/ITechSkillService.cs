using JoBit.API.JoBit.Domain.Models;
using JoBit.API.JoBit.Domain.Services.Communication;

namespace JoBit.API.JoBit.Domain.Services;

public interface ITechSkillService
{
    Task<IEnumerable<TechSkill>> ListAllAsync();
    Task<TechSkillResponse> FindByTechSkillId(short techSkillId);
    Task<TechSkillResponse> FindByTechName(String techName);
    Task<IEnumerable<TechSkill>> ListByContainingWord(String word);

}