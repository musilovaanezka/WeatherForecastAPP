using System.Globalization;
using WeatherForecastAPP.Interfaces;
using WeatherForecastAPP.Model;

namespace WeatherForecastAPP.Services
{
    public class CurrentWeatherService : ICurrentWeatherService
    {
        private readonly CurrentWeatherApiClientService _apiClientService;

        public CurrentWeatherService(CurrentWeatherApiClientService apiClientService)
        {
            _apiClientService = apiClientService;
        }
        public async Task<CurrentWeather> GetCurrentWeatherAsync(City city)
        {
            try
            {
                var parameters = new Dictionary<string, string>
                {
                    { "appid", Constants.WeatherAPIKey },
                    { "lat", city.Coord.Lat.ToString("0.00000000", CultureInfo.InvariantCulture) },
                    { "lon", city.Coord.Lon.ToString("0.00000000", CultureInfo.InvariantCulture) },
                    { "units", "metric" }
                };

                var response = await _apiClientService.GetAsync<CurrentWeather>(Constants.WeatherAPIDataCurrentWeatherEndpoint, parameters);
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

    public class CurrentWeatherApiClientService : BaseApiClientService
    {
        public CurrentWeatherApiClientService(HttpClient client) : base(client, Constants.BaseCurrentWeatherAPIUrl) { }
    }
}
