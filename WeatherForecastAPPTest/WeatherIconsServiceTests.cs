using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecastAPP;
using WeatherForecastAPP.Services;

namespace WeatherForecastAPPTest
{
    public class WeatherIconsServiceTests
    {
        private readonly WeatherIconsService _weatherIconsService;

        public WeatherIconsServiceTests()
        {
            _weatherIconsService = new WeatherIconsService();
        }

        [Fact]
        public void GetIconUrlAsync_ReturnsCorrectUrl_WhenZoomIsNull()
        {
            // Arrange
            var icon = "testIcon";

            // Act
            var result = _weatherIconsService.GetIconUrlAsync(icon);

            // Assert
            Assert.Equal(Constants.BaseImgWeatherAPIUrl + icon + ".png", result);
        }

        [Fact]
        public void GetIconUrlAsync_ReturnsCorrectUrl_WhenZoomIsNotNull()
        {
            // Arrange
            var icon = "testIcon";
            var zoom = 2;

            // Act
            var result = _weatherIconsService.GetIconUrlAsync(icon, zoom);

            // Assert
            Assert.Equal(Constants.BaseImgWeatherAPIUrl + icon + "@" + zoom.ToString() + "x.png", result);
        }
    }
}
