using LoggingAPI.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LoggingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogManagerController : ControllerBase
    {
        private readonly ILogger _logger;

        public LogManagerController(ILogger<LogManagerController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult LogMessage([FromBody] LogMessageDetail message)
        {
            _logger.LogInformation($"{nameof(LogManagerController)} called with message {message.Message}");
            
            return Ok();
        }
    }
}