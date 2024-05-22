using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecastAPP.Model;

namespace WeatherForecastAPPTest
{
    public class ModelTests
    {
        [Fact]
        public void City_GettersAndSetters_WorkCorrectly()
        {
            // Arrange
            var city = new City();

            // Set values
            city.Id = 1;
            city.Name = "TestCity";
            city.State = "TestState";
            city.Country = "TestCountry";
            var coord = new Coordinates { Lat = 10.0, Lon = 20.0 };
            city.Coord = coord;

            // Assert
            Assert.Equal(1, city.Id);
            Assert.Equal("TestCity", city.Name);
            Assert.Equal("TestState", city.State);
            Assert.Equal("TestCountry", city.Country);
            Assert.Equal(10.0, city.Coord.Lat);
            Assert.Equal(20.0, city.Coord.Lon);
        }
        [Fact]
        public void CurrentWeather_GettersAndSetters_WorkCorrectly()
        {
            // Arrange
            var currentWeather = new CurrentWeather();
            var coord = new Coordinates { Lat = 10.0, Lon = 20.0 };
            var weather = new Weather[] { new Weather() };
            var mainWeather = new MainWeather();
            var wind = new Wind();
            var clouds = new Clouds();
            var sys = new CurrentWeatherSys();
            var rain = new Rain();
            var snow = new Snow();

            // Set values
            currentWeather.Coord = coord;
            currentWeather.Weather = weather;
            currentWeather.Base = "TestBase";
            currentWeather.Main = mainWeather;
            currentWeather.Visibility = 1000;
            currentWeather.Wind = wind;
            currentWeather.Clouds = clouds;
            currentWeather.Dt = 1621686000;
            currentWeather.Sys = sys;
            currentWeather.Timezone = 3600;
            currentWeather.Id = 2643743;
            currentWeather.Name = "London";
            currentWeather.Cod = 200;
            currentWeather.Rain = rain;
            currentWeather.Snow = snow;

            // Assert
            Assert.Equal(coord, currentWeather.Coord);
            Assert.Equal(weather, currentWeather.Weather);
            Assert.Equal("TestBase", currentWeather.Base);
            Assert.Equal(mainWeather, currentWeather.Main);
            Assert.Equal(1000, currentWeather.Visibility);
            Assert.Equal(wind, currentWeather.Wind);
            Assert.Equal(clouds, currentWeather.Clouds);
            Assert.Equal(1621686000, currentWeather.Dt);
            Assert.Equal(sys, currentWeather.Sys);
            Assert.Equal(3600, currentWeather.Timezone);
            Assert.Equal(2643743, currentWeather.Id);
            Assert.Equal("London", currentWeather.Name);
            Assert.Equal(200, currentWeather.Cod);
            Assert.Equal(rain, currentWeather.Rain);
            Assert.Equal(snow, currentWeather.Snow);
        }
    }

    public class CurrentWeatherSysTests
    {
        [Fact]
        public void CurrentWeatherSys_GettersAndSetters_WorkCorrectly()
        {
            // Arrange
            var currentWeatherSys = new CurrentWeatherSys();

            // Set values
            currentWeatherSys.Type = 1;
            currentWeatherSys.Id = 123;
            currentWeatherSys.Country = "US";
            currentWeatherSys.Sunrise = 1621686000;
            currentWeatherSys.Sunset = 1621728000;

            // Assert
            Assert.Equal(1, currentWeatherSys.Type);
            Assert.Equal(123, currentWeatherSys.Id);
            Assert.Equal("US", currentWeatherSys.Country);
            Assert.Equal(1621686000, currentWeatherSys.Sunrise);
            Assert.Equal(1621728000, currentWeatherSys.Sunset);
        }
    }

    public class DailyWeatherForecastTests
    {
        [Fact]
        public void DailyWeatherForecast_GettersAndSetters_WorkCorrectly()
        {
            // Arrange
            var dailyWeatherForecast = new DailyWeatherForecast();
            var city = new DailyWeatherForecastCity();
            var list = new DailyWeatherForecastList[] { new DailyWeatherForecastList() };

            // Set values
            dailyWeatherForecast.Cod = "200";
            dailyWeatherForecast.Message = 1.0;
            dailyWeatherForecast.Cnt = 5;
            dailyWeatherForecast.List = list;
            dailyWeatherForecast.City = city;

            // Assert
            Assert.Equal("200", dailyWeatherForecast.Cod);
            Assert.Equal(1.0, dailyWeatherForecast.Message);
            Assert.Equal(5, dailyWeatherForecast.Cnt);
            Assert.Equal(list, dailyWeatherForecast.List);
            Assert.Equal(city, dailyWeatherForecast.City);
        }
    }

