using System;
using Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LoggingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimpleLogController : BaseLogController
    {
        public SimpleLogController(ILogger<SimpleLogController> logger)
        : base(logger) { }

        [HttpPost]
        public IActionResult LogMessage([FromBody] LogMessageDetail messageDetail)
        { 
            return Ok(LogMessageAndGetResult(messageDetail));
        } 
    }
}