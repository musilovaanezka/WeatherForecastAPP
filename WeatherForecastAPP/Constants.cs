using static System.Net.WebRequestMethods;

namespace WeatherForecastAPP
{
	public class Constants
	{
		public static string APIUrl = "localhost";
		public static string APIPort = "7193";
		public static string APIProtocol = "https";

        //public static string APIRestUrl = $"{APIProtocol}://{APIUrl}:{APIPort}/api/";
        //      public static string APIRestUrl = "http://amusil-weather-forecast-440f27844575.herokuapp.com/api/";
        public static string APIRestUrl = Environment.GetEnvironmentVariable("AMUSIL_API");

		//      public static string WeatherAPIKey = "27f5e232e3b11725bc87ed47808bead0";
		public static string WeatherAPIKey = Environment.GetEnvironmentVariable("API_KEY");
		//public static string WeatherAPIBaseUrl = "http://api.openweathermap.org";
		public static string WeatherAPIBaseUrl = Environment.GetEnvironmentVariable("WEATHER_API_BASE_URL");
  //      public static string WeatherAPIProBaseUrl = "http://pro.openweathermap.org";
		public static string WeatherAPIProBaseUrl = Environment.GetEnvironmentVariable("WEATHER_API_PRO_BASE_URL");
  //      public static string WeatherAPPBaseUrl = "http://openweathermap.org";
		public static string WeatherAPPBaseUrl = Environment.GetEnvironmentVariable("WEATHER_MAP_BASE_URL");
  //      public static string WeatherHistoryAPIBaseUrl = "http://history.openweathermap.org";
		public static string WeatherHistoryAPIBaseUrl = Environment.GetEnvironmentVariable("WEATHER_HISTORY_API_BASE_URL");	


  //      public static string WeatherAPIDataEndpoint = "data";
		public static string WeatherAPIDataEndpoint = Environment.GetEnvironmentVariable("WEATHER_API_DATA_ENDPOINT");
		//public static string WeatherAPIDataEndpointVersion = "2.5";
		public static string WeatherAPIDataEndpointVersion = Environment.GetEnvironmentVariable("WEATHER_API_DATA_ENDPOINT_VERSION");
  //      public static string WeatherAPIDataCurrentWeatherEndpoint = "weather";
		public static string WeatherAPIDataCurrentWeatherEndpoint = Environment.GetEnvironmentVariable("WEATHER_API_DATA_CURRENT_WEATHER_ENDPOINT");

        public static string BaseCurrentWeatherAPIUrl = 
			$"{Environment.GetEnvironmentVariable("WEATHER_API_BASE_URL")}" +
			$"/{Environment.GetEnvironmentVariable("WEATHER_API_DATA_ENDPOINT")}" +
			$"/{Environment.GetEnvironmentVariable("WEATHER_API_DATA_ENDPOINT_VERSION")}/";

		//protected static string WeatherAPIImgEndpoint = "img/wn";
		public static string WeatherAPIImgEndpoint = Environment.GetEnvironmentVariable("WEATHER_API_IMG_ENDPOINT");

		public static string BaseImgWeatherAPIUrl = 
			$"{Environment.GetEnvironmentVariable("WEATHER_MAP_BASE_URL")}" +
			$"/{Environment.GetEnvironmentVariable("WEATHER_API_IMG_ENDPOINT")}/";

		//public static string WeatherAPIForecastEndpoint = "forecast";
		public static string WeatherAPIForecastEndpoint = Environment.GetEnvironmentVariable("WEATHER_API_FORECAST_ENDPOINT");
		//public static string WeatherAPIForecastHourlyEndpoint = "hourly";
		public static string WeatherAPIForecastHourlyEndpoint = Environment.GetEnvironmentVariable("WEATHER_API_FORECAST_HOURLY_ENDPOINT");

        public static string BaseHourlyForecastWeatherAPIUrl = 
			$"{Environment.GetEnvironmentVariable("WEATHER_API_PRO_BASE_URL")}" +
			$"/{Environment.GetEnvironmentVariable("WEATHER_API_DATA_ENDPOINT")}" +
			$"/{Environment.GetEnvironmentVariable("WEATHER_API_DATA_ENDPOINT_VERSION")}" +
			$"/{Environment.GetEnvironmentVariable("WEATHER_API_FORECAST_ENDPOINT")}/";

        //public static string WeatherAPIForecastDailyEndpoint = "daily";
		public static string WeatherAPIForecastDailyEndpoint = Environment.GetEnvironmentVariable("WEATHER_API_FORECAST_DAILY_ENDPOINT");

        public static string BaseDailyForecastWeatherAPIUrl = 
			$"{Environment.GetEnvironmentVariable("WEATHER_API_PRO_BASE_URL")}" +
			$"/{Environment.GetEnvironmentVariable("WEATHER_API_DATA_ENDPOINT")}" +
			$"/{Environment.GetEnvironmentVariable("WEATHER_API_DATA_ENDPOINT_VERSION")}" +
			$"/{Environment.GetEnvironmentVariable("WEATHER_API_FORECAST_ENDPOINT")}/";

		//private static string WeatherHistoryAPIDataEndpoint = "data";
		private static string WeatherHistoryAPIDataEndpoint = Environment.GetEnvironmentVariable("WEATHER_HISTORY_API_DATA_ENDPOINT");
  //      private static string WeatherHistoryAPIDataEndpointVersion = "2.5";
		private static string WeatherHistoryAPIDataEndpointVersion = Environment.GetEnvironmentVariable("WEATHER_HISTORY_API_DATA_ENDPOINT_VERSION");
  //      private static string WeatherHistoryAPIHistoryEndpoint = "history";
		private static string WeatherHistoryAPIHistoryEndpoint = Environment.GetEnvironmentVariable("WEATHER_HISTORY_API_DATA_HISTORY_ENDPOINT");
  //      public static string WeatherHistoryAPICityEndpoint = "city";
		public static string WeatherHistoryAPICityEndpoint = Environment.GetEnvironmentVariable("WEATHER_HISTORY_API_CITY_ENDPOINT");

        public static string BaseWeatherAPIHistoryUrl = 
			$"{Environment.GetEnvironmentVariable("WEATHER_HISTORY_API_BASE_URL")}" +
			$"/{Environment.GetEnvironmentVariable("WEATHER_HISTORY_API_DATA_ENDPOINT")}" +
			$"/{Environment.GetEnvironmentVariable("WEATHER_HISTORY_API_DATA_ENDPOINT_VERSION")}" +
			$"/{Environment.GetEnvironmentVariable("WEATHER_HISTORY_API_CITY_ENDPOINT")}/";
    }
}
