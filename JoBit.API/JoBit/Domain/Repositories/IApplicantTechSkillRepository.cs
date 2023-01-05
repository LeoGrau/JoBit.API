using JoBit.API.JoBit.Domain.Models;

namespace JoBit.API.JoBit.Domain.Repositories;

public interface IApplicantTechSkillRepository
{
    Task<IEnumerable<ApplicantTechSkill>?> ListByApplicantIdAsync(long applicantId);
    Task<ApplicantTechSkill?> FindByApplicantIdAndTechSkillId(long applicantId, short techSkillId);
    Task AddAsync(ApplicantTechSkill newApplicantTechSkill);
    void Update(ApplicantTechSkill updatedApplicantTechSkill);
    void Remove(ApplicantTechSkill toDeleteApplicantTechSkill);
}