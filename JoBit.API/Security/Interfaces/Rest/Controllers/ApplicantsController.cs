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
[SwaggerTag("CRUD for Applicants")]
public class ApplicantsController : ControllerBase
{
    private readonly IApplicantService _applicantService;
    private readonly IMapper _mapper;

    public ApplicantsController(IApplicantService applicantService, IMapper mapper)
    {
        _applicantService = applicantService;
        _mapper = mapper;
    }

    [HttpGet("{applicantId}")]
    public async Task<IActionResult> GetApplicantByApplicantId(long applicantId)
    {
        var applicant = await _applicantService.FindByApplicantIdAsync(applicantId);
        if (applicant == null)
            return BadRequest("Applicant does not exist");
        return Ok(applicant);
    }

    //[AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> PostApplicant(
        [FromBody, SwaggerRequestBody("New Applicant")] ApplicantRegisterRequest applicantRegisterRequest)
    {
        var mappedApplicant = _mapper.Map<ApplicantRegisterRequest, Applicant>(applicantRegisterRequest);
        await _applicantService.AddAsync(mappedApplicant);
        return Ok(new { message = "Successfully registered." });
    }
}