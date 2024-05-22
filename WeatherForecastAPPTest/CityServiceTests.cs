using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecastAPP.Interfaces;
using WeatherForecastAPP.Model;
using WeatherForecastAPP.Services;
using WeatherForecastAPP.Pages;

namespace WeatherForecastAPPTest
{
    public class CityServiceTests
    {
        private readonly Mock<IApiClientService> _mockApiClientService;
        private readonly CityService _cityService;

        public CityServiceTests()
        {
            _mockApiClientService = new Mock<IApiClientService>();
            _cityService = new CityService(_mockApiClientService.Object);
        }

        [Fact]
        public async Task GetAsync_CallsApiClientServiceWithCorrectParameters()
        {
            // Arrange
            var parameters = new Dictionary<string, string> { { "name", "TestCity" }, { "country", "TestCountry" }, { "state", "TestState" } };

            // Act
            var result = await _cityService.GetAsync("TestCity", "TestCountry", "TestState");

            // Assert
            _mockApiClientService.Verify(service => service.GetAsync<List<City>>("cities", parameters), Times.Once);
        }

        [Fact]
        public async Task GetByIdAsync_CallsApiClientServiceWithCorrectParameters()
        {
            // Arrange
            long id = 1;

            // Act
            var result = await _cityService.GetByIdAsync(id);

            // Assert
            _mockApiClientService.Verify(service => service.GetAsync<City>($"cities/{id}", null), Times.Once);
        }

        [Fact]
        public async Task GetAsync_ThrowsException_ReturnsNull()
        {
            // Arrange
            _mockApiClientService
                .Setup(service => service.GetAsync<List<City>>(It.IsAny<string>(), It.IsAny<Dictionary<string, string>>()))
                .ThrowsAsync(new Exception());

            // Act
            var result = await _cityService.GetAsync("TestCity", "TestCountry", "TestState");

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task GetByIdAsync_ThrowsException_ReturnsNull()
        {
            // Arrange
            long id = 1;
            _mockApiClientService
                .Setup(service => service.GetAsync<City>(It.IsAny<string>(), null))
                .ThrowsAsync(new Exception());

            // Act
            var result = await _cityService.GetByIdAsync(id);

            // Assert
            Assert.Null(result);
        }
    }
}
