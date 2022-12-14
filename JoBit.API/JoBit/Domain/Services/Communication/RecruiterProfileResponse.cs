using JoBit.API.JoBit.Domain.Models;
using JoBit.API.Shared.Domain.Services.Communication;

namespace JoBit.API.JoBit.Domain.Services.Communication;

public class RecruiterProfileResponse : BaseResponse<RecruiterProfile>
{
    public RecruiterProfileResponse(RecruiterProfile resource) : base(resource)
    {
    }

    public RecruiterProfileResponse(string message) : base(message)
    {
    }
}