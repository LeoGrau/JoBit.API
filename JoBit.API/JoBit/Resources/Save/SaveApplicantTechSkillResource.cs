namespace JoBit.API.JoBit.Resources.Save;

public class SaveApplicantTechSkillResource
{
    public long ApplicantId { get; set; }
    public short TechSkillId { get; set; }
    public DateTime StartDate { get; set; }
}

public class SaveApplicantTechSkillWithoutApplicantIdResource
{
    public short TechSkillId { get; set; }
    public DateTime StartDate { get; set; }
}
