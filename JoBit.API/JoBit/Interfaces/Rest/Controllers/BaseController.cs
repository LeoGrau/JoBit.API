using System.Data.SqlTypes;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace JoBit.API.JoBit.Interfaces.Rest.Controllers;

[ApiController]
[Route("/api/v1")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Welcome!")]
public class BaseController : ControllerBase
{
    public BaseController()
    {
    }

    [HttpGet("Welcome")]
    public IActionResult Welcome()
    {
        return Ok(new
        {
            author = "Leonardo Manuel Grau Vargas",
            apiName = "JoBit API",
            tech = ".NET",
            description = "Well, this is my first 'serious' API. I tried to do the best I could and my fingers potential permit",
            version = "v2.0"
        });
    }
}