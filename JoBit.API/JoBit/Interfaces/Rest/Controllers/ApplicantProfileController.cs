using System.Net.Mime;
using AutoMapper;
using JoBit.API.JoBit.Domain.Models;
using JoBit.API.JoBit.Domain.Services;
using JoBit.API.JoBit.Resources.Save;
using JoBit.API.JoBit.Resources.Show;
using JoBit.API.JoBit.Resources.Update;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace JoBit.API.JoBit.Interfaces.Rest.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Edit and Get Applicant Profiles")]
public class ApplicantProfileController : ControllerBase
{
    private readonly IApplicantProfileService _applicantProfileService;
    private readonly IApplicantTechSkillService _applicantTechSkillService;
    private readonly IMapper _mapper;

    public ApplicantProfileController(IApplicantProfileService applicantProfileService, IMapper mapper, IApplicantTechSkillService applicantTechSkillService)
    {
        _applicantProfileService = applicantProfileService;
        _applicantTechSkillService = applicantTechSkillService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<ApplicantProfileResource>> GetAllApplicantProfiles()
    {
        var applicantProfiles = await _applicantProfileService.ListAllAsync();
        var mappedApplicantProfiles = _mapper.Map<IEnumerable<ApplicantProfile>, IEnumerable<ApplicantProfileResource>>(applicantProfiles);
        return mappedApplicantProfiles;
    }   

    [HttpGet("{applicantId}")]
    public async Task<IActionResult> GetApplicantProfileByApplicantId(long applicantId)
    {
        var result = await _applicantProfileService.FindByApplicantId(applicantId);
        if (!result.Success)
            return BadRequest(result.Message);
        var mappedResult = _mapper.Map<ApplicantProfile, ApplicantProfileResource>(result.Resource);
        return Ok(mappedResult);
    }

    [HttpPost("applicant-tech-skill/{applicantId}")]
    public async Task<IActionResult> PostApplicantTechSkill(long applicantId, [FromBody, SwaggerRequestBody()] SaveApplicantTechSkillWithoutApplicantIdResource saveApplicantTechSkillResource)
    {
        var mappedApplicantTechSkill = _mapper.Map<SaveApplicantTechSkillWithoutApplicantIdResource, ApplicantTechSkill>(saveApplicantTechSkillResource);

        mappedApplicantTechSkill.ApplicantId = applicantId;
        var result = await _applicantTechSkillService.AddAsync(mappedApplicantTechSkill);
        if (!result.Success)
            return BadRequest(result.Message);
        var mappedResult = _mapper.Map<ApplicantTechSkill, ApplicantTechSkillResource>(result.Resource);
        return Ok(new { message = "Successfully added.", resource = mappedResult });
    }

    [HttpPut("{applicantId}")]
    public async Task<IActionResult> PutApplicantProfile(long applicantId, [FromBody, SwaggerRequestBody()] UpdateApplicantProfileResource updateApplicantProfileResource)
    {
        var mappedApplicantTechSkill = _mapper.Map<UpdateApplicantProfileResource, ApplicantProfile>(updateApplicantProfileResource);
        var result = await _applicantProfileService.UpdateAsync(applicantId, mappedApplicantTechSkill);
        if (!result.Success)
            return BadRequest(result.Message);
        var mappedResult = _mapper.Map<ApplicantProfile, ApplicantProfileResource>(result.Resource);
        return Ok(mappedResult);
    }

    [HttpPut("applicant-id/{applicantId}/tech-skill-id/{techSkillId}")]
    public async Task<IActionResult> PutApplicantTechSkill(long applicantId, short techSkillId, UpdateApplicantTechSkillWithoutApplicantIdResource updateApplicantTechSkillResource)
    {
        var mappedApplicantTechSkill = _mapper.Map<UpdateApplicantTechSkillWithoutApplicantIdResource, ApplicantTechSkill>(updateApplicantTechSkillResource);
        var result = await _applicantTechSkillService.UpdateAsync(applicantId, techSkillId, mappedApplicantTechSkill);
        if (!result.Success)
            return BadRequest(result.Message);
        var mappedResult = _mapper.Map<ApplicantTechSkill, ApplicantTechSkillResource>(result.Resource);
        return Ok(new { message = "Successfully updated.", resource = mappedResult });
        
    }
}