using JoBit.API.Security.Domain.Models.Intermediate;
using JoBit.API.Shared.Domain.Services.Communication;

namespace JoBit.API.JoBit.Domain.Services.Communication;

public class PostJobRecruiterResponse : BaseResponse<PostJobRecruiter>
{
    public PostJobRecruiterResponse(PostJobRecruiter resource) : base(resource)
    {
    }

    public PostJobRecruiterResponse(string message) : base(message)
    {
    }
}