    public class DailyWeatherForecastCityTests
    {
        [Fact]
        public void DailyWeatherForecastCity_GettersAndSetters_WorkCorrectly()
        {
            // Arrange
            var city = new DailyWeatherForecastCity();

            // Set values
            city.Id = 123;
            city.Name = "London";
            city.Coordinates = new Coordinates { Lat = 10.0, Lon = 20.0 };
            city.Country = "UK";
            city.Population = 1000000;
            city.Timezone = 3600;

            // Assert
            Assert.Equal(123, city.Id);
            Assert.Equal("London", city.Name);
            Assert.Equal(10.0, city.Coordinates.Lat);
            Assert.Equal(20.0, city.Coordinates.Lon);
            Assert.Equal("UK", city.Country);
            Assert.Equal(1000000, city.Population);
            Assert.Equal(3600, city.Timezone);
        }
    }

    public class DailyWeatherForecastListTests
    {
        [Fact]
        public void DailyWeatherForecastList_GettersAndSetters_WorkCorrectly()
        {
            // Arrange
            var list = new DailyWeatherForecastList();

            // Set values
            list.Dt = 1621686000;
            list.Sunrise = 1621686000;
            list.Sunset = 1621728000;
            list.Temp = new DailyWeatherForecastTemp { Day = 20.0 };
            list.FeelsLike = new DailyWeatherForecastFeelsLike { Day = 22.0 };
            list.Pressure = 1000;
            list.Humidity = 70;
            list.Weather = new Weather[] { new Weather() };
            list.speed = 5.0;
            list.Deg = 90;
            list.Gust = 7.0;
            list.Clouds = 20;
            list.Pop = 0.5;
            list.Rain = 5.0;

            // Assert
            Assert.Equal(1621686000, list.Dt);
            Assert.Equal(1621686000, list.Sunrise);
            Assert.Equal(1621728000, list.Sunset);
            Assert.Equal(20.0, list.Temp.Day);
            Assert.Equal(22.0, list.FeelsLike.Day);
            Assert.Equal(1000, list.Pressure);
            Assert.Equal(70, list.Humidity);
            Assert.Equal(5.0, list.speed);
            Assert.Equal(90, list.Deg);
            Assert.Equal(7.0, list.Gust);
            Assert.Equal(20, list.Clouds);
            Assert.Equal(0.5, list.Pop);
            Assert.Equal(5.0, list.Rain);
        }
    }

    public class DailyWeatherForecastTempTests
    {
        [Fact]
        public void DailyWeatherForecastTemp_GettersAndSetters_WorkCorrectly()
        {
            // Arrange
            var temp = new DailyWeatherForecastTemp();

            // Set values
            temp.Day = 20.0;
            temp.Min = 15.0;
            temp.Max = 25.0;
            temp.Night = 18.0;
            temp.Eve = 22.0;
            temp.Morn = 16.0;

            // Assert
            Assert.Equal(20.0, temp.Day);
            Assert.Equal(15.0, temp.Min);
            Assert.Equal(25.0, temp.Max);
            Assert.Equal(18.0, temp.Night);
            Assert.Equal(22.0, temp.Eve);
            Assert.Equal(16.0, temp.Morn);
        }
    }

    public class DailyWeatherForecastFeelsLikeTests
    {
        [Fact]
        public void DailyWeatherForecastFeelsLike_GettersAndSetters_WorkCorrectly()
        {
            // Arrange
            var feelsLike = new DailyWeatherForecastFeelsLike();

            // Set values
            feelsLike.Day = 22.0;
            feelsLike.Night = 18.0;
            feelsLike.Eve = 24.0;
            feelsLike.Morn = 20.0;

            // Assert
            Assert.Equal(22.0, feelsLike.Day);
            Assert.Equal(18.0, feelsLike.Night);
            Assert.Equal(24.0, feelsLike.Eve);
            Assert.Equal(20.0, feelsLike.Morn);
        }
    }

    public class UserTests
    {
        [Fact]
        public void User_GettersAndSetters_WorkCorrectly()
        {
            // Arrange
            var user = new User();

            // Set values
            user.Username = "testUser";
            user.Password = "testPassword";

            // Assert
            Assert.Equal("testUser", user.Username);
            Assert.Equal("testPassword", user.Password);
        }
    }

    public class RainTests
    {
        [Fact]
        public void Rain_GettersAndSetters_WorkCorrectly()
        {
            // Arrange
            var rain = new Rain();

            // Set values
            rain.Hour = 10.5;
            rain.ThreeHours = 20.3;

            // Assert
            Assert.Equal(10.5, rain.Hour);
            Assert.Equal(20.3, rain.ThreeHours);
        }
    }

    public class CloudsTests
    {
        [Fact]
        public void Clouds_GettersAndSetters_WorkCorrectly()
        {
            // Arrange
            var clouds = new Clouds();

            // Set value
            clouds.All = 50;

            // Assert
            Assert.Equal(50, clouds.All);
        }
    }

