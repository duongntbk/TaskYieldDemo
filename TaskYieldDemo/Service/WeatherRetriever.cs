﻿using System.Threading;
using System.Threading.Tasks;
using TaskYieldDemo.DataRepo;

namespace TaskYieldDemo.Service
{
    public class WeatherRetriever : IWeatherRetriever
    {
        private readonly IDataReader _reader;
        private readonly IDataWriter _writer;

        public WeatherRetriever(IDataReader reader, IDataWriter writer)
        {
            _reader = reader;
            _writer = writer;
        }

        public async Task InitializeAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var currentWeather = await _reader.ReadAsync();
                await _writer.WriteAsync(currentWeather);
            }
        }
    }
}