using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecastAPP.Services;

namespace WeatherForecastAPPTest
{
    public class CurrentWeatherApiClientServiceTests
    {
        [Fact]
        public void Constructor_CreatesInstance()
        {
            Environment.SetEnvironmentVariable("WEATHER_API_BASE_URL", "http://api.openweathermap.org");
            Environment.SetEnvironmentVariable("WEATHER_API_DATA_ENDPOINT", "data");
            Environment.SetEnvironmentVariable("WEATHER_API_DATA_ENDPOINT_VERSION", "2.5");

            // Arrange
            var client = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:5000/")
            };

            // Act
            var service = new CurrentWeatherApiClientService(client);

            // Assert
            Assert.NotNull(service);
        }
    }
}
