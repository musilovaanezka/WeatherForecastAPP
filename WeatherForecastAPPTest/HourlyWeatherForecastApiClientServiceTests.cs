using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecastAPP.Services;

namespace WeatherForecastAPPTest
{
    public class HourlyWeatherForecastApiClientServiceTests
    {
        [Fact]
        public void Constructor_CreatesInstance()
        {
            Environment.SetEnvironmentVariable("WEATHER_API_PRO_BASE_URL", "http://pro.openweathermap.org");
            Environment.SetEnvironmentVariable("WEATHER_API_DATA_ENDPOINT", "data");
            Environment.SetEnvironmentVariable("WEATHER_API_DATA_ENDPOINT_VERSION", "2.5");
            Environment.SetEnvironmentVariable("WEATHER_API_FORECAST_ENDPOINT", "forecast");

            // Arrange
            var client = new HttpClient();

            // Act
            var service = new HourlyWeatherForecastApiClientService(client);

            // Assert
            Assert.NotNull(service);
        }
    }
}
