using System.Reflection.Metadata.Ecma335;
using WeatherForecastAPP.Interfaces;
using WeatherForecastAPP.Model;

namespace WeatherForecastAPP.Services
{
	public class CityService : ICityService
	{
		private readonly IApiClientService _apiClientService;
		private const string Controller = "cities";

		public CityService(IApiClientService apiClientService)
		{
			_apiClientService = apiClientService;
		}
		public async Task<List<City>> GetAsync(string? name, string? country, string? state)
		{
			try
			{
				var parameters = new Dictionary<string, string>();
				if (!string.IsNullOrEmpty(name)) parameters.Add("name", name);
				if (!string.IsNullOrEmpty(country)) parameters.Add("country", country);
				if (!string.IsNullOrEmpty(state)) parameters.Add("state", state);

				var cities = await _apiClientService.GetAsync<List<City>>(Controller, parameters);
				return cities;
			}
			catch (Exception ex)
			{
				return null;
			}
		}

        public async Task<City> GetByIdAsync(long id)
        {
            try
			{
				var city = await _apiClientService.GetAsync<City>($"{Controller}/{id}", null);
				return city;
            }
			catch (Exception ex)
			{
				return null;
			}
        }
    }
}
