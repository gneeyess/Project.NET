using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Modsen.App.API.Controllers
{
    //I don't know does this class necessary.
    //If actually not it can be deleted.

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
