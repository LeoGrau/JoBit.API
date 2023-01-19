using System.Net.Mime;
using AutoMapper;
using JoBit.API.JoBit.Domain.Models.Intermediate;
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
[SwaggerTag("")]
public class CareerInstitutionController : ControllerBase
{
    private readonly ICareerInstitutionService _careerInstitutionService;
    private readonly IMapper _mapper;

    public CareerInstitutionController(ICareerInstitutionService careerInstitutionService, IMapper mapper)
    {
        _careerInstitutionService = careerInstitutionService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<CareerInstitution>> GetAllCareerInstitutions()
    {
        var careerInstitutions = await _careerInstitutionService.ListAllAsync();
        var mappedCareerInstitutions = _mapper.Map<IEnumerable<CareerInstitution>, IEnumerable<CareerInstitution>>(careerInstitutions);
        return mappedCareerInstitutions;
    }
    
    [HttpGet("{applicantId}")]
    public async Task<IEnumerable<CareerInstitution>> GetAllCareerInstitutionsByApplicantId(long applicantId)
    {
        var careerInstitutions = await _careerInstitutionService.ListByApplicantIdAsync(applicantId);
        var mappedCareerInstitutions = _mapper.Map<IEnumerable<CareerInstitution>, IEnumerable<CareerInstitution>>(careerInstitutions);
        return mappedCareerInstitutions;
    }

    [HttpPost]
    public async Task<IActionResult> PostCareerInstitution([FromBody, SwaggerRequestBody()] SaveCareerInstitutionResource saveCareerInstitution)
    {
        var mappedCareerInstitution = _mapper.Map<SaveCareerInstitutionResource, CareerInstitution>(saveCareerInstitution);
        var result = await _careerInstitutionService.AddAsync(mappedCareerInstitution);
        if (!result.Success)
            return BadRequest(result.Message);
        var mappedResult = _mapper.Map<CareerInstitution, CareerInstitutionResource>(result.Resource);
        return Ok(mappedResult);
    }

    [HttpPut("{careerInstitutionId}")]
    public async Task<IActionResult> PutCareerInstitution([FromBody, SwaggerRequestBody()] UpdateCareerInstitutionResource updateCareerInstitution)
    {
        var mappedCareerInstitution = _mapper.Map<UpdateCareerInstitutionResource, CareerInstitution>(updateCareerInstitution);
        var result = await _careerInstitutionService.AddAsync(mappedCareerInstitution);
        if(!result.Success)
            return BadRequest(result.Message);
        var mappedResult = _mapper.Map<CareerInstitution, CareerInstitutionResource>(result.Resource);
        return Ok(mappedResult);
    }
    
    [HttpDelete("{careerInstitutionId}")]
    public async Task<IActionResult> DeleteCareerInstitution(long careerInstitutionId)
    {
        var result = await _careerInstitutionService.RemoveAsync(careerInstitutionId);
        if(!result.Success)
            return BadRequest(result.Message);
        var mappedResult = _mapper.Map<CareerInstitution, CareerInstitutionResource>(result.Resource);
        return Ok(mappedResult);
    }
}