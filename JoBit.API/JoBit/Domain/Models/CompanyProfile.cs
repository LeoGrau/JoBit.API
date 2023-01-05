using JoBit.API.Security.Domain.Models;

namespace JoBit.API.JoBit.Domain.Models;

public class CompanyProfile
{
    //Relations we send
    public long CompanyId { get; set; }
    public Company? Company { get; set; }

    public String? CompanyName { get; set; }
    public String? AdminMail { get; set; }
    public String? Password { get; set; }
    public String? BusinessSector { get; set; }
    public String? PhotoUrl { get; set; }
    
    
}