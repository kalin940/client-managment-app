using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dynamo.Common.Exceptions;
using Dynamo.Extensions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Dynamo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        private readonly ILogger<ErrorController> _logger;
        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
        }

        [Route("/Error")]
        public MyErrorResponse Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context?.Error; 
            var code = 500;

            //we can add custom exceptions here
            if (exception is UserNotFoundException) code = 404; // Not Found
            else if (exception is UnauthorizedAccessException) code = 401; // Unauthorized
            else if (exception is ArgumentOutOfRangeException) code = 400; // Bad Request

            Response.StatusCode = code; // we can use HttpStatusCode enum instead

            _logger.LogError($"{code}: {exception}");

            var ex = new MyErrorResponse(exception, code);
            ex.StackTrace = null;

            return ex; // 
        }

        [Route("/ErrorDev")]
        public MyErrorResponse ErrorDev()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context?.Error;
            var code = 500;

            //we can add custom exceptions here
            if (exception is NullReferenceException) code = 404; // Not Found
            else if (exception is UnauthorizedAccessException) code = 401; // Unauthorized
            else if (exception is ArgumentOutOfRangeException) code = 400; // Bad Request

            Response.StatusCode = code; // we can use HttpStatusCode enum instead

            _logger.LogError($"{code}: {exception}");

            return new MyErrorResponse(exception, code); // 
        }
    }
}