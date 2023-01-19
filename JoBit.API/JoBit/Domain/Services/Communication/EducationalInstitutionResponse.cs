using JoBit.API.JoBit.Domain.Models;
using JoBit.API.Shared.Domain.Services.Communication;

namespace JoBit.API.JoBit.Domain.Services.Communication;

public class EducationalInstitutionResponse : BaseResponse<Institution>
{
    public EducationalInstitutionResponse(Institution resource) : base(resource)
    {
    }

    public EducationalInstitutionResponse(string message) : base(message)
    {
    }
}