using Moq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecastAPP.Model;
using WeatherForecastAPP.Services;

namespace WeatherForecastAPPTest
{
    public class HourlyWeatherForecastServiceTests
    {
        private readonly Mock<IHourlyWeatherForecastApiClientService> _mockApiClientService;
        private readonly HourlyWeatherForecastService _hourlyWeatherForecastService;

        public HourlyWeatherForecastServiceTests()
        {
            _mockApiClientService = new Mock<IHourlyWeatherForecastApiClientService>();
            _hourlyWeatherForecastService = new HourlyWeatherForecastService(_mockApiClientService.Object);
        }

        [Fact]
        public async Task GetHourlyWeatherForecastAsync_ReturnsWeatherForecast()
        {
            // Arrange
            var city = new City { Coord = new Coordinates { Lat = 1.2345678, Lon = 9.8765432 } };
            var expectedWeatherForecast = new WeatherForecast();

            _mockApiClientService
                .Setup(service => service.GetAsync<WeatherForecast>(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>()))
                .ReturnsAsync(expectedWeatherForecast);

            // Act
            var result = await _hourlyWeatherForecastService.GetHourlyWeatherForecastAsync(city);

            // Assert
            Assert.Equal(expectedWeatherForecast, result);
        }

        [Fact]
        public async Task GetHourlyWeatherForecastAsync_ThrowsException_ReturnsNull()
        {
            // Arrange
            var city = new City { Coord = new Coordinates { Lat = 1.2345678, Lon = 9.8765432 } };

            _mockApiClientService
                .Setup(service => service.GetAsync<WeatherForecast>(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>()))
                .ThrowsAsync(new Exception());

            // Act
            var result = await _hourlyWeatherForecastService.GetHourlyWeatherForecastAsync(city);

            // Assert
            Assert.Null(result);
        }

    }
}
