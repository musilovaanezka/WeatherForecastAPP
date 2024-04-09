namespace WeatherForecastAPP.Interfaces
{
    public interface IBaseApiClientService
    {
        public Task<T> GetAsync<T>(string endpoint, Dictionary<string, string>? parameters = null);
    }
}
