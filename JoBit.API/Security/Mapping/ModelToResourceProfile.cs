using AutoMapper;
using JoBit.API.Security.Domain.Models;
using JoBit.API.Security.Domain.Services.Communication.Requests;
using JoBit.API.Security.Resources.Show;

namespace JoBit.API.Security.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Applicant, ApplicantResource>();
        
        CreateMap<Recruiter, RecruiterResource>();
    }
}