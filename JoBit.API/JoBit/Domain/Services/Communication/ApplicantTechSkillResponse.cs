using JoBit.API.JoBit.Domain.Models;
using JoBit.API.Shared.Domain.Services.Communication;

namespace JoBit.API.JoBit.Domain.Services.Communication;

public class ApplicantTechSkillResponse : BaseResponse<ApplicantTechSkill>
{
    public ApplicantTechSkillResponse(ApplicantTechSkill resource) : base(resource)
    {
    }

    public ApplicantTechSkillResponse(string message) : base(message)
    {
    }
}