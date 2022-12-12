using JoBit.API.JoBit.Domain.Models;
using JoBit.API.Security.Domain.Models.Bases;

namespace JoBit.API.Security.Domain.Models;

public class Applicant : UserBase
{
    public long ApplicantId { get; set; }
    
    //Relations (Others sends)
    //-UserId ForeignKey
    public long UserId { get; set; }
    public User? User { get; set; }
    

    //Relations (We send)
    public ApplicantProfile? ApplicantProfile;


    public Applicant(long userId, string? firstname, string? lastname) : base(userId, firstname, lastname)
    {
        UserId = userId;
    }
}