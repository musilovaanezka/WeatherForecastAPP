﻿using System.Globalization;
using WeatherForecastAPP.Interfaces;
using WeatherForecastAPP.Model;

namespace WeatherForecastAPP.Services
{
    public class DailyWeatherForecastService : IDailyWeatherForecastService
    {
        private readonly IDailyWeatherForecastApiClientService _apiClientService;

        public DailyWeatherForecastService(IDailyWeatherForecastApiClientService apiClientService)
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

    public class DailyWeatherForecastApiClientService : BaseApiClientService, IDailyWeatherForecastApiClientService
    {
        public DailyWeatherForecastApiClientService(HttpClient client) : base(client, ($"{Environment.GetEnvironmentVariable("WEATHER_API_PRO_BASE_URL")}" +
            $"/{Environment.GetEnvironmentVariable("WEATHER_API_DATA_ENDPOINT")}" +
            $"/{Environment.GetEnvironmentVariable("WEATHER_API_DATA_ENDPOINT_VERSION")}" +
            $"/{Environment.GetEnvironmentVariable("WEATHER_API_FORECAST_ENDPOINT")}/")) { }
    }

    public interface IDailyWeatherForecastApiClientService : IBaseApiClientService
    {
    }
}
