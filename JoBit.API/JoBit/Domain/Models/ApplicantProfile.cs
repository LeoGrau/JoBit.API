using JoBit.API.JoBit.Domain.Models.Base;
using JoBit.API.JoBit.Domain.Models.Intermediate;
using JoBit.API.Security.Domain.Models;

namespace JoBit.API.JoBit.Domain.Models;

public class ApplicantProfile : BaseProfile
{ 
    //Relations
    //-ApplicantId ForeignKey
    public long ApplicantId { get; set; } //This is also primary key.
    public Applicant? Applicant { get; set; }
    
    //Relations (We send)
    //-ApplicantProfileTechSkill
    public IList<ApplicantTechSkill>? ApplicantTechSkills { get; set; }
    public IList<CareerInstitution>? CareerInstitutions { get; set; }

    public ApplicantProfile()
    {
    }

    public ApplicantProfile(string? firstname, string? lastname, string? photoUrl, string? description, string? profession, long applicantId) : base(firstname, lastname, photoUrl, description, profession)
    {
        ApplicantId = applicantId;
    }

    public void SetApplicantProfile(ApplicantProfile applicantProfile)
    {
        Firstname = applicantProfile.Firstname;
        Lastname = applicantProfile.Lastname;
        PhotoUrl = applicantProfile.PhotoUrl;
        Description = applicantProfile.Description;
        Profession = applicantProfile.Profession;
    }
}