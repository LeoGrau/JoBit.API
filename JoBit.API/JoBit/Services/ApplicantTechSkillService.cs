using JoBit.API.JoBit.Domain.Models;
using JoBit.API.JoBit.Domain.Repositories;
using JoBit.API.JoBit.Domain.Services;
using JoBit.API.JoBit.Domain.Services.Communication;
using JoBit.API.Security.Domain.Repositories;
using JoBit.API.Shared.Domain.Repositories;

namespace JoBit.API.JoBit.Services;

public class ApplicantTechSkillService : IApplicantTechSkillService
{
    private readonly IApplicantTechSkillRepository _applicantTechSkillRepository;
    private readonly IApplicantRepository _applicantRepository;
    private readonly ITechSkillRepository _techSkillRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ApplicantTechSkillService(IApplicantTechSkillRepository applicantTechSkillRepository, IUnitOfWork unitOfWork, IApplicantRepository applicantRepository, ITechSkillRepository techSkillRepository)
    {
        _applicantTechSkillRepository = applicantTechSkillRepository;
        _applicantRepository = applicantRepository;
        _techSkillRepository = techSkillRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<ApplicantTechSkill>?> ListByApplicantIdAsync(long applicantId)
    {
        var existingApplicant = await _applicantRepository.FindByApplicantIdAsync(applicantId);
        if (existingApplicant == null)
            return null;

        var applicantTechSkills = await _applicantTechSkillRepository.ListByApplicantIdAsync(applicantId);
        
        applicantTechSkills!.ToList().ForEach(applicantTechSkill =>
        {
            applicantTechSkill.TechSkill = _techSkillRepository.FindByTechSkillIdAsync(applicantTechSkill.TechSkillId).Result;
        });
        
        return await _applicantTechSkillRepository.ListByApplicantIdAsync(applicantId);
    }

    public async Task<ApplicantTechSkillResponse> FindByApplicantIdAndTechSkillIdAsync(long applicantId, short techSkillId)
    {
        var existingApplicantTechSkill = await _applicantTechSkillRepository.FindByApplicantIdAndTechSkillId(applicantId, techSkillId);
        if (existingApplicantTechSkill == null)
            return new ApplicantTechSkillResponse("Applicant Tech Skill does not exist.");
        
        existingApplicantTechSkill.TechSkill = await _techSkillRepository.FindByTechSkillIdAsync(existingApplicantTechSkill.TechSkillId);
        return new ApplicantTechSkillResponse(existingApplicantTechSkill);
    }

    public async Task<ApplicantTechSkillResponse> AddAsync(ApplicantTechSkill newApplicantTechSkill)
    {
        var existingApplicant = await _applicantRepository.FindByApplicantIdAsync(newApplicantTechSkill.ApplicantId);
        var existingTechSkill = await _techSkillRepository.FindByTechSkillIdAsync(newApplicantTechSkill.TechSkillId);

        if (existingApplicant == null || existingTechSkill == null)
            return new ApplicantTechSkillResponse("Applicant or TechSkill does not exist.");

        try
        {
           await _applicantTechSkillRepository.AddAsync(newApplicantTechSkill);
           await _unitOfWork.CompleteAsync();
           return new ApplicantTechSkillResponse(newApplicantTechSkill);
        }
        catch (Exception exception)
        {
            return new ApplicantTechSkillResponse($"{exception.Message}");
        }
    }

    public async Task<ApplicantTechSkillResponse> UpdateAsync(long applicantId, short techSkillId, ApplicantTechSkill updatedApplicantTechSkill)
    {
        var existingApplicantTechSkill =
            await _applicantTechSkillRepository.FindByApplicantIdAndTechSkillId(applicantId, techSkillId);
        if (existingApplicantTechSkill == null)
            return new ApplicantTechSkillResponse("Applicant Tech Skill does not exist.");

        existingApplicantTechSkill.SetApplicantTechSkillFromApplicant(updatedApplicantTechSkill);
        
        try
        {
            _applicantTechSkillRepository.Update(existingApplicantTechSkill);
            await _unitOfWork.CompleteAsync();
            return new ApplicantTechSkillResponse(existingApplicantTechSkill);
        }
        catch (Exception exception)
        {
            return new ApplicantTechSkillResponse($"{exception.Message}");
        }
    }

    public async Task<ApplicantTechSkillResponse> RemoveAsync(long applicantId, short techSkillId)
    {
        var existingApplicantTechSkill =
            await _applicantTechSkillRepository.FindByApplicantIdAndTechSkillId(applicantId, techSkillId);
        if (existingApplicantTechSkill == null)
            return new ApplicantTechSkillResponse("Applicant Tech Skill does not exist.");
        try
        {
            _applicantTechSkillRepository.Remove(existingApplicantTechSkill);
            await _unitOfWork.CompleteAsync();
            return new ApplicantTechSkillResponse(existingApplicantTechSkill);
        }
        catch (Exception exception)
        {
            return new ApplicantTechSkillResponse($"{exception}");
        }
    }
}