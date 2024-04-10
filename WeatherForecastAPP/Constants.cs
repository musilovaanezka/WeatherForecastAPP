using static System.Net.WebRequestMethods;

namespace WeatherForecastAPP
{
	public class Constants
	{
		public static string APIUrl = "localhost";
		public static string APIPort = "7193";
		public static string APIProtocol = "https";

		public static string APIRestUrl = $"{APIProtocol}://{APIUrl}:{APIPort}/api/";

		public static string WeatherAPIKey = "27f5e232e3b11725bc87ed47808bead0";
		public static string WeatherAPIBaseUrl = "https://api.openweathermap.org";
        public static string WeatherAPIProBaseUrl = "https://pro.openweathermap.org";
        public static string WeatherAPPBaseUrl = "https://openweathermap.org";
        public static string WeatherHistoryAPIBaseUrl = "https://history.openweathermap.org";


        public static string WeatherAPIDataEndpoint = "data";
		public static string WeatherAPIDataEndpointVersion = "2.5";
        public static string WeatherAPIDataCurrentWeatherEndpoint = "weather";

        public static string BaseCurrentWeatherAPIUrl = $"{WeatherAPIBaseUrl}/{WeatherAPIDataEndpoint}/{WeatherAPIDataEndpointVersion}/";

		protected static string WeatherAPIImgEndpoint = "img/wn";

		public static string BaseImgWeatherAPIUrl = $"{WeatherAPPBaseUrl}/{WeatherAPIImgEndpoint}/";

		public static string WeatherAPIForecastEndpoint = "forecast";
		public static string WeatherAPIForecastHourlyEndpoint = "hourly";

        public static string BaseHourlyForecastWeatherAPIUrl = $"{WeatherAPIProBaseUrl}/{WeatherAPIDataEndpoint}/{WeatherAPIDataEndpointVersion}/{WeatherAPIForecastEndpoint}/";

        public static string WeatherAPIForecastDailyEndpoint = "daily";

        public static string BaseDailyForecastWeatherAPIUrl = $"{WeatherAPIBaseUrl}/{WeatherAPIDataEndpoint}/{WeatherAPIDataEndpointVersion}/{WeatherAPIForecastEndpoint}/";

		private static string WeatherHistoryAPIDataEndpoint = "data";
        private static string WeatherHistoryAPIDataEndpointVersion = "2.5";
        private static string WeatherHistoryAPIHistoryEndpoint = "history";
        public static string WeatherHistoryAPICityEndpoint = "city";

        public static string BaseWeatherAPIHistoryUrl = $"{WeatherHistoryAPIBaseUrl}/{WeatherHistoryAPIDataEndpoint}/{WeatherHistoryAPIDataEndpointVersion}/{WeatherHistoryAPIHistoryEndpoint}/";
    }
}
