using WeatherForecastAPP.Model;

namespace WeatherForecastAPP.Interfaces
{
    public interface ICurrentWeatherService
    {
        public Task<CurrentWeather> GetCurrentWeatherAsync(City city);
    }
}
