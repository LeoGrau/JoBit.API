namespace JoBit.API.JoBit.Domain.Models;

//Well this are techs-kills from each applicant profile 
public class ApplicantTechSkill
{
    public DateTime StartDate { get; set; }
    public long ApplicantTechSkillId { get; set; }

    //Relations (Others Send)
    //-ApplicantId
    public long ApplicantId { get; set; }
    public ApplicantProfile ApplicantProfile { get; set; }
    //-TechSkillId
    public short TechSkillId { get; set; }
    public TechSkill TechSkill { get; set; }

    
    //Constructors
    public ApplicantTechSkill()
    {
    }

    public ApplicantTechSkill(DateTime startDate, long applicantId, short techSkillId)
    {
        StartDate = startDate;
        ApplicantId = applicantId;
        TechSkillId = techSkillId;
    }
    
    //Methods
    public void SetApplicantTechSkill(ApplicantTechSkill updatedApplicantTechSkill)
    {
        ApplicantId = updatedApplicantTechSkill.ApplicantId;
        TechSkillId = updatedApplicantTechSkill.TechSkillId;
        StartDate = updatedApplicantTechSkill.StartDate;
    }
    
    public void SetApplicantTechSkillFromApplicant(ApplicantTechSkill updatedApplicantTechSkill)
    {
        TechSkillId = updatedApplicantTechSkill.TechSkillId;
        StartDate = updatedApplicantTechSkill.StartDate;
    }
}