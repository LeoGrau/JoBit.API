using JoBit.API.JoBit.Domain.Models;
using JoBit.API.Shared.Domain.Services.Communication;

namespace JoBit.API.JoBit.Domain.Services.Communication;

public class TechSkillResponse : BaseResponse<TechSkill>
{
    public TechSkillResponse(TechSkill resource) : base(resource)
    {
    }

    public TechSkillResponse(string message) : base(message)
    {
    }
}