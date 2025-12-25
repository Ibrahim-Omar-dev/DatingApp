using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> _logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("serverError")]
        public IActionResult ServerError()
        {
            _logger.LogError("Server error occurred");
            throw new Exception("Server Error");
        }

        [HttpGet("auth")]
        public IActionResult Auth()
        {
            _logger.LogError("Unauthorized access");
            return Unauthorized();
        }

        [HttpGet("notfound")]
        public IActionResult NotFoundError()
        {
            _logger.LogError("Resource not found");
            return NotFound();
        }
    }
}
