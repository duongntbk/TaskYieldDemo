using System;
using System.Threading.Tasks;

namespace TaskYieldDemo.DataRepo
{
    internal class DummyDataWriter : IDataWriter
    {
        public async Task WriteAsync(WeatherModel model)
        {
            await Task.Delay(500); // Simulate a slow running process
            Console.WriteLine(
                $"Current weather: {model.DegreeInCelcius:0.00} C, " +
                $"{model.RainProbability:0.00}% chance of raining, wind speed " +
                $"{model.WindMetrePerHour:0.00} mph.");
        }
    }
}
