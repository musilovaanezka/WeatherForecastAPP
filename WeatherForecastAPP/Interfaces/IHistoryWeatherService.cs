using WeatherForecastAPP.Model;

namespace WeatherForecastAPP.Interfaces
{
    public interface IHistoryWeatherService
    {
        public Task<WeatherHistory> GetHistoryWeatherAsync(City city);
    }
}
