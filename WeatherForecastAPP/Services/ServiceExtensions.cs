using WeatherForecastAPP.Interfaces;

namespace WeatherForecastAPP.Services
{
	public static class ServiceExtensions
	{
		public static IServiceCollection AddServices(this IServiceCollection services)
		{
			return services
				.AddSingleton<IBaseApiClientService, BaseApiClientService>()
				.AddSingleton<IApiClientService, ApiClientService>()
				.AddSingleton<ICityService, CityService>()
				.AddSingleton<IUserService, UserService>()
				.AddSingleton<ICurrentWeatherService, CurrentWeatherService>()
				.AddSingleton<ICurrentWeatherApiClientService, CurrentWeatherApiClientService>()
				.AddSingleton<IWeatherIconsService, WeatherIconsService>()
				.AddSingleton<IHourlyWeatherForecastService, HourlyWeatherForecastService>()
				.AddSingleton<IHourlyWeatherForecastApiClientService, HourlyWeatherForecastApiClientService>()
				.AddSingleton<IDailyWeatherForecastService, DailyWeatherForecastService>()
				.AddSingleton<IDailyWeatherForecastApiClientService, DailyWeatherForecastApiClientService>()
				.AddSingleton<IHistoryWeatherService, HistoryWeatherService>()
				.AddSingleton<IHistoryWeatherApiClientService, HistoryWeatherApiClientService>();
		}
	}
}
