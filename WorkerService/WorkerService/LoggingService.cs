using System;
using System.Collections.Generic;
using System.Text;

namespace WorkerService
{
    public interface ILoggingService
    {
        string LogMessage();
    }

    public class LoggingService : ILoggingService
    {
        public string LogMessage() => $"Worker running at: {DateTimeOffset.Now}";
    }
}
