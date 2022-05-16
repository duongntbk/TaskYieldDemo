using System;
using System.Threading.Tasks;

namespace TaskYieldDemo.DataRepo
{
    internal class DummyDataReader : IDataReader
    {
        private readonly Random _random;

        public DummyDataReader() => _random = new Random();

        public async Task<WeatherModel> ReadAsync()
        {
            await Task.Delay(500); // Simulate a slow running process
            return new WeatherModel
            {
                DegreeInCelcius = _random.NextDouble() * 30,
                RainProbability = _random.NextDouble() * 100,
                WindMetrePerHour = _random.NextDouble() * 10
            };
        }
    }
}
