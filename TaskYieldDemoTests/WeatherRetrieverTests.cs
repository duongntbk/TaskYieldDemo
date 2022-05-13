using System;
using System.Threading;
using System.Threading.Tasks;
using FakeItEasy;
using TaskYieldDemo.DataRepo;
using TaskYieldDemo.Service;
using Xunit;

namespace TaskYieldDemoTests
{
    public class WeatherRetrieverTests
    {
        [Fact]
        public async Task FirstTest()
        {
            // Arrange
            var weatherModel = new WeatherModel();
            var reader = A.Fake<IDataReader>();
            A.CallTo(() => reader.ReadAsync()).ReturnsLazily(async () =>
            {
                await Task.Yield();
                return weatherModel;
            });

            var writer = A.Fake<IDataWriter>();

            var sut = new WeatherRetriever(reader, writer);

            // Act
            var cts = new CancellationTokenSource();
            var initTask = sut.InitializeAsync(cts.Token);
            await Task.Delay(200);
            cts.Cancel();
            await initTask;

            // Assert
            A.CallTo(() => writer.WriteAsync(weatherModel)).MustHaveHappened();
        }
    }
}
