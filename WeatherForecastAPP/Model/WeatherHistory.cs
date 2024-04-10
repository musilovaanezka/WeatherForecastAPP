using System.Text.Json.Serialization;

namespace WeatherForecastAPP.Model
{
    public class WeatherHistory
    {
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("cod")]
        public string Cod {  get; set; }
        [JsonPropertyName("city_id")]
        public long CityId { get; set; }
        [JsonPropertyName("calctime")]
        public double Calctime { get; set; }
        [JsonPropertyName("cnt")]
        public int Cnt {  get; set; }
        [JsonPropertyName("list")]
        public WeatherHistoryList[] List { get; set; }

        public WeatherHistory() { }
    }

    public class WeatherHistoryList
    {
        [JsonPropertyName("dt")]
        public long Dt { get; set; }
        [JsonPropertyName("main")]
        public WeatherHistoryMain Main { get; set; }
        [JsonPropertyName("wind")]
        public WeatherHistoryWind Wind { get; set; }
        [JsonPropertyName("clouds")]
        public Clouds Clouds { get; set; }
        [JsonPropertyName("weather")]
        public Weather[] Weather { get; set; }
        [JsonPropertyName("rain")]
        public Rain Rain { get; set; }
        
        public WeatherHistoryList() { }
    }

    public class WeatherHistoryMain
    {
        [JsonPropertyName("temp")]
        public double Temp {  get; set; }
        [JsonPropertyName("feels_like")]
        public double FeelsLike {  get; set; }
        [JsonPropertyName("pressure")]
        public long Pressure { get; set; }
        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }
        [JsonPropertyName("temp_min")]
        public double TempMin { get; set; }
        [JsonPropertyName("temp_max")]
        public double TempMax { get; set; }

        public WeatherHistoryMain() { }
    }

    public class WeatherHistoryWind
    {
        [JsonPropertyName("speed")]
        public double Speed { get; set; }
        [JsonPropertyName("deg")]
        public double Deg { get; set; }
        [JsonPropertyName("gust")]
        public double? Gust { get; set; }

        public WeatherHistoryWind() { }
    }
}
