using Moq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecastAPP.Model;
using WeatherForecastAPP.Services;
using WeatherForecastAPP.Interfaces;
using WeatherForecastAPP;

namespace WeatherForecastAPPTest
{
    public class CurrentWeatherServiceTests
    {
        private readonly Mock<ICurrentWeatherApiClientService> _mockApiClientService;
        private readonly CurrentWeatherService _currentWeatherService;

        public CurrentWeatherServiceTests()
        {
            _mockApiClientService = new Mock<ICurrentWeatherApiClientService>();
            _currentWeatherService = new CurrentWeatherService(_mockApiClientService.Object);
        }

        [Fact]
        public async Task GetCurrentWeatherAsync_ReturnsCurrentWeather()
        {
            // Arrange
            var city = new City
            {
                Coord = new Coordinates { Lat = 40.7128, Lon = -74.0060 }
            };

            var expectedWeather = new CurrentWeather
            {
            };

            var parameters = new Dictionary<string, string>
            {
                { "appid", Constants.WeatherAPIKey },
                { "lat", city.Coord.Lat.ToString("0.00000000", CultureInfo.InvariantCulture) },
                { "lon", city.Coord.Lon.ToString("0.00000000", CultureInfo.InvariantCulture) },
                { "units", "metric" }
            };

            _mockApiClientService
                .Setup(service => service.GetAsync<CurrentWeather>(Constants.WeatherAPIDataCurrentWeatherEndpoint, parameters))
                .ReturnsAsync(expectedWeather);

            // Act
            var result = await _currentWeatherService.GetCurrentWeatherAsync(city);

            // Assert
            Assert.Equal(expectedWeather, result);
        }

        [Fact]
        public async Task GetCurrentWeatherAsync_ReturnsNull_OnException()
        {
            // Arrange
            var city = new City
            {
                Coord = new Coordinates { Lat = 40.7128, Lon = -74.0060 } 
            };

            var parameters = new Dictionary<string, string>
            {
                { "appid", Constants.WeatherAPIKey },
                { "lat", city.Coord.Lat.ToString("0.00000000", CultureInfo.InvariantCulture) },
                { "lon", city.Coord.Lon.ToString("0.00000000", CultureInfo.InvariantCulture) },
                { "units", "metric" }
            };

            _mockApiClientService
                .Setup(service => service.GetAsync<CurrentWeather>(Constants.WeatherAPIDataCurrentWeatherEndpoint, parameters))
                .ThrowsAsync(new Exception("API call failed"));

            // Act
            var result = await _currentWeatherService.GetCurrentWeatherAsync(city);

            // Assert
            Assert.Null(result);
        }
    }
}
