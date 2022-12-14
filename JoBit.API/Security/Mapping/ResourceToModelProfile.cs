using AutoMapper;
using JoBit.API.Security.Domain.Models;
using JoBit.API.Security.Domain.Services.Communication.Requests;

namespace JoBit.API.Security.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<ApplicantRegisterRequest, Applicant>();
        
        CreateMap<RecruiterRegisterRequest, Recruiter>();
    }
}