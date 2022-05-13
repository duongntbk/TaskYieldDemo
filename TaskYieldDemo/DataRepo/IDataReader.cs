using System.Threading.Tasks;

namespace TaskYieldDemo.DataRepo
{
    public interface IDataReader
    {
        Task<WeatherModel> ReadAsync();
    }
}
