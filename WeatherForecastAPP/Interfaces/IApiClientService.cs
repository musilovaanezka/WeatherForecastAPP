namespace WeatherForecastAPP.Interfaces
{
    public interface IApiClientService : IBaseApiClientService
    {
        public Task<T> PostAsync<T>(string endpoint, object data);
    }
}
