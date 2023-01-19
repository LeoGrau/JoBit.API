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
public class CareerController : ControllerBase
{
    private readonly ICareerService _careerService;
    private readonly IMapper _mapper;

    public CareerController(ICareerService careerService, IMapper mapper)
    {
        _careerService = careerService;
        _mapper = mapper;
    }

    [HttpGet("{careerId}")]
    public async Task<IActionResult> GetCareerByCareerId(int careerId)
    {
        var result = await _careerService.FindByCareerIdAsync(careerId);
        if (!result.Success)
            return BadRequest(result.Message);
        var resultMapped = _mapper.Map<Career, CareerResource>(result.Resource);
        return Ok(resultMapped);
    }
    [HttpGet]
    public async Task<IEnumerable<CareerResource>> ListAllCareers()
    {
        var careers = await _careerService.ListAllAsync();
        var mappedCareers = _mapper.Map<IEnumerable<Career>, IEnumerable<CareerResource>>(careers);
        return mappedCareers;
    }
    
    [HttpGet("{word}")]
    public async Task<IEnumerable<CareerResource>> ListAllCareersByContainingWord(string word)
    {
        var careers = await _careerService.ListByContainingCareerName(word);
        var mappedCareers = _mapper.Map<IEnumerable<Career>, IEnumerable<CareerResource>>(careers);
        return mappedCareers;
    }
}