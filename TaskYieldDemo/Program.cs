using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaskYieldDemo.DataRepo;
using TaskYieldDemo.Service;

namespace TaskYieldDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host
                .CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services
                        .AddSingleton<IWeatherRetriever, WeatherRetriever>()
                        .AddSingleton<IDataReader, DummyDataReader>()
                        .AddSingleton<IDataWriter, DummyDataWriter>();
                    services.AddHostedService<CheckWeatherService>();
                });
        }
    }
}
