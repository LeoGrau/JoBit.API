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
[SwaggerTag("Get TechSkill")]
public class TechSkillController : ControllerBase
{
    private readonly ITechSkillService _techSkillService;
    private readonly IMapper _mapper;

    public TechSkillController(ITechSkillService techSkillService, IMapper mapper)
    {
        _techSkillService = techSkillService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<TechSkillResource>> GetAllTechSkills()
    {
        var techSkills = await _techSkillService.ListAllAsync();
        var techSkillsMapped = _mapper.Map<IEnumerable<TechSkill>, IEnumerable<TechSkillResource>>(techSkills);
        return techSkillsMapped;
    }

    [HttpGet("{techSkillId}")]
    public async Task<IActionResult> GetTechSkillByTechSkillId(short techSkillId)
    {
        var result = await _techSkillService.FindByTechSkillId(techSkillId);
        if (!result.Success)
            return BadRequest(result.Message);
        var mappedResult = _mapper.Map<TechSkill, TechSkillResource>(result.Resource);
        return Ok(mappedResult);
    }
    [HttpGet("name/{techName}")]
    public async Task<IActionResult> GetTechSkillByTechName(String techName)
    {
        var result = await _techSkillService.FindByTechName(techName);
        if (!result.Success)
            return BadRequest(result.Message);
        var mappedResult = _mapper.Map<TechSkill, TechSkillResource>(result.Resource);
        return Ok(mappedResult);
    }
    
    [HttpGet("find/{word}")]
    public async Task<IEnumerable<TechSkillResource>> GetAllTechSkillsByContainingWord(String word)
    {
        var techSkills = await _techSkillService.ListByContainingWord(word);
        var techSkillsMapped = _mapper.Map<IEnumerable<TechSkill>, IEnumerable<TechSkillResource>>(techSkills);
        return techSkillsMapped;
    }
}