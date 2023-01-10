using System.Net.Mime;
using AutoMapper;
using JoBit.API.JoBit.Interfaces.Rest.Controllers;
using JoBit.API.Security.Domain.Models;
using JoBit.API.Security.Domain.Services;
using JoBit.API.Security.Domain.Services.Communication.Requests;
using JoBit.API.Security.Resources.Show;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace JoBit.API.Security.Interfaces.Rest.Controllers;

[ApiController]
[Route("/api/v1/companies")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("CRUD for Companies")]
public class CompanyController : BaseController
{
    private readonly ICompanyService _companyService;
    private readonly IMapper _mapper;

    public CompanyController(ICompanyService companyService, IMapper mapper)
    {
        _companyService = companyService;
        _mapper = mapper;
    }

    [HttpGet("{companyId}")]
    public async Task<IActionResult> GetCompanyByCompanyId(long companyId)
    {
        var result = await _companyService.FindByCompanyIdAsync(companyId);
        if (result == null)
            return BadRequest("Company does not exist!");
        var mappedCompany = _mapper.Map<Company, CompanyResource>(result);
        return Ok(mappedCompany);

    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterCompany([FromBody, SwaggerRequestBody("New Company")] CompanyRegisterRequest companyRegisterRequest)
    {
        var mappedCompany = _mapper.Map<CompanyRegisterRequest, Company>(companyRegisterRequest);
        await _companyService.AddAsync(mappedCompany);
        return Ok(new { message = "Successfully registered." });
    }
}