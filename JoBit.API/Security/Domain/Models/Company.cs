using JoBit.API.JoBit.Domain.Models;

namespace JoBit.API.Security.Domain.Models;

public class Company
{
    public long CompanyId { get; set; }
    public String? CompanyName { get; set; }
    public String? BusinessSector { get; set; }
    public String? AdminMail { get; set; }
    public String? Password { get; set; }

    //Relations (We send)
    public IList<Recruiter>? Recruiters { get; set; }
    public IList<PostJob>? PostJobs { get; set; }
    public CompanyProfile? CompanyProfile { get; set; }

}