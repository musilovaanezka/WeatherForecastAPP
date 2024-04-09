using System.Text.Json.Serialization;

namespace WeatherForecastAPP.Model
{

    public class Rain
    {
        [JsonPropertyName("1h")]
        public double? Hour { get; set; }
        [JsonPropertyName("3h")]
        public double? ThreeHours { get; set; }

        public Rain() { }
    }

    public class Clouds
    {
        [JsonPropertyName("all")]
        public long All { get; set; }

        public Clouds() { }
    }

    public class Snow
    {
        [JsonPropertyName("1h")]
        public double? Hour { get; set; }
        [JsonPropertyName("3h")]
        public double? ThreeHours { get; set; }

        public Snow() { }
    }

    public class MainWeather
    {
        [JsonPropertyName("temp")]
        public double Temp { get; set; }
        [JsonPropertyName("feels_like")]
        public double FeelsLike { get; set; }
        [JsonPropertyName("temp_min")]
        public double TempMin { get; set; }
        [JsonPropertyName("temp_max")]
        public double TempMax { get; set; }
        public long Pressure { get; set; }
        [JsonPropertyName("sea_level")]
        public long? SeaLevel { get; set; }
        [JsonPropertyName("grnd_level")]
        public long? GrndLevel { get; set; }
        public long Humidity { get; set; }

        public MainWeather() { }
    }

    public class Weather
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("main")]
        public string Main { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("icon")]
        public string Icon { get; set; }

        public Weather() { }
    }

    public class Wind
    {
        [JsonPropertyName("speed")]
        public double Speed { get; set; }
        [JsonPropertyName("deg")]
        public long Deg { get; set; }

        public Wind() { }
    }
}
