namespace JoBit.API.Security.Domain.Models;

public class Company
{
    public long CompanyId { get; set; }
    public String? CompanyName { get; set; }
    public String? BusinessSector { get; set; }
    
    //We send
    public IList<Recruiter>? Recruiters { get; set; }
}