using System.Threading.Tasks;

namespace TaskYieldDemo.DataRepo
{
    public interface IDataWriter
    {
        Task WriteAsync(WeatherModel model);
    }
}