    public class SnowTests
    {
        [Fact]
        public void Snow_GettersAndSetters_WorkCorrectly()
        {
            // Arrange
            var snow = new Snow();

            // Set values
            snow.Hour = 5.0;
            snow.ThreeHours = 10.0;

            // Assert
            Assert.Equal(5.0, snow.Hour);
            Assert.Equal(10.0, snow.ThreeHours);
        }
    }

    public class MainWeatherTests
    {
        [Fact]
        public void MainWeather_GettersAndSetters_WorkCorrectly()
        {
            // Arrange
            var mainWeather = new MainWeather();

            // Set values
            mainWeather.Temp = 25.0;
            mainWeather.FeelsLike = 27.0;
            mainWeather.TempMin = 20.0;
            mainWeather.TempMax = 30.0;
            mainWeather.Pressure = 1000;
            mainWeather.SeaLevel = 1010;
            mainWeather.GrndLevel = 990;
            mainWeather.Humidity = 70;

            // Assert
            Assert.Equal(25.0, mainWeather.Temp);
            Assert.Equal(27.0, mainWeather.FeelsLike);
            Assert.Equal(20.0, mainWeather.TempMin);
            Assert.Equal(30.0, mainWeather.TempMax);
            Assert.Equal(1000, mainWeather.Pressure);
            Assert.Equal(1010, mainWeather.SeaLevel);
            Assert.Equal(990, mainWeather.GrndLevel);
            Assert.Equal(70, mainWeather.Humidity);
        }
    }

    public class WeatherTests
    {
        [Fact]
        public void Weather_GettersAndSetters_WorkCorrectly()
        {
            // Arrange
            var weather = new Weather();

            // Set values
            weather.Id = 800;
            weather.Main = "Clear";
            weather.Description = "clear sky";
            weather.Icon = "01d";

            // Assert
            Assert.Equal(800, weather.Id);
            Assert.Equal("Clear", weather.Main);
            Assert.Equal("clear sky", weather.Description);
            Assert.Equal("01d", weather.Icon);
        }
    }

    public class WindTests
    {
        [Fact]
        public void Wind_GettersAndSetters_WorkCorrectly()
        {
            // Arrange
            var wind = new Wind();

            // Set values
            wind.Speed = 5.0;
            wind.Deg = 90;

            // Assert
            Assert.Equal(5.0, wind.Speed);
            Assert.Equal(90, wind.Deg);
        }
    }

    public class WeatherForecastTests
    {
        [Fact]
        public void WeatherForecast_GettersAndSetters_WorkCorrectly()
        {
            // Arrange
            var weatherForecast = new WeatherForecast();

            // Set values
            weatherForecast.Cod = "200";
            weatherForecast.Message = 100;
            weatherForecast.Cnt = 5;
            weatherForecast.List = new WeatherForecastList[] { new WeatherForecastList() };
            weatherForecast.City = new WeatherForecastCity();

            // Assert
            Assert.Equal("200", weatherForecast.Cod);
            Assert.Equal(100, weatherForecast.Message);
            Assert.Equal(5, weatherForecast.Cnt);
            Assert.Single(weatherForecast.List);
            Assert.NotNull(weatherForecast.City);
        }
    }

    public class WeatherForecastListTests
    {
        [Fact]
        public void WeatherForecastList_GettersAndSetters_WorkCorrectly()
        {
            // Arrange
            var weatherForecastList = new WeatherForecastList();

            // Set values
            weatherForecastList.Dt = 1621728000;
            weatherForecastList.Main = new MainWeather();
            weatherForecastList.Weather = new Weather[] { new Weather() };
            weatherForecastList.Clouds = new Clouds();
            weatherForecastList.Wind = new Wind();
            weatherForecastList.Visibility = 10000;
            weatherForecastList.Pop = 0.5;
            weatherForecastList.Sys = new WeatherForecastSys();
            weatherForecastList.DxTxt = "2022-05-23 12:00:00";

            // Assert
            Assert.Equal(1621728000, weatherForecastList.Dt);
            Assert.NotNull(weatherForecastList.Main);
            Assert.Single(weatherForecastList.Weather);
            Assert.NotNull(weatherForecastList.Clouds);
            Assert.NotNull(weatherForecastList.Wind);
            Assert.Equal(10000, weatherForecastList.Visibility);
            Assert.Equal(0.5, weatherForecastList.Pop);
            Assert.NotNull(weatherForecastList.Sys);
            Assert.Equal("2022-05-23 12:00:00", weatherForecastList.DxTxt);
        }
    }

