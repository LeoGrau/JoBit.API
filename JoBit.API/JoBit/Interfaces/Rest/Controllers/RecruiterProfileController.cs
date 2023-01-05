using System.Net.Mime;
using AutoMapper;
using JoBit.API.JoBit.Domain.Models;
using JoBit.API.JoBit.Domain.Services;
using JoBit.API.JoBit.Resources.Show;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace JoBit.API.JoBit.Interfaces.Rest.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Edit and Get Recruiter Profiles")]
public class RecruiterProfileController : ControllerBase
{
    private readonly IRecruiterProfileService _recruiterProfileService;
    private readonly IMapper _mapper;

    public RecruiterProfileController(IRecruiterProfileService recruiterProfileService, IMapper mapper)
    {
        _recruiterProfileService = recruiterProfileService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<RecruiterProfileResource>> GetAllRecruiterProfiles()
    {
        var recruiterProfiles = await _recruiterProfileService.ListAllAsync();
        var mappedRecruiterProfiles =
            _mapper.Map<IEnumerable<RecruiterProfile>, IEnumerable<RecruiterProfileResource>>(recruiterProfiles);
        return mappedRecruiterProfiles;
    }

    [HttpGet("{recruiterId}")]
    public async Task<IActionResult> GetRecruiterProfileByRecruiterId(long recruiterId)
    {
        var result = await _recruiterProfileService.FindByRecruiterId(recruiterId);
        if (!result.Success)
            return BadRequest(result.Message);
        var mappedResult = _mapper.Map<RecruiterProfile, RecruiterProfileResource>(result.Resource);
        return Ok(mappedResult);
    }
}
