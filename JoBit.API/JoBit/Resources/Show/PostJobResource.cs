using JoBit.API.JoBit.Domain.Models.Flags;
using JoBit.API.JoBit.Resources.Base.Abstract;

namespace JoBit.API.JoBit.Resources.Show;

public class PostJobResource : PostBaseResource
{
    public IList<PostJobRecruiterResource>? PostJobRecruiters { get; set; }
    public CompanyProfileResource? CompanyProfile  { get; set; }
    public long PostId { get; set; }
    public long CompanyId { get; set; }
    public long RecruiterPublisherId { get; set; }
    public String? JobName { get; set; }
    public Decimal Salary { get; set; }
    public String? Place { get; set; }
    public JobModality JobModality { get; set; }
    public TimeModality TimeModality { get; set; }
}