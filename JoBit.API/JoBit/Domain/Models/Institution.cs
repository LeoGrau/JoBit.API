using JoBit.API.JoBit.Domain.Models.Intermediate;

namespace JoBit.API.JoBit.Domain.Models;

public class Institution
{
    public long InstitutionId { get; set; }
    public String? InstitutionName { get; set; }
    public String? PhotoUrl { get; set; }
    
    //Relations (We send)
    public IList<CareerInstitution> CareerInstitutions { get; set; }
}