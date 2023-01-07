using AutoMapper;
using JoBit.API.JoBit.Domain.Models;
using JoBit.API.JoBit.Resources.Show;

namespace JoBit.API.JoBit.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<ApplicantProfile, ApplicantProfileResource>();
        CreateMap<RecruiterProfile, RecruiterProfileResource>();
        CreateMap<TechSkill, TechSkillResource>();
        CreateMap<ApplicantTechSkill, ApplicantTechSkillResource>()
            .ForMember(applicantTechSkillResource => applicantTechSkillResource.TechName,
                memberOptions => memberOptions.MapFrom(applicantTechSkill => applicantTechSkill.TechSkill.TechName))
            .ForMember(applicantTechSkillResource => applicantTechSkillResource.ExperienceTime,
                memberOptions => memberOptions.MapFrom(applicantTechSkill => DateTime.Now.Subtract(applicantTechSkill.StartDate)));
        CreateMap<PostJob, PostJobResource>();
        CreateMap<CompanyProfile, CompanyProfileResource>();
    }
}