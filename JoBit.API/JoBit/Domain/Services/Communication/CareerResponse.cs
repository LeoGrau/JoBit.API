using JoBit.API.JoBit.Domain.Models;
using JoBit.API.Shared.Domain.Services.Communication;

namespace JoBit.API.JoBit.Domain.Services.Communication;

public class CareerResponse : BaseResponse<Career>
{
    public CareerResponse(Career resource) : base(resource)
    {
    }

    public CareerResponse(string message) : base(message)
    {
    }
}