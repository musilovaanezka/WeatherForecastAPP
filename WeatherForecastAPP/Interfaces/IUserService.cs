using WeatherForecastAPP.Model;

namespace WeatherForecastAPP.Interfaces
{
	public interface IUserService
	{
		public Task<bool> SignUpAsync(User user);
		public Task<bool> SignInAsync(User user);
	}
}
