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
[SwaggerTag("")]
public class InstitutionController : ControllerBase
{
    private readonly IInstitutionService _institutionService;
    private readonly IMapper _mapper;

    public InstitutionController(IInstitutionService institutionService, IMapper mapper)
    {
        _institutionService = institutionService;
        _mapper = mapper;
    }
    
    [HttpGet("{careerId}")]
    public async Task<IActionResult> GetCareerByCareerId(int institutionId)
    {
        var result = await _institutionService.FindByInstitutionIdAsync(institutionId);
        if (!result.Success)
            return BadRequest(result.Message);
        var resultMapped = _mapper.Map<Institution, InstitutionResource>(result.Resource);
        return Ok(resultMapped);
    }
    [HttpGet]
    public async Task<IEnumerable<InstitutionResource>> ListAllInstitutions()
    {
        var institutions = await _institutionService.ListAllAsync();
        var mappedInstitutions = _mapper.Map<IEnumerable<Institution>, IEnumerable<InstitutionResource>>(institutions);
        return mappedInstitutions;
    }
    [HttpGet("{word}")]
    public async Task<IEnumerable<InstitutionResource>> ListAllInstitutionsByContainingWord(string word)
    {
        var institutions = await _institutionService.ListByContainingInstitutionName(word);
        var mappedInstitutions = _mapper.Map<IEnumerable<Institution>, IEnumerable<InstitutionResource>>(institutions);
        return mappedInstitutions;
    }
}