using System.Net.Mime;
using AutoMapper;
using JoBit.API.Security.Domain.Models;
using JoBit.API.Security.Domain.Services;
using JoBit.API.Security.Domain.Services.Communication.Requests;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace JoBit.API.Security.Interfaces.Rest.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("CRUD for Recruiters")]
public class RecruitersController : ControllerBase
{
    private readonly IRecruiterService _recruiterService;
    private readonly IMapper _mapper;

    public RecruitersController(IRecruiterService recruiterService, IMapper mapper)
    {
        _recruiterService = recruiterService;
        _mapper = mapper;
    }
    
    [HttpGet("{recruiterId}")]
    public async Task<IActionResult> GetApplicantByApplicantId(long applicantId)
    {
        var user = await _recruiterService.FindByRecruiterIdAsync(applicantId);
        if (user == null)
            return BadRequest("Recruiter does not exist");
        return Ok(user);
    }

    //[AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> PostApplicant(
        [FromBody, SwaggerRequestBody("New Recruiter")] RecruiterRegisterRequest recruiterRegisterRequest)
    {
        var mappedApplicant = _mapper.Map<RecruiterRegisterRequest, Recruiter>(recruiterRegisterRequest);
        await _recruiterService.AddAsync(mappedApplicant);
        return Ok(new { message = "Successfully registered." });
    }
}