using System.Globalization;
using WeatherForecastAPP.Interfaces;
using WeatherForecastAPP.Model;

namespace WeatherForecastAPP.Services
{
    public class HourlyWeatherForecastService : IHourlyWeatherForecastService
    {
        private readonly IHourlyWeatherForecastApiClientService _apiClientService;

        public HourlyWeatherForecastService(IHourlyWeatherForecastApiClientService apiClientService)
        {
            _apiClientService = apiClientService;
        }

        public async Task<WeatherForecast> GetHourlyWeatherForecastAsync(City city)
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

                var response = await _apiClientService.GetAsync<WeatherForecast>(Constants.WeatherAPIForecastHourlyEndpoint, parameters);
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

    public class HourlyWeatherForecastApiClientService : BaseApiClientService, IHourlyWeatherForecastApiClientService
    {
        public HourlyWeatherForecastApiClientService(HttpClient client) : base(client,
            $"{Environment.GetEnvironmentVariable("WEATHER_API_PRO_BASE_URL")}" +
            $"/{Environment.GetEnvironmentVariable("WEATHER_API_DATA_ENDPOINT")}" +
            $"/{Environment.GetEnvironmentVariable("WEATHER_API_DATA_ENDPOINT_VERSION")}" +
            $"/{Environment.GetEnvironmentVariable("WEATHER_API_FORECAST_ENDPOINT")}/") { }
    }

    public interface IHourlyWeatherForecastApiClientService : IBaseApiClientService
    {
    }
}
