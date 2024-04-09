using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WeatherForecastAPP.Interfaces;
using WeatherForecastAPP.Model;
using WeatherForecastAPP.Services;
using static System.Net.WebRequestMethods;

namespace WeatherForecastAPP.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;
		private readonly ICityService _cityService;
		private readonly IUserService _userService;
		private readonly ICurrentWeatherService _currentWeatherService;
		private readonly IWeatherIconsService _weatherIconsService;
		private readonly IHourlyWeatherForecastService _hourlyForecastService;

		public IndexModel(
			ILogger<IndexModel> logger, 
			ICityService cityService, 
			IUserService userService, 
			ICurrentWeatherService currentWeatherService,
			IWeatherIconsService weatherIconsService,
			IHourlyWeatherForecastService hourlyWeatherForecastService)
		{
			_logger = logger;
			_cityService = cityService;
			_userService = userService;
			_currentWeatherService = currentWeatherService;
			_weatherIconsService = weatherIconsService;
			_hourlyForecastService = hourlyWeatherForecastService;
		}

		public City CurrentCity { get; private set; }
		public List<City> Cities { get; private set; }
		public CurrentWeather CurrentWeather {  get; private set; }

        public WeatherForecast WeatherForecastHourly { get; private set; }

        public async Task OnGetAsync()
		{
			try
			{
				var cities = await _cityService.GetAsync("»·slav", null, null);
				CurrentCity = cities[0];
				CurrentWeather = await _currentWeatherService.GetCurrentWeatherAsync(CurrentCity);
				WeatherForecastHourly = await _hourlyForecastService.GetHourlyWeatherForecastAsync(CurrentCity);
			} 
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error occurred while fetching cities");
			}

		}

		public async Task<IActionResult> OnPostNewCity(string city)
		{
			try
			{
				var cities = await _cityService.GetAsync(city, null, null);
				if (cities.Count == 1)
				{
					CurrentCity = cities[0];
                    CurrentWeather = await _currentWeatherService.GetCurrentWeatherAsync(CurrentCity);
                    WeatherForecastHourly = await _hourlyForecastService.GetHourlyWeatherForecastAsync(CurrentCity);
                }
				else
				{
					Cities = cities;
				}
				return Page();
			}
			catch (Exception ex)
			{
                _logger.LogError(ex, "Error occurred while fetching cities");
                return BadRequest("Error occurred while fetching cities");
            }
		}

		[BindProperty]
		public long SelectedCityId { get; set; }

		public async Task<IActionResult> OnPostFromCities()
		{
			try
			{
				var selectedCity = await _cityService.GetByIdAsync(SelectedCityId);
				if (selectedCity != null)
				{
					CurrentCity = selectedCity;
                    CurrentWeather = await _currentWeatherService.GetCurrentWeatherAsync(CurrentCity);
                    WeatherForecastHourly = await _hourlyForecastService.GetHourlyWeatherForecastAsync(CurrentCity);
                }
			}
			catch (Exception ex)
			{
                _logger.LogError(ex, "Error occurred while selecting city");
            }
			return Page();
		}
        public string GetIcon(string icon, int? zoom = null)
        {
			// adding icon of current weather by its url address - zoom = 2x
			return _weatherIconsService.GetIconUrlAsync(icon, zoom);
		}
	}
}
