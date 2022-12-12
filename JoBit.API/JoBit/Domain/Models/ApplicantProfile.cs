using JoBit.API.Security.Domain.Models;

namespace JoBit.API.JoBit.Domain.Models;

public class ApplicantProfile
{
    public String? Firstname { get; set; }
    public String? Lastname { get; set; }
    public String? PhotoUrl { get; set; }
    public String? Description { get; set; }

    //Relations
    //-ApplicantId ForeignKey
    public long ApplicantId { get; set; } //This is also primary key.
    public Applicant? Applicant { get; set; }
    
    
    
}