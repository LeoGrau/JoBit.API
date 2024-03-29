using AutoMapper;
using JoBit.API.JoBit.Domain.Models;
using JoBit.API.JoBit.Domain.Models.Intermediate;
using JoBit.API.JoBit.Resources.Save;
using JoBit.API.JoBit.Resources.Update;
using JoBit.API.Security.Domain.Models.Intermediate;

namespace JoBit.API.JoBit.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        //ApplicantTechSkill
        CreateMap<SaveApplicantTechSkillResource, ApplicantTechSkill>();
        CreateMap<SaveApplicantTechSkillWithoutApplicantIdResource, ApplicantTechSkill>();
        CreateMap<UpdateApplicantTechSkillResource, ApplicantTechSkill>();
        CreateMap<UpdateApplicantTechSkillWithoutApplicantIdResource, ApplicantTechSkill>();

        //PostJob
        CreateMap<SavePostJobResource, PostJob>();
        
        //PostJobRecruiter
        CreateMap<SavePostJobRecruiterResource, PostJobRecruiter>();
        
        //ApplicantProfile
        CreateMap<UpdateApplicantProfileResource, ApplicantProfile>();


    }
}