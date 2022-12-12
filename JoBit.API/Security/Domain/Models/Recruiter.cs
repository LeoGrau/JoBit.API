using JoBit.API.Security.Domain.Models.Bases;

namespace JoBit.API.Security.Domain.Models;

public class Recruiter : UserBase
{
    public long RecruiterId { get; set; }
    
    //Relations
    //-UserId ForeignKey
    public long UserId { get; set; }
    public User? User { get; set; }
    
    //-CompanyId ForeignKey
    public long CompanyId { get; set; }
    public Company? Company { get; set; }

    public Recruiter(long userId, string? firstname, string? lastname) : base(userId, firstname, lastname)
    {
        UserId = userId;
        CompanyId = 0;
    }
}