namespace JoBit.API.JoBit.Domain.Models;

public class TechSkill
{
    public short TechSkillId { get; set; }
    public String? TechName { get; set; }
    public String? PhotoUrl { get; set; }
    
    //Relations (We send)
    //-ApplicantProfileTechSkill
    public IList<ApplicantTechSkill>? ApplicantTechSkills { get; set; }
}