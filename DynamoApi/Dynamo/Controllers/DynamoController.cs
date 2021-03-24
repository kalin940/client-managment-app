using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Dynamo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DynamoController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;

        public DynamoController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return new JsonResult("API START");
        }
    }
}