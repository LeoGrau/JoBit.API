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
[Route("/api/v1/applicant-tech-skill")]
public class ApplicantTechSkillController : ControllerBase
{
    private readonly IApplicantTechSkillService _applicantTechSkillService;
    private readonly IMapper _mapper;

    public ApplicantTechSkillController(IApplicantTechSkillService applicantTechSkillService, IMapper mapper)
    {
        _applicantTechSkillService = applicantTechSkillService;
        _mapper = mapper;
    }

    [HttpGet("{applicantId}")]
    public async Task<IActionResult> GetAllByApplicantIdAsync(long applicantId)
    {
        var result = await _applicantTechSkillService.ListByApplicantIdAsync(applicantId);
        if (result == null)
            return BadRequest("Applicant does not exist.");
        var mappedResult = _mapper.Map<IEnumerable<ApplicantTechSkill>, IEnumerable<ApplicantTechSkillResource>>(result);
        return Ok(mappedResult);
    }

    [HttpGet("applicantId={applicantId}/techSkillId={techSkillId}")]
    public async Task<IActionResult> GetByApplicantTechSkillPkAsync(long applicantId, short techSkillId)
    {
        var result = await _applicantTechSkillService.FindByApplicantIdAndTechSkillIdAsync(applicantId, techSkillId);
        if (!result.Success)
            return BadRequest(result.Message);
        var mappedResult = _mapper.Map<ApplicantTechSkill, ApplicantTechSkillResource>(result.Resource);
        return Ok(mappedResult);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody, SwaggerRequestBody()] SaveApplicantTechSkillResource saveApplicantTechSkillResource)
    {
        var mappedApplicantTechSkill = _mapper.Map<SaveApplicantTechSkillResource, ApplicantTechSkill>(saveApplicantTechSkillResource);
        var result = await _applicantTechSkillService.AddAsync(mappedApplicantTechSkill);
        if (!result.Success) 
            return BadRequest(result.Message);
        var mappedResult = _mapper.Map<ApplicantTechSkill, ApplicantTechSkillResource>(result.Resource);
        return Ok(new { message = "Successfully added.", resource = mappedResult });
    }

    [HttpPut("applicantId={applicantId}/techSkillId={techSkillId}")]
    public async Task<IActionResult> UpdateAsync(long applicantId, short techSkillId,
        UpdateApplicantTechSkillResource updatedApplicantTechSkill)
    {
        var mappedApplicantTechSkill = _mapper.Map<UpdateApplicantTechSkillResource, ApplicantTechSkill>(updatedApplicantTechSkill);
        var result = await _applicantTechSkillService.UpdateAsync(applicantId, techSkillId, mappedApplicantTechSkill);
        if (!result.Success) 
            return BadRequest(result.Message);
        var mappedResult = _mapper.Map<ApplicantTechSkill, ApplicantTechSkillResource>(result.Resource);
        return Ok(new { message = "Successfully updated.", resource = mappedResult });
    }

    [HttpDelete("applicantId={applicantId}/techSkillId={techSkillId}")]
    public async Task<IActionResult> RemoveAsync(long applicantId, short techSkillId)
    {
        var result = await _applicantTechSkillService.RemoveAsync(applicantId, techSkillId);
        if (!result.Success)
            return BadRequest(result.Message);
        return Ok(new { message = "Successfully removed" });
    }
}