﻿using WeatherForecastAPP.Interfaces;

namespace WeatherForecastAPP.Services
{
	public static class ServiceExtensions
	{
		public static IServiceCollection AddServices(this IServiceCollection services)
		{
			return services
				.AddSingleton<IBaseApiClientService, BaseApiClientService>()
				.AddSingleton<ApiClientService>()
				.AddSingleton<ICityService, CityService>()
				.AddSingleton<IUserService, UserService>()
				.AddSingleton<ICurrentWeatherService, CurrentWeatherService>()
				.AddSingleton<CurrentWeatherApiClientService>()
				.AddSingleton<IWeatherIconsService, WeatherIconsService>()
				.AddSingleton<IHourlyWeatherForecastService, HourlyWeatherForecastService>()
				.AddSingleton<HourlyWeatherForecastApiClientService>()
				.AddSingleton<IDailyWeatherForecastService, DailyWeatherForecastService>()
				.AddSingleton<DailyWeatherForecastApiClientService>()
				.AddSingleton<IHistoryWeatherService, HistoryWeatherService>()
				.AddSingleton<HistoryWeatherApiClientService>();
		}
	}
}
