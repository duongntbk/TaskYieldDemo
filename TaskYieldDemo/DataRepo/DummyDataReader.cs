using System;
using System.Threading.Tasks;

namespace TaskYieldDemo.DataRepo
{
    internal class DummyDataReader : IDataReader
    {
        private readonly Random _random;

        public DummyDataReader() => _random = new Random();

        public Task<WeatherModel> ReadAsync()
        {
            return Task.FromResult(new WeatherModel
            {
                DegreeInCelcius = _random.NextDouble() * 30,
                RainProbability = _random.NextDouble() * 100,
                WindMetrePerHour = _random.NextDouble() * 10
            });
        }
    }
}
