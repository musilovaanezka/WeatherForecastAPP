using System.Text;
using System.Text.Json;
using WeatherForecastAPP.Interfaces;

namespace WeatherForecastAPP.Services
{
    public interface IApiClientService
    {
        Task<T> PostAsync<T>(string endpoint, object data);
        Task<T> GetAsync<T>(string endpoint, Dictionary<string, string>? parameters = null);
    }
    public class ApiClientService : BaseApiClientService, IApiClientService
	{
		public ApiClientService(HttpClient client) : base(client, Constants.APIRestUrl) { }

		public async Task<T> PostAsync<T>(string endpoint, object data)
		{
			try
			{
				var json = JsonSerializer.Serialize(data);
				var content = new StringContent(json, Encoding.UTF8, "application/json");
				var response = await _client.PostAsync(endpoint, content);
				return await HandleResponse<T>(response);
			} catch (Exception e)
			{
                throw new Exception("Error in ApiClientService.PostAsync", e);
            }
		}
	}
}
