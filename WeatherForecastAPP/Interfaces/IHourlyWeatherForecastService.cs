using WeatherForecastAPP.Model;


namespace WeatherForecastAPP.Interfaces
{
    public interface IHourlyWeatherForecastService
    {
        public Task<WeatherForecast> GetHourlyWeatherForecastAsync(City city); 
    }
}
