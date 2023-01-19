using JoBit.API.JoBit.Domain.Models;
using JoBit.API.JoBit.Domain.Repositories;
using JoBit.API.JoBit.Domain.Services;
using JoBit.API.JoBit.Domain.Services.Communication;
using JoBit.API.Shared.Domain.Repositories;

namespace JoBit.API.JoBit.Services;

public class ApplicantProfileService : IApplicantProfileService
{
    private readonly IApplicantProfileRepository _applicantProfileRepository;
    private readonly IApplicantTechSkillRepository _applicantTechSkillRepository;
    private readonly ITechSkillRepository _techSkillRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ApplicantProfileService(IApplicantProfileRepository applicantProfileRepository, IUnitOfWork unitOfWork, IApplicantTechSkillRepository applicantTechSkillRepository, ITechSkillRepository techSkillRepository)
    {
        _applicantProfileRepository = applicantProfileRepository;
        _unitOfWork = unitOfWork;
        _applicantTechSkillRepository = applicantTechSkillRepository;
        _techSkillRepository = techSkillRepository;
    }

    public async Task<IEnumerable<ApplicantProfile>> ListAllAsync()
    {
        var applicantProfiles = await _applicantProfileRepository.ListAllAsync();
        applicantProfiles.ToList().ForEach(
            applicantProfile =>
            {
                applicantProfile.ApplicantTechSkills = _applicantTechSkillRepository.ListByApplicantIdAsync(applicantProfile.ApplicantId).Result.ToList();
                applicantProfile.ApplicantTechSkills.ToList().ForEach(applicantTechSkill =>
                {
                    applicantTechSkill.TechSkill = _techSkillRepository.FindByTechSkillIdAsync(applicantTechSkill.TechSkillId).Result;
                });
            });
        return await _applicantProfileRepository.ListAllAsync();
    }

    public async Task<ApplicantProfileResponse> FindByApplicantId(long applicantId)
    {
        var existingApplicantProfile = await _applicantProfileRepository.FindByApplicantIdAsync(applicantId);
        if (existingApplicantProfile == null)
            return new ApplicantProfileResponse("Applicant does not exist");
        
        //Set inside objects
        existingApplicantProfile.ApplicantTechSkills = _applicantTechSkillRepository.ListByApplicantIdAsync(existingApplicantProfile.ApplicantId).Result.ToList();
        existingApplicantProfile.ApplicantTechSkills.ToList().ForEach(applicantTechSkill =>
        {
            applicantTechSkill.TechSkill = _techSkillRepository.FindByTechSkillIdAsync(applicantTechSkill.TechSkillId).Result;
        });
        
        return new ApplicantProfileResponse(existingApplicantProfile);
    }

    public Task<ApplicantProfileResponse> AddAsync(ApplicantProfile applicantProfile)
    {
        try
        {
            throw new NotImplementedException();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<ApplicantProfileResponse> UpdateAsync(long applicantId, ApplicantProfile updatedApplicantProfile)
    {
        var existingApplicantProfile = await _applicantProfileRepository.FindByApplicantIdAsync(applicantId);
        if (existingApplicantProfile == null)
            return new ApplicantProfileResponse("Applicant Profile does not exist.");

        existingApplicantProfile.SetApplicantProfile(updatedApplicantProfile);

        try
        {
            _applicantProfileRepository.Update(existingApplicantProfile);
            await _unitOfWork.CompleteAsync();
            return new ApplicantProfileResponse(existingApplicantProfile);
        }
        catch (Exception exception)
        {
            return new ApplicantProfileResponse($"{exception.Message}");
        }
    }

    public Task<ApplicantProfileResponse> RemoveAsync(long applicantId)
    {
        throw new NotImplementedException();
    }
}