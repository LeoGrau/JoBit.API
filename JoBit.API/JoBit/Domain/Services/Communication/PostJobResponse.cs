using JoBit.API.JoBit.Domain.Models;
using JoBit.API.Shared.Domain.Services.Communication;

namespace JoBit.API.JoBit.Domain.Services.Communication;

public class PostJobResponse : BaseResponse<PostJob>
{
    public PostJobResponse(PostJob resource) : base(resource)
    {
    }

    public PostJobResponse(string message) : base(message)
    {
    }
}