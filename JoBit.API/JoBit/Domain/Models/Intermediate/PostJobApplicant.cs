using JoBit.API.JoBit.Domain.Models;

namespace JoBit.API.Security.Domain.Models.Intermediate;

public class PostJobApplicant
{
    //Relations (Others send)
    public long ApplicantId { get; set; }
    public Applicant? Applicant { get; set; }

    public long PostId { get; set; }
    public PostJob? PostJob { get; set; }
}