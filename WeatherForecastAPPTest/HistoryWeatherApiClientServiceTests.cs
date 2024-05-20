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
            Environment.SetEnvironmentVariable("WEATHER_HISTORY_API_BASE_URL", "http://history.openweathermap.org");
            Environment.SetEnvironmentVariable("WEATHER_HISTORY_API_DATA_ENDPOINT", "data");
            Environment.SetEnvironmentVariable("WEATHER_HISTORY_API_DATA_ENDPOINT_VERSION", "2.5");
            Environment.SetEnvironmentVariable("WEATHER_HISTORY_API_CITY_ENDPOINT", "city");

            // Arrange
            var client = new HttpClient();

            // Act
            var service = new HistoryWeatherApiClientService(client);

            // Assert
            Assert.NotNull(service);
        }
    }
}
