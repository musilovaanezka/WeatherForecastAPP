using System.Globalization;
using WeatherForecastAPP.Interfaces;
using WeatherForecastAPP.Model;

namespace WeatherForecastAPP.Services
{
    public class HistoryWeatherService : IHistoryWeatherService
    {
        private readonly IHistoryWeatherApiClientService _apiClientService;

        public HistoryWeatherService(IHistoryWeatherApiClientService apiClientService)
        {
            _apiClientService = apiClientService;
        }
        public async Task<WeatherHistory> GetHistoryWeatherAsync(City city)
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

                var response = await _apiClientService.GetAsync<WeatherHistory>(Constants.WeatherHistoryAPICityEndpoint, parameters);
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

    public class HistoryWeatherApiClientService :  BaseApiClientService, IHistoryWeatherApiClientService
    {
        public HistoryWeatherApiClientService(HttpClient client) : base(client, 
            $"{Environment.GetEnvironmentVariable("WEATHER_HISTORY_API_BASE_URL")}" +
            $"/{Environment.GetEnvironmentVariable("WEATHER_HISTORY_API_DATA_ENDPOINT")}" +
            $"/{Environment.GetEnvironmentVariable("WEATHER_HISTORY_API_DATA_ENDPOINT_VERSION")}" +
            $"/{Environment.GetEnvironmentVariable("WEATHER_HISTORY_API_CITY_ENDPOINT")}/") { }
    }

    public interface IHistoryWeatherApiClientService : IBaseApiClientService
    {
    }
}
