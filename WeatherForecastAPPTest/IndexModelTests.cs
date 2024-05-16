using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecastAPP.Interfaces;
using WeatherForecastAPP.Model;
using WeatherForecastAPP.Pages;

namespace WeatherForecastAPPTest
{
    public class IndexModelTests
    {
        private readonly Mock<ILogger<IndexModel>> _mockLogger;
        private readonly Mock<ICityService> _mockCityService;
        private readonly Mock<IUserService> _mockUserService;
        private readonly Mock<ICurrentWeatherService> _mockCurrentWeatherService;
        private readonly Mock<IWeatherIconsService> _mockWeatherIconsService;
        private readonly Mock<IHourlyWeatherForecastService> _mockHourlyForecastService;
        private readonly Mock<IDailyWeatherForecastService> _mockDailyWeatherForecastService;
        private readonly Mock<IHistoryWeatherService> _mockHistoryWeatherService;
        private readonly IndexModel _indexModel;

        public IndexModelTests()
        {
            _mockLogger = new Mock<ILogger<IndexModel>>();
            _mockCityService = new Mock<ICityService>();
            _mockUserService = new Mock<IUserService>();
            _mockCurrentWeatherService = new Mock<ICurrentWeatherService>();
            _mockWeatherIconsService = new Mock<IWeatherIconsService>();
            _mockHourlyForecastService = new Mock<IHourlyWeatherForecastService>();
            _mockDailyWeatherForecastService = new Mock<IDailyWeatherForecastService>();
            _mockHistoryWeatherService = new Mock<IHistoryWeatherService>();
            _indexModel = new IndexModel(
                _mockLogger.Object,
                _mockCityService.Object,
                _mockUserService.Object,
                _mockCurrentWeatherService.Object,
                _mockWeatherIconsService.Object,
                _mockHourlyForecastService.Object,
                _mockDailyWeatherForecastService.Object,
                _mockHistoryWeatherService.Object);
        }

        [Fact]
        public async Task OnGetAsync_SetsCurrentCity()
        {
            // Arrange
            var expectedCity = new City { Id = 1, Name = "Čáslav", Country = "TestCountry", Coord = new Coordinates { Lat = 1.0, Lon = 1.0 } };
            _mockCityService
                .Setup(service => service.GetAsync("Čáslav", null, null))
                .ReturnsAsync(new List<City> { expectedCity });

            // Act
            await _indexModel.OnGetAsync();

            // Assert
            Assert.Equal(expectedCity, _indexModel.CurrentCity);
        }

        [Fact]
        public async Task OnPostNewCity_SetsCurrentCity_WhenOneCityIsReturned()
        {
            // Arrange
            var expectedCity = new City { Id = 2, Name = "AnotherCity", Country = "AnotherCountry", Coord = new Coordinates { Lat = 2.0, Lon = 2.0 } };
            _mockCityService
                .Setup(service => service.GetAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(new List<City> { expectedCity });

            // Act
            var result = await _indexModel.OnPostNewCity("TestCity");

            // Assert
            Assert.Equal(expectedCity, _indexModel.CurrentCity);
            Assert.IsType<PageResult>(result);
        }

        [Fact]
        public async Task OnPostNewCity_SetsCities_WhenMultipleCitiesAreReturned()
        {
            // Arrange
            var expectedCities = new List<City>
    {
        new City { Id = 3, Name = "City1", Country = "Country1", Coord = new Coordinates { Lat = 3.0, Lon = 3.0 } },
        new City { Id = 4, Name = "City2", Country = "Country2", Coord = new Coordinates { Lat = 4.0, Lon = 4.0 } }
    };
            _mockCityService
                .Setup(service => service.GetAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(expectedCities);

            // Act
            var result = await _indexModel.OnPostNewCity("TestCity");

            // Assert
            Assert.Equal(expectedCities, _indexModel.Cities);
            Assert.IsType<PageResult>(result);
        }

        [Fact]
        public async Task OnPostFromCities_SetsCurrentCity_WhenCityIsFound()
        {
            // Arrange
            var expectedCity = new City { Id = 5, Name = "FoundCity", Country = "FoundCountry", Coord = new Coordinates { Lat = 5.0, Lon = 5.0 } };
            _mockCityService
                .Setup(service => service.GetByIdAsync(It.IsAny<long>()))
                .ReturnsAsync(expectedCity);

            // Act
            var result = await _indexModel.OnPostFromCities();

            // Assert
            Assert.Equal(expectedCity, _indexModel.CurrentCity);
            Assert.IsType<PageResult>(result);
        }
    }
}
