using System;
using System.Threading;
using System.Threading.Tasks;
using Infrastructure.Services;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly ILoggingService _loggingService;

        public Worker(ILogger<Worker> logger, ILoggingService loggingService)
        {
            _logger = logger;
            _loggingService = loggingService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var message = $"Worker running at: {DateTimeOffset.Now}";
                _loggingService.AddLoggingMessage(message);
                _logger.LogInformation(message);
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
