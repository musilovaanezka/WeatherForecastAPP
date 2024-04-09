using WeatherForecastAPP.Model;

namespace WeatherForecastAPP.Interfaces
{
	public interface ICityService
	{
		public Task<List<City>> GetAsync(string? name, string? country, string? state);

		public Task<City> GetByIdAsync(long id);
	}
}
