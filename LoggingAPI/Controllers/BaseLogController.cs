using System;
using Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LoggingAPI.Controllers
{
    public abstract class BaseLogController : ControllerBase
    {
        private readonly ILogger _logger;

        protected BaseLogController(ILogger<SimpleLogController> logger)
        {
            _logger = logger;
        }
        
        protected object LogMessageAndGetResult(LogMessageDetail messageDetail)
        {
            var logLevel = messageDetail.GetLogLevel();
            _logger.Log(logLevel, "level: {logLevel}, detail: {messageDetail}", logLevel, messageDetail);
            
            return new
            {
                LogLevel = $"{(int)logLevel} {logLevel}",
                DateTime = DateTime.Now,
                Detail = messageDetail
            };
        }
    }
}