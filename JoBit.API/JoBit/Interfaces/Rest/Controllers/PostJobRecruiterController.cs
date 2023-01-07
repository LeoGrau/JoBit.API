using System.Net.Mime;
using AutoMapper;
using JoBit.API.JoBit.Domain.Models.Composite;
using JoBit.API.JoBit.Domain.Models.Intermediate;
using JoBit.API.JoBit.Domain.Services;
using JoBit.API.JoBit.Domain.Services.Communication;
using JoBit.API.JoBit.Resources.Save;
using JoBit.API.JoBit.Resources.Show;
using JoBit.API.Security.Domain.Models.Intermediate;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace JoBit.API.JoBit.Interfaces.Rest.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("CRUD for Post Job Recruiters")]
public class PostJobRecruiterController : BaseController
{
    private readonly IPostJobRecruiterService _postJobRecruiterService;
    private readonly IMapper _mapper;

    public PostJobRecruiterController(IPostJobRecruiterService postJobRecruiterService, IMapper mapper)
    {
        _postJobRecruiterService = postJobRecruiterService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<PostJobRecruiterResource>> GetAllPostJobRecruiters()
    {
        var postJobRecruiters = await _postJobRecruiterService.ListAllAsync();
        var mappedPostJobRecruiters = _mapper.Map<IEnumerable<PostJobRecruiter>, IEnumerable<PostJobRecruiterResource>>(postJobRecruiters);
        return mappedPostJobRecruiters;
    }

    [HttpGet("/recruiter-id/{recruiterId}/post-id/{postId}")]
    public async Task<IActionResult> GetPostJobRecruiterByPrimaryKey(long recruiterId, long postId)
    {
        var primaryKey = new PostJobRecruiterPk(postId, recruiterId);
        var result = await _postJobRecruiterService.FindByPostJobIdAndRecruiterId(primaryKey);
        if (!result.Success)
            return BadRequest(result.Message);
        var mappedResult = _mapper.Map<PostJobRecruiter, PostJobRecruiterResource>(result.Resource);
        return Ok(mappedResult);
    }
    
    [HttpPost]
    public async Task<IActionResult> PostPostJobRecruiter([FromBody, SwaggerRequestBody("")] SavePostJobRecruiterResource savePostJobRecruiterResource)
    {
        var mappedPostJobResource = _mapper.Map<SavePostJobRecruiterResource, PostJobRecruiter>(savePostJobRecruiterResource);
        var result = await _postJobRecruiterService.AddAsync(mappedPostJobResource);
        if (!result.Success)
            return BadRequest(result.Message);
        var mappedResult = _mapper.Map<PostJobRecruiter, PostJobRecruiterResource>(result.Resource);
        return Ok(mappedResult);
    }

    [HttpDelete("/recruiter-id/{recruiterId}/post-id/{postId}")]
    public async Task<IActionResult> DeletePostJobRecruiter(long recruiterId, long postId)
    {
        var primaryKey = new PostJobRecruiterPk(postId, recruiterId); 
        var result = await _postJobRecruiterService.RemoveAsync(primaryKey);
        if (!result.Success)
            return BadRequest(result.Message);
        var mappedResult = _mapper.Map<PostJobRecruiter, PostJobRecruiterResource>(result.Resource);
        return Ok(mappedResult);
    }

}