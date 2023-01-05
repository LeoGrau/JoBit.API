using JoBit.API.JoBit.Domain.Models;
using JoBit.API.JoBit.Domain.Repositories;
using JoBit.API.JoBit.Domain.Services;
using JoBit.API.JoBit.Domain.Services.Communication;
using JoBit.API.Shared.Domain.Repositories;

namespace JoBit.API.JoBit.Services;

public class TechSkillService : ITechSkillService
{
    private readonly ITechSkillRepository _techSkillRepository;
    private readonly IUnitOfWork _unitOfWork;

    public TechSkillService(ITechSkillRepository techSkillRepository, IUnitOfWork unitOfWork)
    {
        _techSkillRepository = techSkillRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<TechSkill>> ListAllAsync()
    {
        return await _techSkillRepository.ListAllAsync();
    }

    public async Task<TechSkillResponse> FindByTechSkillId(short techSkillId)
    {
        var existingTechSkill = await _techSkillRepository.FindByTechSkillIdAsync(techSkillId);
        if (existingTechSkill == null)
            return new TechSkillResponse("TechSkill does not exist.");
        return new TechSkillResponse(existingTechSkill);
    }

    public async Task<TechSkillResponse> FindByTechName(string techName)
    {
        var existingTechSkillWithName = await _techSkillRepository.FindByTechNameAsync(techName);
        if (existingTechSkillWithName == null)
            return new TechSkillResponse("TechSkill with that name does not exist");
        return new TechSkillResponse(existingTechSkillWithName);
    }

    public async Task<IEnumerable<TechSkill>> ListByContainingWord(string word)
    {
        return await _techSkillRepository.ListByContainingTechSkillName(word);
    }
}