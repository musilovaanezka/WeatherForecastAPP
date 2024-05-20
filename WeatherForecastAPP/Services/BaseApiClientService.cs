using System.Text.Json;
using WeatherForecastAPP.Interfaces;

namespace WeatherForecastAPP.Services
{
    public class BaseApiClientService : IBaseApiClientService
    {
        protected readonly HttpClient _client;

        public BaseApiClientService(HttpClient client, string baseAddress = "http://api.openweathermap.org/data/2.5/")
        {
            _client = client;
            _client.BaseAddress = new Uri(baseAddress);
        }
        public async Task<T> GetAsync<T>(string endpoint, Dictionary<string, string>? parameters = null)
        {
            string requestUrl = BuildRequestUrl(endpoint, parameters);

            var response = await _client.GetAsync(requestUrl);
            return await HandleResponse<T>(response);
        }

        protected async Task<T> HandleResponse<T>(HttpResponseMessage response)
        {
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(content);
        }

        protected string BuildRequestUrl(string endpoint, Dictionary<string, string>? parameters = null)
        {
            var requestUrl = endpoint;
            if (parameters != null && parameters.Count > 0)
            {
                var queryString = new FormUrlEncodedContent(parameters).ReadAsStringAsync().Result;
                requestUrl = requestUrl + "?" + queryString;
            }

            return requestUrl;
        }
    }
}
