using JoBit.API.Security.Domain.Models;

namespace JoBit.API.JoBit.Domain.Models.Intermediate;

public class CareerInstitution
{
    public long CareerInstitutionId { get; set; }

    //Relations (Others send)
    public int CareerId { get; set; }
    public Career? Career { get; set; }

    public long InstitutionId { get; set; }
    public Institution? Institution { get; set; }

    public long ApplicantId { get; set; }
    public ApplicantProfile? ApplicantProfile { get; set; }

}