using JoBit.API.JoBit.Domain.Models;
using JoBit.API.JoBit.Domain.Services.Communication;

namespace JoBit.API.JoBit.Domain.Services;

public interface IApplicantTechSkillService
{
    
    Task<IEnumerable<ApplicantTechSkill>?> ListByApplicantIdAsync(long applicantId);
    Task<ApplicantTechSkillResponse> FindByApplicantIdAndTechSkillIdAsync(long applicantId, short techSkillId);
    Task<ApplicantTechSkillResponse> AddAsync(ApplicantTechSkill applicantTechSkill);
    Task<ApplicantTechSkillResponse> UpdateAsync(long applicantId, short techSkillId, ApplicantTechSkill updatedApplicantTechSkill);
    Task<ApplicantTechSkillResponse> RemoveAsync(long applicantId, short techSkillId);
}