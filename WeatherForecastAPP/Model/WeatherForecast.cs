using System.Text.Json.Serialization;

namespace WeatherForecastAPP.Model
{
    public class WeatherForecast
    {
        [JsonPropertyName("cod")]
        public string Cod { get; set; }
        [JsonPropertyName("message")]
        public long Message { get; set; }
        [JsonPropertyName("cnt")]
        public long Cnt { get; set; }
        [JsonPropertyName("list")]
        public WeatherForecastList[] List { get; set; }
        [JsonPropertyName("city")]
        public WeatherForecastCity City { get; set; }

        public WeatherForecast() { }
    }

    public class WeatherForecastList
    {
        [JsonPropertyName("dt")]
        public long Dt { get; set; }
        [JsonPropertyName("main")]
        public MainWeather Main { get; set; }
        [JsonPropertyName("weather")]
        public Weather[] Weather { get; set; }
        [JsonPropertyName("clouds")]
        public Clouds Clouds { get; set; }
        [JsonPropertyName("wind")]
        public Wind Wind { get; set; }
        [JsonPropertyName("visibility")]
        public long Visibility { get; set; }
        [JsonPropertyName("pop")]
        public double Pop { get; set; }
        [JsonPropertyName("sys")]
        public WeatherForecastSys Sys { get; set; }
        [JsonPropertyName("dt_txt")]
        public string DxTxt { get; set; }
        [JsonPropertyName("rain")]
        public Rain Rain { get; set; }
        public Snow Snow { get; set; }

        public WeatherForecastList() { }
    }
    public class WeatherForecastCity
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("coord")]
        public Coordinates Coordinates { get; set; }
        [JsonPropertyName("country")]
        public string Country { get; set; }
        [JsonPropertyName("population")]
        public long Population { get; set; }
        [JsonPropertyName("timezone")]
        public long Timezone { get; set; }
        [JsonPropertyName("sunrise")]
        public long Sunrise { get; set; }
        [JsonPropertyName("sunset")]
        public long Sunset { get; set; }

        public WeatherForecastCity() { }
    }

    public class WeatherForecastSys
    {
        [JsonPropertyName("pod")]
        public string Pod { get; set; }

        public WeatherForecastSys() { } 
    }
}
