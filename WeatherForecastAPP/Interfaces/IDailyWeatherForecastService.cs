using WeatherForecastAPP.Model;

namespace WeatherForecastAPP.Interfaces
{
    public interface IDailyWeatherForecastService
    {
        public Task<DailyWeatherForecast> GetDailyWeatherForecastAsync(City city);
    }
}
