using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace TaskYieldDemo.Service
{
    internal class CheckWeatherService : BackgroundService
    {
        private readonly IWeatherRetriever _weatherRetriever;

        public CheckWeatherService(IWeatherRetriever weatherRetriever) => _weatherRetriever = weatherRetriever;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine($"Starting {nameof(CheckWeatherService)}...");
            await _weatherRetriever.InitializeAsync(stoppingToken);
            Console.WriteLine($"Stopping {nameof(CheckWeatherService)}...");
        }
    }
}
