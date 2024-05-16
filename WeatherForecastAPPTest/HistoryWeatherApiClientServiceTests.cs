using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecastAPP.Services;

namespace WeatherForecastAPPTest
{
    public class HistoryWeatherApiClientServiceTests
    {
        [Fact]
        public void Constructor_CreatesInstance()
        {
            // Arrange
            var client = new HttpClient();

            // Act
            var service = new HistoryWeatherApiClientService(client);

            // Assert
            Assert.NotNull(service);
        }
    }
}
