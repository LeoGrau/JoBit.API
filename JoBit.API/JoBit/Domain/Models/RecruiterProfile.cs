using JoBit.API.Security.Domain.Models;

namespace JoBit.API.JoBit.Domain.Models;

public class RecruiterProfile
{
    //Relations
    //-RecruiterId ForeignKey
    public long RecruiterId { get; set; }
    public Recruiter? Recruiter { get; set; }

}