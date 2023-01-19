using JoBit.API.JoBit.Domain.Models.Intermediate;
using JoBit.API.Shared.Domain.Services.Communication;

namespace JoBit.API.JoBit.Domain.Services.Communication;

public class CareerInstitutionResponse : BaseResponse<CareerInstitution>
{
    public CareerInstitutionResponse(CareerInstitution resource) : base(resource)
    {
    }

    public CareerInstitutionResponse(string message) : base(message)
    {
    }
}