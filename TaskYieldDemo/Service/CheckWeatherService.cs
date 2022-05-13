using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace TaskYieldDemo.Service
{
    internal class CheckWeatherService : BackgroundService
    {
        private readonly IWeatherRetriever _weatherRetriever;
        private readonly IHostApplicationLifetime _hostApplicationLifetime;

        public CheckWeatherService(IWeatherRetriever weatherRetriever,
            IHostApplicationLifetime hostApplicationLifetime)
        {
            _weatherRetriever = weatherRetriever;
            _hostApplicationLifetime = hostApplicationLifetime;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine($"Starting {nameof(CheckWeatherService)}...");
            return base.StartAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                await _weatherRetriever.InitializeAsync(stoppingToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while starting {nameof(CheckWeatherService)}: {ex.Message}");
                _hostApplicationLifetime.StopApplication();
            }
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine($"Stopping {nameof(CheckWeatherService)}...");
            return base.StopAsync(cancellationToken);
        }
    }
}
