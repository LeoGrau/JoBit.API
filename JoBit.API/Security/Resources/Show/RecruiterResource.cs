using JoBit.API.Security.Resources.Base;

namespace JoBit.API.Security.Resources.Show;

public class RecruiterResource : UserBaseResource
{
    public long RecruiterId { get; set; }
}