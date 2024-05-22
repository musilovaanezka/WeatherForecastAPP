using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Session;
using Microsoft.Extensions.DependencyInjection;
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
        private readonly DefaultHttpContext _httpContext;

        public IndexModelTests()
        {
            _mockLogger = new Mock<ILogger<IndexModel>>();
            _mockCityService = new Mock<ICityService>();
            _mockUserService = new Mock<IUserService>();
            _mockCurrentWeatherService = new Mock<ICurrentWeatherService>();
            _mockWeatherIconsService = new Mock<IWeatherIconsService>();
            _mockHourlyForecastService = new Mock<IHourlyWeatherForecastService>();
            _mockDailyWeatherForecastService = new Mock<IDailyWeatherForecastService>();
            _httpContext = new DefaultHttpContext();
            _mockHistoryWeatherService = new Mock<IHistoryWeatherService>();
            _httpContext = new DefaultHttpContext();
            _httpContext.Features.Set<ISessionFeature>(new SessionFeature());

            var session = new Mock<ISession>();

            session.Setup(s => s.Set(It.IsAny<string>(), It.IsAny<byte[]>()));
            session.Setup(s => s.Remove(It.IsAny<string>()));

            session.Setup(s => s.TryGetValue(It.Is<string>(key => key == "IsAuthenticated"), out It.Ref<byte[]>.IsAny)).Returns(true);

            _httpContext.Features.Set<ISessionFeature>(new SessionFeature { Session = session.Object });


            _indexModel = new IndexModel(
                _mockLogger.Object,
                _mockCityService.Object,
                _mockUserService.Object,
                _mockCurrentWeatherService.Object,
                _mockWeatherIconsService.Object,
                _mockHourlyForecastService.Object,
                _mockDailyWeatherForecastService.Object,
                _mockHistoryWeatherService.Object)
            {
                PageContext = new PageContext
                {
                    HttpContext = _httpContext
                }
            };
        }

        [Fact]
        public async Task OnGetAsync_ShouldLoadDataCorrectly()
        {
            // Arrange
            var cities = new List<City> { new City { Id = 1, Name = "City1" } };
            _mockCityService.Setup(service => service.GetAsync(It.IsAny<string>(), null, null)).ReturnsAsync(cities);

            // Act
            await _indexModel.OnGetAsync();

            // Assert
            Assert.NotNull(_indexModel.CurrentCity);
        }

        [Fact]
        public void GetIcon_ShouldReturnIconUrl()
        {
            // Arrange
            var icon = "01d";
            var zoom = 2;
            var expectedUrl = "http://example.com/icon.png";
            _mockWeatherIconsService.Setup(service => service.GetIconUrlAsync(icon, zoom)).Returns(expectedUrl);

            // Act
            var result = _indexModel.GetIcon(icon, zoom);

            // Assert
            Assert.Equal(expectedUrl, result);
        }

        [Fact]
        public async Task SetData_ShouldSetDataCorrectly()
        {
            // Arrange
            var city = new City { Id = 1, Name = "City1" };
            var currentWeather = new CurrentWeather();
            var hourlyForecast = new WeatherForecast();
            var dailyForecast = new DailyWeatherForecast();
            var historicalData = new WeatherHistory();

            _indexModel.CurrentCity = city;
            _mockCurrentWeatherService.Setup(service => service.GetCurrentWeatherAsync(city)).ReturnsAsync(currentWeather);
            _mockHourlyForecastService.Setup(service => service.GetHourlyWeatherForecastAsync(city)).ReturnsAsync(hourlyForecast);
            _mockDailyWeatherForecastService.Setup(service => service.GetDailyWeatherForecastAsync(city)).ReturnsAsync(dailyForecast);
            _mockHistoryWeatherService.Setup(service => service.GetHistoryWeatherAsync(city)).ReturnsAsync(historicalData);
            _indexModel.IsAuthenticated = true;
            // Act
            await _indexModel.SetData();

            // Assert
            Assert.NotNull(_indexModel.CurrentWeather);
            Assert.NotNull(_indexModel.WeatherForecastHourly);
            Assert.NotNull(_indexModel.WeatherForecastDaily);
            Assert.NotNull(_indexModel.HistoricalData);
        }

        [Fact]
        public async Task SetData_ShouldSetDataLoadedFalse_WhenCurrentCityIsNull()
        {
            // Arrange
            _indexModel.CurrentCity = null;

            // Act
            await _indexModel.SetData();

            // Assert
            Assert.False(_indexModel.DataLoaded);
        }

        [Fact]
        public async Task OnPostFromCities_ShouldSetCurrentCityAndCallSetData_WhenCityIsFound()
        {
            // Arrange
            var city = new City { Id = 1, Name = "City1" };
            _indexModel.SelectedCityId = 1;
            _mockCityService.Setup(service => service.GetByIdAsync(1)).ReturnsAsync(city);
            _mockCurrentWeatherService.Setup(service => service.GetCurrentWeatherAsync(It.IsAny<City>())).ReturnsAsync(new CurrentWeather());
            _mockHourlyForecastService.Setup(service => service.GetHourlyWeatherForecastAsync(It.IsAny<City>())).ReturnsAsync(new WeatherForecast());
            _mockDailyWeatherForecastService.Setup(service => service.GetDailyWeatherForecastAsync(It.IsAny<City>())).ReturnsAsync(new DailyWeatherForecast());
            _mockHistoryWeatherService.Setup(service => service.GetHistoryWeatherAsync(It.IsAny<City>())).ReturnsAsync(new WeatherHistory());

            // Act
            var result = await _indexModel.OnPostFromCities();

            // Assert
            Assert.NotNull(_indexModel.CurrentCity);
            Assert.Equal(city, _indexModel.CurrentCity);
            _mockLogger.Verify(
                x => x.Log(
                    It.IsAny<LogLevel>(),
                    It.IsAny<EventId>(),
                    It.IsAny<It.IsAnyType>(),
                    It.IsAny<Exception>(),
                    (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()),
                Times.Never
            );
            Assert.IsType<PageResult>(result);
        }

        [Fact]
        public async Task OnPostFromCities_ShouldLogError_WhenExceptionIsThrown()
        {
            // Arrange
            _indexModel.SelectedCityId = 1;
            var exception = new Exception("Test exception");
            _mockCityService.Setup(service => service.GetByIdAsync(1)).ThrowsAsync(exception);

            // Act
            var result = await _indexModel.OnPostFromCities();

            // Assert
            _mockLogger.Verify(
                x => x.Log(
                    It.IsAny<LogLevel>(),
                    It.IsAny<EventId>(),
                    It.IsAny<It.IsAnyType>(),
                    It.IsAny<Exception>(),
                    (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()),
                Times.Once
            );
            Assert.IsType<PageResult>(result);
        }

        [Fact]
        public async Task OnPostFromCities_ShouldReturnPageResult()
        {
            // Arrange
            _indexModel.SelectedCityId = 1;
            _mockCityService.Setup(service => service.GetByIdAsync(1)).ReturnsAsync(new City { Id = 1, Name = "City1" });

            // Act
            var result = await _indexModel.OnPostFromCities();

            // Assert
            Assert.IsType<PageResult>(result);
        }

        [Fact]
        public async Task OnPostNewCity_ShouldSetCurrentCityAndCallSetData_WhenSingleCityIsFound()
        {
            // Arrange
            var city = new City { Id = 1, Name = "City1" };
            var cities = new List<City> { city };
            _mockCityService.Setup(service => service.GetAsync("City1", null, null)).ReturnsAsync(cities);
            _mockCurrentWeatherService.Setup(service => service.GetCurrentWeatherAsync(city)).ReturnsAsync(new CurrentWeather());
            _mockHourlyForecastService.Setup(service => service.GetHourlyWeatherForecastAsync(city)).ReturnsAsync(new WeatherForecast());
            _mockDailyWeatherForecastService.Setup(service => service.GetDailyWeatherForecastAsync(city)).ReturnsAsync(new DailyWeatherForecast());
            _mockHistoryWeatherService.Setup(service => service.GetHistoryWeatherAsync(city)).ReturnsAsync(new WeatherHistory());

            // Act
            var result = await _indexModel.OnPostNewCity("City1");

            // Assert
            Assert.NotNull(_indexModel.CurrentCity);
            Assert.Equal(city, _indexModel.CurrentCity);
            _mockLogger.Verify(
                x => x.Log(
                    It.IsAny<LogLevel>(),
                    It.IsAny<EventId>(),
                    It.IsAny<It.IsAnyType>(),
                    It.IsAny<Exception>(),
                    (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()),
                Times.Never
            );
            Assert.IsType<PageResult>(result);
        }

        [Fact]
        public async Task OnPostNewCity_ShouldSetCities_WhenMultipleCitiesAreFound()
        {
            // Arrange
            var cities = new List<City>
            {
                new City { Id = 1, Name = "City1" },
                new City { Id = 2, Name = "City2" }
            };
            _mockCityService.Setup(service => service.GetAsync("City", null, null)).ReturnsAsync(cities);

            // Act
            var result = await _indexModel.OnPostNewCity("City");

            // Assert
            Assert.Null(_indexModel.CurrentCity);
            Assert.NotNull(_indexModel.Cities);
            Assert.Equal(2, _indexModel.Cities.Count);
            Assert.IsType<PageResult>(result);
        }

        [Fact]
        public async Task OnPostNewCity_ShouldLogError_WhenExceptionIsThrown()
        {
            // Arrange
            var exception = new Exception("Test exception");
            _mockCityService.Setup(service => service.GetAsync("City1", null, null)).ThrowsAsync(exception);

            // Act
            var result = await _indexModel.OnPostNewCity("City1");

            // Assert
            _mockLogger.Verify(
                x => x.Log(
                    LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.IsAny<It.IsAnyType>(),
                    exception,
                    (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()),
                Times.Once
            );
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task OnGetAsync_ShouldLogError_WhenExceptionIsThrown()
        {
            // Arrange
            var exception = new Exception("Test exception");
            _mockCityService.Setup(service => service.GetAsync(It.IsAny<string>(), null, null)).ThrowsAsync(exception);

            // Act
            await _indexModel.OnGetAsync();

            // Assert
            _mockLogger.Verify(
                x => x.Log(
                    LogLevel.Error,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Error occurred while fetching cities")),
                    exception,
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                Times.Once
            );
        }
    }
}
