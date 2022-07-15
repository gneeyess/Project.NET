using System;
using System.Collections;
using Microsoft.Extensions.Logging;
using log4net;
using System;
using Modsen.App.API;
using Dal.Entities.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Modsen.App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoggingController : ControllerBase
    {
        private readonly ILogger _logger;

        public LoggingController(ILogger<LoggingController> logger)
        {
            _logger = logger;
        }

        // GET api/values
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<string>> Get(int id)
        {
            _logger.LogInformation("Start : Getting item details for {ID}", id);

            List<string> list = new List<string>();
            list.Add("A");
            list.Add("B");
            list.Add("C");

            _logger.LogInformation($"Completed : Item details are {string.Join(", ", list)}");
            return list;
        }
    }
}
