using System.Net.Mime;
using AutoMapper;
using JoBit.API.Security.Domain.Models;
using JoBit.API.Security.Domain.Services;
using JoBit.API.Security.Domain.Services.Communication.Requests;
using JoBit.API.Security.Resources.Show;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace JoBit.API.Security.Interfaces.Rest.Controllers;

[ApiController]
[Route("/api/v1/recruiters")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("CRUD for Recruiters")]
public class RecruiterController : ControllerBase
{
    private readonly IRecruiterService _recruiterService;
    private readonly IMapper _mapper;

    public RecruiterController(IRecruiterService recruiterService, IMapper mapper)
    {
        _recruiterService = recruiterService;
        _mapper = mapper;
    }
    
    [HttpGet("{recruiterId}")]
    public async Task<IActionResult> GetRecruiterByRecruiterId(long recruiterId)
    {
        var recruiter = await _recruiterService.FindByRecruiterIdAsync(recruiterId);
        if (recruiter == null)
            return BadRequest("Recruiter does not exist");
        var mappedRecruiter = _mapper.Map<Recruiter, RecruiterResource>(recruiter);
        return Ok(mappedRecruiter);
    }

    //[AllowAnonymous]
    [HttpPost("register")]
    public async Task<IActionResult> RegisterRecruiter(
        [FromBody, SwaggerRequestBody("New Recruiter")] RecruiterRegisterRequest recruiterRegisterRequest)
    {
        var mappedApplicant = _mapper.Map<RecruiterRegisterRequest, Recruiter>(recruiterRegisterRequest);
        await _recruiterService.AddAsync(mappedApplicant);
        return Ok(new { message = "Successfully registered." });
    }
}