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
            Assert.NotNull(provider.GetService<IHistoryWeatherService>());
            Assert.NotNull(provider.GetService<IHistoryWeatherApiClientService>());
        }
    }
}
