using JoBit.API.JoBit.Domain.Models.Base;
using JoBit.API.Security.Domain.Models;

namespace JoBit.API.JoBit.Domain.Models;

public class ApplicantProfile : BaseProfile
{ 
    //Relations
    //-ApplicantId ForeignKey
    public long ApplicantId { get; set; } //This is also primary key.
    public Applicant? Applicant { get; set; }

    public ApplicantProfile()
    {
    }

    public ApplicantProfile(string? firstname, string? lastname, string? photoUrl, string? description, long applicantId) : base(firstname, lastname, photoUrl, description)
    {
        ApplicantId = applicantId;
    }
}