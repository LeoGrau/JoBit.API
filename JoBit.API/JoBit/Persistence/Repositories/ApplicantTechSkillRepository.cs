using JoBit.API.JoBit.Domain.Models;
using JoBit.API.JoBit.Domain.Repositories;
using JoBit.API.Shared.Persistence.Context;
using JoBit.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace JoBit.API.JoBit.Persistence.Repositories;

public class ApplicantTechSkillRepository : BaseRepository, IApplicantTechSkillRepository
{
    public ApplicantTechSkillRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }


    public async Task<IEnumerable<ApplicantTechSkill>?> ListByApplicantIdAsync(long applicantId)
    {
        return await AppDbContext.ApplicantTechSkills.Where(applicantTechSkill => applicantTechSkill.ApplicantId == applicantId).ToListAsync()!;
    }

    public async Task<ApplicantTechSkill?> FindByApplicantIdAndTechSkillId(long applicantId, short techSkillId)
    {
        return await AppDbContext.ApplicantTechSkills.FirstOrDefaultAsync(applicantTechSkill => applicantTechSkill.ApplicantId == applicantId && applicantTechSkill.TechSkillId == techSkillId);
    }

    public async Task AddAsync(ApplicantTechSkill newApplicantTechSkill)
    {
        await AppDbContext.ApplicantTechSkills.AddAsync(newApplicantTechSkill);
    }

    public void Update(ApplicantTechSkill updatedApplicantTechSkill)
    {
        // AppDbContext.ApplicantTechSkills.Attach(updatedApplicantTechSkill);
        // updatedApplicantTechSkill.TechSkillId = 3;
        AppDbContext.ApplicantTechSkills.Update(updatedApplicantTechSkill);
    }
    
    public void Remove(ApplicantTechSkill toDeleteApplicantTechSkill)
    {
        AppDbContext.ApplicantTechSkills.Remove(toDeleteApplicantTechSkill);
    }
}