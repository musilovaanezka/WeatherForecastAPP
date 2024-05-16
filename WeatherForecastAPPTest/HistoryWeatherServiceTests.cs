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
    public class HistoryWeatherServiceTests
    {
        private readonly Mock<IHistoryWeatherApiClientService> _mockApiClientService;
        private readonly HistoryWeatherService _historyWeatherService;

        public HistoryWeatherServiceTests()
        {
            _mockApiClientService = new Mock<IHistoryWeatherApiClientService>();
            _historyWeatherService = new HistoryWeatherService(_mockApiClientService.Object);
        }

        [Fact]
        public async Task GetHistoryWeatherAsync_ReturnsWeatherHistory()
        {
            // Arrange
            var city = new City { Coord = new Coordinates { Lat = 1.2345678, Lon = 9.8765432 } };
            var expectedWeatherHistory = new WeatherHistory();

            _mockApiClientService
                .Setup(service => service.GetAsync<WeatherHistory>(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>()))
                .ReturnsAsync(expectedWeatherHistory);

            // Act
            var result = await _historyWeatherService.GetHistoryWeatherAsync(city);

            // Assert
            Assert.Equal(expectedWeatherHistory, result);
        }

        [Fact]
        public async Task GetHistoryWeatherAsync_ThrowsException_ReturnsNull()
        {
            // Arrange
            var city = new City { Coord = new Coordinates { Lat = 1.2345678, Lon = 9.8765432 } };

            _mockApiClientService
                .Setup(service => service.GetAsync<WeatherHistory>(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>()))
                .ThrowsAsync(new Exception());

            // Act
            var result = await _historyWeatherService.GetHistoryWeatherAsync(city);

            // Assert
            Assert.Null(result);
        }
    }
}
