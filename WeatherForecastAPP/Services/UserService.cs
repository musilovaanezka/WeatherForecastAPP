using Microsoft.AspNetCore.Mvc;
using WeatherForecastAPP.Interfaces;
using WeatherForecastAPP.Model;

namespace WeatherForecastAPP.Services
{
	public class UserService : IUserService
	{
		private readonly ApiClientService _apiClientService;
		private const string Controller = "users";
		public UserService(ApiClientService apiClientService)
		{
			_apiClientService = apiClientService;
		}
		public async Task<bool> SignInAsync(User user)
		{
			try
			{
				var response = await _apiClientService.PostAsync<User>(Controller + "/signin", user);
				return true;
			}
			catch (Exception ex)
			{
				return false;
			}
		}

		public async Task<bool> SignUpAsync(User user)
		{
			try
			{
				var response = await _apiClientService.PostAsync<User>(Controller + "/signup", user);
				return true;
			} 
			catch (Exception ex)
			{
				return false;
			}
		}
	}
}
