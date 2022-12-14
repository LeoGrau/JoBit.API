using JoBit.API.JoBit.Domain.Models.Base;
using JoBit.API.Security.Domain.Models;

namespace JoBit.API.JoBit.Domain.Models;

public class RecruiterProfile : BaseProfile
{
    //Relations
    //-RecruiterId ForeignKey
    public long RecruiterId { get; set; }
    public Recruiter? Recruiter { get; set; }

    public RecruiterProfile()
    {
    }

    public RecruiterProfile(string? firstname, string? lastname, string? photoUrl, string? description, long recruiterId) : base(firstname, lastname, photoUrl, description)
    {
        RecruiterId = recruiterId;
    }
}