using JoBit.API.JoBit.Domain.Models.Flags;
using JoBit.API.JoBit.Resources.Base.Abstract;
using JoBit.API.JoBit.Resources.Show;

namespace JoBit.API.JoBit.Resources.Save;

public class SavePostJobResource : PostBaseResource
{
    public String? JobName { get; set; }
    public String? Place { get; set; }
    public Decimal Salary { get; set; }
    public JobModality JobModality { get; set; }
    public TimeModality TimeModality { get; set; }
    public long CompanyId { get; set; }
    public long RecruiterPublisherId { get; set; }
}