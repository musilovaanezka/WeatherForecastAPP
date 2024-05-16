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
    public class DailyWeatherForecastServiceTests
    {
        private readonly DailyWeatherForecastService _dailyWeatherForecastService;
        private readonly Mock<IDailyWeatherForecastApiClientService> _apiClientServiceMock;

        public DailyWeatherForecastServiceTests()
        {
            _apiClientServiceMock = new Mock<IDailyWeatherForecastApiClientService>();
            _dailyWeatherForecastService = new DailyWeatherForecastService(_apiClientServiceMock.Object);
        }

        [Fact]
        public async Task GetDailyWeatherForecastAsync_ReturnsCorrectResponse()
        {
            // Arrange
            var city = new City
            {
                Coord = new Coordinates
                {
                    Lat = 1.23,
                    Lon = 4.56
                }
            };

            var expectedResponse = new DailyWeatherForecast
            {
                // Fill in the expected properties here
            };

            _apiClientServiceMock
                .Setup(service => service.GetAsync<DailyWeatherForecast>(
                    It.IsAny<string>(),
                    It.IsAny<Dictionary<string, string>>()))
                .ReturnsAsync(expectedResponse);

            // Act
            var result = await _dailyWeatherForecastService.GetDailyWeatherForecastAsync(city);

            // Assert
            Assert.Equal(expectedResponse, result);
        }

        [Fact]
        public async Task GetDailyWeatherForecastAsync_ReturnsNull_WhenExceptionIsThrown()
        {
            // Arrange
            var city = new City
            {
                Coord = new Coordinates
                {
                    Lat = 1.23,
                    Lon = 4.56
                }
            };

            _apiClientServiceMock
                .Setup(service => service.GetAsync<DailyWeatherForecast>(
                    It.IsAny<string>(),
                    It.IsAny<Dictionary<string, string>>()))
                .ThrowsAsync(new Exception());

            // Act
            var result = await _dailyWeatherForecastService.GetDailyWeatherForecastAsync(city);

            // Assert
            Assert.Null(result);
        }

    }
}
