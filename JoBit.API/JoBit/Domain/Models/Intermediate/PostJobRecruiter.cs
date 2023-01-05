using JoBit.API.JoBit.Domain.Models;

namespace JoBit.API.Security.Domain.Models.Intermediate;

public class PostJobRecruiter
{
    //Relations (Others send)
    public long RecruiterId { get; set; }
    public Recruiter? Recruiter { get; set; }

    public long PostId { get; set; }
    public PostJob? PostJob { get; set; }
    
    
}