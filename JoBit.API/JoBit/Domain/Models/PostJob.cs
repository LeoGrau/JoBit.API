using JoBit.API.JoBit.Domain.Models.Flags;
using JoBit.API.JoBit.Domain.Models.Intermediate;
using JoBit.API.Security.Domain.Models;
using JoBit.API.Security.Domain.Models.Intermediate;

namespace JoBit.API.JoBit.Domain.Models;

public class PostJob : Post
{
    public String? JobName;
    public String? Place;
    public Decimal Salary;
    public JobModality JobModality;
    public TimeModality TimeModality;
    
    //Relations (Others send)
    //Company Profile
    public long CompanyId { get; set; }
    public Company? Company { get; set; }
    public long RecruiterPublisherId { get; set; } //Main Recruiter Publisher 
    public Recruiter? RecruiterPublisher { get; set; }

    //Relations (We send)
    public IList<PostJobRecruiter>? PostJobRecruiters { get; set; }
    public IList<PostJobApplicant>? PostJobApplicants { get; set; }

    //Methods
    public void SetPostJob(PostJob postJob)
    {
        Title = postJob.Title;
        Description = postJob.Description;
        Place = postJob.Place;
        Salary = postJob.Salary;
        TimeModality = postJob.TimeModality;
        JobModality = postJob.JobModality;
    }
}