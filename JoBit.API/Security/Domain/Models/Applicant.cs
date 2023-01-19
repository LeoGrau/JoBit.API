using JoBit.API.JoBit.Domain.Models;
using JoBit.API.JoBit.Domain.Models.Intermediate;
using JoBit.API.Security.Domain.Models.Bases;
using JoBit.API.Security.Domain.Models.Flags;

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

    public Applicant()
    {
    }

    public Applicant(string? firstname, string? lastname, string? email, string? username, string? password, long userId) : base(firstname, lastname, email, username, password)
    {
        UserId = userId;
    }
}