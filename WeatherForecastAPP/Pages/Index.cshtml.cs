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
		private readonly IDailyWeatherForecastService _dailyWeatherForecastService;
		private readonly IHistoryWeatherService _historyWeatherService;

		public IndexModel(
			ILogger<IndexModel> logger, 
			ICityService cityService, 
			IUserService userService, 
			ICurrentWeatherService currentWeatherService,
			IWeatherIconsService weatherIconsService,
			IHourlyWeatherForecastService hourlyWeatherForecastService,
			IDailyWeatherForecastService dailyWeatherForecastService,
			IHistoryWeatherService historyWeatherService)
		{
			_logger = logger;
			_cityService = cityService;
			_userService = userService;
			_currentWeatherService = currentWeatherService;
			_weatherIconsService = weatherIconsService;
			_hourlyForecastService = hourlyWeatherForecastService;
			_dailyWeatherForecastService = dailyWeatherForecastService;
			_historyWeatherService = historyWeatherService;
		}


		public bool DataLoaded { get; private set; } = true;
		public City CurrentCity { get; private set; }
		public List<City> Cities { get; private set; }
		public CurrentWeather CurrentWeather {  get; private set; }
        public WeatherForecast WeatherForecastHourly { get; private set; }
		public DailyWeatherForecast WeatherForecastDaily { get; private set; }
		public WeatherHistory HistoricalData {  get; private set; }
		public bool IsAuthenticated { get; set; } = false;

        public async Task OnGetAsync()
		{
			try
			{
                IsAuthenticated = HttpContext.Session.GetString("IsAuthenticated") == "true";

                var cities = await _cityService.GetAsync("»·slav", null, null);
				CurrentCity = cities.FirstOrDefault();
				await SetData();
            } 
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error occurred while fetching cities");
			}

		}

		public async Task<IActionResult> OnPostNewCity(string city)
		{
            IsAuthenticated = HttpContext.Session.GetString("IsAuthenticated") == "true";
            try
			{
				var cities = await _cityService.GetAsync(city, null, null);
				if (cities.Count == 1)
				{
					CurrentCity = cities[0];
                    await SetData();
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
            IsAuthenticated = HttpContext.Session.GetString("IsAuthenticated") == "true";
            try
			{
				var selectedCity = await _cityService.GetByIdAsync(SelectedCityId);
				if (selectedCity != null)
				{
					CurrentCity = selectedCity;
                    await SetData();
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

		private async Task SetData()
		{
			if (CurrentCity == null) 
			{
				DataLoaded = false;
				return; 
			}
            CurrentWeather = await _currentWeatherService.GetCurrentWeatherAsync(CurrentCity);
            WeatherForecastHourly = await _hourlyForecastService.GetHourlyWeatherForecastAsync(CurrentCity);
            WeatherForecastDaily = await _dailyWeatherForecastService.GetDailyWeatherForecastAsync(CurrentCity);

            _logger.LogInformation($"CurrentWeather: {CurrentWeather}");
            _logger.LogInformation($"WeatherForecastHourly: {WeatherForecastHourly}");
            _logger.LogInformation($"WeatherForecastDaily: {WeatherForecastDaily}");


            if (IsAuthenticated)
			{
				HistoricalData = await _historyWeatherService.GetHistoryWeatherAsync(CurrentCity);
                _logger.LogInformation($"HistoricalData: {HistoricalData}");
            }
			if (CurrentWeather == null || WeatherForecastHourly == null || WeatherForecastDaily == null)
			{
				DataLoaded = false;
				return;
			}

            _logger.LogInformation($"WeatherForecastDaily.List: {WeatherForecastDaily.List}");
        }

    }
    }
}
