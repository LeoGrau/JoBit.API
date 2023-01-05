namespace JoBit.API.JoBit.Resources.Update;

public class UpdateApplicantTechSkillResource
{
    public long ApplicantId { get; set; }
    public short TechSkillId { get; set; }
    public DateTime StartDate { get; set; }
}

public class UpdateApplicantTechSkillWithoutApplicantIdResource
{
    public short TechSkillId { get; set; }
    public DateTime StartDate { get; set; }
}

