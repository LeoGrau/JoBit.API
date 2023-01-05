using System.Net.Mime;
using AutoMapper;
using JoBit.API.JoBit.Domain.Models;
using JoBit.API.JoBit.Domain.Repositories;
using JoBit.API.JoBit.Domain.Services;
using JoBit.API.JoBit.Resources.Show;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace JoBit.API.JoBit.Interfaces.Rest.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("CRUD for PostJob")]
public class PostJobController : BaseController
{
    private readonly IPostJobService _postJobService;
    private readonly IMapper _mapper;

    public PostJobController(IPostJobService postJobService, IMapper mapper)
    {
        _postJobService = postJobService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<PostJobResource>> GetAllPostJobs()
    {
        var postJobs = await _postJobService.ListAllAsync();
        var mappedPostJobs = _mapper.Map<IEnumerable<PostJob>, IEnumerable<PostJobResource>>(postJobs);
        return mappedPostJobs;
    }

    [HttpGet("job-name/{jobName}")]
    public async Task<IEnumerable<PostJobResource>> GetAllPostJobsByName(string jobName)
    {
        var postJobs = await _postJobService.ListAllByContainingJobName(jobName);
        var mappedPostJobs = _mapper.Map<IEnumerable<PostJob>, IEnumerable<PostJobResource>>(postJobs);
        return mappedPostJobs;
    }

    [HttpGet("{postJobId}")]
    public async Task<IActionResult> GetPostJobByPostJobId(long postJobId)
    {
        var result = await _postJobService.FindByPostJobIdAsync(postJobId);
        if (!result.Success)
            return BadRequest(result.Message);
        var mappedResult = _mapper.Map<PostJob, PostJobResource>(result.Resource);
        return Ok(mappedResult);
    }

}