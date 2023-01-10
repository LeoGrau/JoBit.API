using System.Net.Mime;
using AutoMapper;
using JoBit.API.JoBit.Domain.Models;
using JoBit.API.JoBit.Domain.Services;
using JoBit.API.JoBit.Resources.Show;
using JoBit.API.Security.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace JoBit.API.JoBit.Interfaces.Rest.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("CRUD for Company Profile")]
public class CompanyProfileController : ControllerBase
{
    private readonly ICompanyProfileService _companyProfileService;
    private readonly IMapper _mapper;
    
    public CompanyProfileController(ICompanyProfileService companyProfileService, IMapper mapper)
    {
        _companyProfileService = companyProfileService;
        _mapper = mapper;
    }

    
    [HttpGet]
    public async Task<IEnumerable<CompanyProfileResource>> GetAllCompanyProfiles()
    {
        var companyProfiles = await _companyProfileService.ListAllAsync();
        var mappedCompanyProfiles = _mapper.Map<IEnumerable<CompanyProfile>, IEnumerable<CompanyProfileResource>>(companyProfiles);
        return mappedCompanyProfiles;
    }
    
    [HttpGet("{companyId}")]
    public async Task<IActionResult> GetCompanyProfileByCompanyId(long companyId)
    {
        var result = await _companyProfileService.FindByCompanyIdAsync(companyId);
        if (!result.Success)
            return BadRequest(result.Message);
        var mappedResult = _mapper.Map<CompanyProfile, CompanyProfileResource>(result.Resource);
        return Ok(mappedResult);
    }
}