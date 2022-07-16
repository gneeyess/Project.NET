using Dal.Entities.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Modsen.App.API.Controllers;

[Route("api/[controller]")]

[ApiController]
public class TestController : ControllerBase
{
    [Authorize]
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(); //Why?
    }
    [HttpGet("un")]
    public IActionResult GetUnAuthorize()
    {
        return Ok();
    }
}