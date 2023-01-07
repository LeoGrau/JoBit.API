using AutoMapper;
using JoBit.API.JoBit.Resources.Show;
using JoBit.API.Security.Domain.Models;
using JoBit.API.Security.Domain.Services.Communication.Requests;
using JoBit.API.Security.Resources.Show;

namespace JoBit.API.Security.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        //Applicant
        CreateMap<Applicant, ApplicantResource>();
        
        //Recruiter
        CreateMap<Recruiter, RecruiterResource>();
        CreateMap<Recruiter, RecruiterProfileResource>();
        
        //Company
        CreateMap<Company, CompanyResource>();
    }
}