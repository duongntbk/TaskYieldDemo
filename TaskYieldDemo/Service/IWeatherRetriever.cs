using System.Threading;
using System.Threading.Tasks;

namespace TaskYieldDemo.Service
{
    public interface IWeatherRetriever
    {
        Task InitializeAsync(CancellationToken stoppingToken);
    }
}
