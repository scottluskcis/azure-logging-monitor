using System;
using Microsoft.Extensions.Logging;

namespace Logging
{
    public class LogMessageDetail
    {
        public string Message { get; set; }
        public string Severity { get; set; }

        public LogLevel GetLogLevel()
        {
            return Enum.TryParse<LogLevel>(Severity, true, out var logLevel) ? logLevel : LogLevel.Debug;
        }
    }
}
