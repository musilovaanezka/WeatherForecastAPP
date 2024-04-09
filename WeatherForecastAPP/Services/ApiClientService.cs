using System.Text;
using System.Text.Json;
using WeatherForecastAPP.Interfaces;

namespace WeatherForecastAPP.Services
{
	public class ApiClientService : BaseApiClientService
	{
		//private readonly HttpClient _client;

		public ApiClientService(HttpClient client) : base(client, Constants.APIRestUrl) { }

		public async Task<T> PostAsync<T>(string endpoint, object data)
		{
			var json = JsonSerializer.Serialize(data);
			var content = new StringContent(json, Encoding.UTF8, "application/json");
			var response = await _client.PostAsync(endpoint, content);
			return await HandleResponse<T>(response);
		}
	}
}
