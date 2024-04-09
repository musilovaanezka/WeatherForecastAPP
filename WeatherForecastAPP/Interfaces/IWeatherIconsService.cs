using WeatherForecastAPP.Model;

namespace WeatherForecastAPP.Interfaces
{
    public interface IWeatherIconsService
    {
        public string GetIconUrlAsync(string icon, int? zoom = null);
    }
}
