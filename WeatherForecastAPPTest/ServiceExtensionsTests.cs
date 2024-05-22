using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecastAPP.Interfaces;
using WeatherForecastAPP.Services;

namespace WeatherForecastAPPTest
{
    public class ServiceExtensionsTests
    {
        [Fact]
        public void AddServices_RegistersServices()
        {
            Environment.SetEnvironmentVariable("AMUSIL_API", "http://pro.openweathermap.org");
            Environment.SetEnvironmentVariable("WEATHER_API_BASE_URL", "http://pro.openweathermap.org");
            Environment.SetEnvironmentVariable("WEATHER_API_PRO_BASE_URL", "http://pro.openweathermap.org");
            Environment.SetEnvironmentVariable("WEATHER_MAP_BASE_URL", "http://pro.openweathermap.org");
            Environment.SetEnvironmentVariable("WEATHER_HISTORY_API_BASE_URL", "http://history.openweathermap.org");
            Environment.SetEnvironmentVariable("WEATHER_API_DATA_ENDPOINT", "data");
            Environment.SetEnvironmentVariable("WEATHER_API_DATA_ENDPOINT_VERSION", "data");
            Environment.SetEnvironmentVariable("WEATHER_API_DATA_CURRENT_WEATHER_ENDPOINT", "data");
            Environment.SetEnvironmentVariable("WEATHER_API_IMG_ENDPOINT", "data");
            Environment.SetEnvironmentVariable("WEATHER_API_FORECAST_ENDPOINT", "data");
            Environment.SetEnvironmentVariable("WEATHER_API_FORECAST_HOURLY_ENDPOINT", "data");
            Environment.SetEnvironmentVariable("WEATHER_API_FORECAST_DAILY_ENDPOINT", "data");
            Environment.SetEnvironmentVariable("WEATHER_HISTORY_API_DATA_ENDPOINT", "data");
            Environment.SetEnvironmentVariable("WEATHER_HISTORY_API_DATA_ENDPOINT_VERSION", "data");
            Environment.SetEnvironmentVariable("WEATHER_HISTORY_API_DATA_HISTORY_ENDPOINT", "data");
            Environment.SetEnvironmentVariable("WEATHER_HISTORY_API_CITY_ENDPOINT", "data");

            // Arrange
            var services = new ServiceCollection();
            services.AddSingleton(new HttpClient());

            // Act
            services.AddServices();
            var provider = services.BuildServiceProvider();

            // Assert
            Assert.NotNull(provider.GetService<IBaseApiClientService>());
            Assert.NotNull(provider.GetService<IApiClientService>());
            Assert.NotNull(provider.GetService<ICityService>());
            Assert.NotNull(provider.GetService<IUserService>());
            Assert.NotNull(provider.GetService<ICurrentWeatherService>());
            Assert.NotNull(provider.GetService<ICurrentWeatherApiClientService>());
            Assert.NotNull(provider.GetService<IWeatherIconsService>());
            Assert.NotNull(provider.GetService<IHourlyWeatherForecastService>());
            Assert.NotNull(provider.GetService<IHourlyWeatherForecastApiClientService>());
            Assert.NotNull(provider.GetService<IDailyWeatherForecastService>());
            Assert.NotNull(provider.GetService<IDailyWeatherForecastApiClientService>());
            Assert.NotNull(provider.GetService<IHistoryWeatherApiClientService>());
        }
    }
}
