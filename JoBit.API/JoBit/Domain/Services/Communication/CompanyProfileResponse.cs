using JoBit.API.JoBit.Domain.Models;
using JoBit.API.Shared.Domain.Services.Communication;

namespace JoBit.API.JoBit.Domain.Services.Communication;

public class CompanyProfileResponse : BaseResponse<CompanyProfile>
{
    public CompanyProfileResponse(CompanyProfile resource) : base(resource)
    {
    }

    public CompanyProfileResponse(string message) : base(message)
    {
    }
}