using System.Globalization;
using WeatherForecastAPP.Interfaces;
using WeatherForecastAPP.Model;

namespace WeatherForecastAPP.Services
{
    public class DailyWeatherForecastService : IDailyWeatherForecastService
    {
        private readonly DailyWeatherForecastApiClientService _apiClientService;

        public DailyWeatherForecastService(DailyWeatherForecastApiClientService apiClientService)
        {
            _apiClientService = apiClientService;
        }

        public async Task<DailyWeatherForecast> GetDailyWeatherForecastAsync(City city)
        {
            try
            {
                var parameters = new Dictionary<string, string>
                {
                    { "appid", Constants.WeatherAPIKey },
                    { "lat", city.Coord.Lat.ToString("0.00000000", CultureInfo.InvariantCulture) },
                    { "lon", city.Coord.Lon.ToString("0.00000000", CultureInfo.InvariantCulture) },
                    { "cnt", "16" },
                    { "units", "metric" }
                };

                var response = await _apiClientService.GetAsync<DailyWeatherForecast>(Constants.WeatherAPIForecastDailyEndpoint, parameters);
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

    public class DailyWeatherForecastApiClientService : BaseApiClientService
    {
        public DailyWeatherForecastApiClientService(HttpClient client) : base(client, Constants.BaseDailyForecastWeatherAPIUrl) { }
    }
}
