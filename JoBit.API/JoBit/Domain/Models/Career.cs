using JoBit.API.JoBit.Domain.Models.Intermediate;

namespace JoBit.API.JoBit.Domain.Models;

public class Career
{
    public int CareerId { get; set; }
    public String? CareerName { get; set; }
    
    //Relations (We send)
    public IList<CareerInstitution> CareerInstitutions { get; set; }
}