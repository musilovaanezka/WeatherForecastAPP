using System.Globalization;
using WeatherForecastAPP.Interfaces;
using WeatherForecastAPP.Model;

namespace WeatherForecastAPP.Services
{
    public class CurrentWeatherService : ICurrentWeatherService
    {
        private readonly ICurrentWeatherApiClientService _apiClientService;

        public CurrentWeatherService(ICurrentWeatherApiClientService apiClientService)
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

    public class CurrentWeatherApiClientService : BaseApiClientService, ICurrentWeatherApiClientService
    {
        public CurrentWeatherApiClientService(HttpClient client) : base(client, $"{Environment.GetEnvironmentVariable("WEATHER_API_BASE_URL")}" +
            $"/{Environment.GetEnvironmentVariable("WEATHER_API_DATA_ENDPOINT")}" +
            $"/{Environment.GetEnvironmentVariable("WEATHER_API_DATA_ENDPOINT_VERSION")}/") { }
    }
}
