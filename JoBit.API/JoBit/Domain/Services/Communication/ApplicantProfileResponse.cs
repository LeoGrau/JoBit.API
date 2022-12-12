using JoBit.API.JoBit.Domain.Models;
using JoBit.API.Shared.Domain.Services.Communication;

namespace JoBit.API.JoBit.Domain.Services.Communication;

public class ApplicantProfileResponse : BaseResponse<ApplicantProfile>
{
    public ApplicantProfileResponse(ApplicantProfile resource) : base(resource)
    {
    }

    public ApplicantProfileResponse(string message) : base(message)
    {
    }
}