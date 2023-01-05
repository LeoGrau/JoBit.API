using AutoMapper;
using JoBit.API.JoBit.Domain.Models;
using JoBit.API.JoBit.Resources.Save;
using JoBit.API.JoBit.Resources.Update;

namespace JoBit.API.JoBit.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveApplicantTechSkillResource, ApplicantTechSkill>();
        CreateMap<SaveApplicantTechSkillWithoutApplicantIdResource, ApplicantTechSkill>();
        CreateMap<UpdateApplicantTechSkillResource, ApplicantTechSkill>();
        CreateMap<UpdateApplicantTechSkillWithoutApplicantIdResource, ApplicantTechSkill>();
    }
}