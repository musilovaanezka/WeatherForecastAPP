using Microsoft.AspNetCore.Mvc;
using WeatherForecastAPP.Interfaces;
using WeatherForecastAPP.Model;

namespace WeatherForecastAPP.Services
{
    public class WeatherIconsService : IWeatherIconsService
    {
        public string GetIconUrlAsync(string icon, int? zoom = null)
        {
            return Constants.BaseImgWeatherAPIUrl + icon + (zoom.HasValue ? "@" + zoom.ToString() + "x" : "") + ".png";
        }
    }
}
