using JoBit.API.JoBit.Domain.Models;
using JoBit.API.Security.Domain.Models.Bases;
using JoBit.API.Security.Domain.Models.Flags;

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
    
    //We Send
    public RecruiterProfile? RecruiterProfile { get; set; }

    public Recruiter()
    {
    }

    public Recruiter(string? firstname, string? lastname, string? email, string? username, string? password, long userId, long companyId) : base(firstname, lastname, email, username, password)
    {
        UserId = userId;
        CompanyId = companyId;
    }
}