    public class WeatherForecastCityTests
    {
        [Fact]
        public void WeatherForecastCity_GettersAndSetters_WorkCorrectly()
        {
            // Arrange
            var weatherForecastCity = new WeatherForecastCity();

            // Set values
            weatherForecastCity.Id = 123;
            weatherForecastCity.Name = "London";
            weatherForecastCity.Coordinates = new Coordinates();
            weatherForecastCity.Country = "UK";
            weatherForecastCity.Population = 1000000;
            weatherForecastCity.Timezone = 3600;
            weatherForecastCity.Sunrise = 1621686000;
            weatherForecastCity.Sunset = 1621728000;

            // Assert
            Assert.Equal(123, weatherForecastCity.Id);
            Assert.Equal("London", weatherForecastCity.Name);
            Assert.NotNull(weatherForecastCity.Coordinates);
            Assert.Equal("UK", weatherForecastCity.Country);
            Assert.Equal(1000000, weatherForecastCity.Population);
            Assert.Equal(3600, weatherForecastCity.Timezone);
            Assert.Equal(1621686000, weatherForecastCity.Sunrise);
            Assert.Equal(1621728000, weatherForecastCity.Sunset);
        }
    }

    public class WeatherForecastSysTests
    {
        [Fact]
        public void WeatherForecastSys_GettersAndSetters_WorkCorrectly()
        {
            // Arrange
            var weatherForecastSys = new WeatherForecastSys();

            // Set value
            weatherForecastSys.Pod = "d";

            // Assert
            Assert.Equal("d", weatherForecastSys.Pod);
        }
    }

    public class WeatherHistoryTests
    {
        [Fact]
        public void WeatherHistory_GettersAndSetters_WorkCorrectly()
        {
            // Arrange
            var weatherHistory = new WeatherHistory();

            // Set values
            weatherHistory.Message = "Test message";
            weatherHistory.Cod = "200";
            weatherHistory.CityId = 12345;
            weatherHistory.Calctime = 1621691400.5;
            weatherHistory.Cnt = 3;

            // Assert
            Assert.Equal("Test message", weatherHistory.Message);
            Assert.Equal("200", weatherHistory.Cod);
            Assert.Equal(12345, weatherHistory.CityId);
            Assert.Equal(1621691400.5, weatherHistory.Calctime);
            Assert.Equal(3, weatherHistory.Cnt);
        }
    }

    public class WeatherHistoryListTests
    {
        [Fact]
        public void WeatherHistoryList_GettersAndSetters_WorkCorrectly()
        {
            // Arrange
            var weatherHistoryList = new WeatherHistoryList();

            // Set values
            weatherHistoryList.Dt = 1621691400;
            weatherHistoryList.Main = new WeatherHistoryMain();
            weatherHistoryList.Wind = new WeatherHistoryWind();
            weatherHistoryList.Clouds = new Clouds();
            weatherHistoryList.Weather = new Weather[] { new Weather() };
            weatherHistoryList.Rain = new Rain();

            // Assert
            Assert.Equal(1621691400, weatherHistoryList.Dt);
            Assert.NotNull(weatherHistoryList.Main);
            Assert.NotNull(weatherHistoryList.Wind);
            Assert.NotNull(weatherHistoryList.Clouds);
            Assert.NotNull(weatherHistoryList.Weather);
            Assert.NotNull(weatherHistoryList.Rain);
        }
    }

    public class WeatherHistoryMainTests
    {
        [Fact]
        public void WeatherHistoryMain_GettersAndSetters_WorkCorrectly()
        {
            // Arrange
            var weatherHistoryMain = new WeatherHistoryMain();

            // Set values
            weatherHistoryMain.Temp = 25.5;
            weatherHistoryMain.FeelsLike = 27.3;
            weatherHistoryMain.Pressure = 1000;
            weatherHistoryMain.Humidity = 80;
            weatherHistoryMain.TempMin = 20.5;
            weatherHistoryMain.TempMax = 30.5;

            // Assert
            Assert.Equal(25.5, weatherHistoryMain.Temp);
            Assert.Equal(27.3, weatherHistoryMain.FeelsLike);
            Assert.Equal(1000, weatherHistoryMain.Pressure);
            Assert.Equal(80, weatherHistoryMain.Humidity);
            Assert.Equal(20.5, weatherHistoryMain.TempMin);
            Assert.Equal(30.5, weatherHistoryMain.TempMax);
        }
    }

    public class WeatherHistoryWindTests
    {
        [Fact]
        public void WeatherHistoryWind_GettersAndSetters_WorkCorrectly()
        {
            // Arrange
            var weatherHistoryWind = new WeatherHistoryWind();

            // Set values
            weatherHistoryWind.Speed = 5.5;
            weatherHistoryWind.Deg = 180.0;
            weatherHistoryWind.Gust = 7.0;

            // Assert
            Assert.Equal(5.5, weatherHistoryWind.Speed);
            Assert.Equal(180.0, weatherHistoryWind.Deg);
            Assert.Equal(7.0, weatherHistoryWind.Gust);
        }
    }
}