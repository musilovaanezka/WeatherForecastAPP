using System.Text.Json.Serialization;

namespace WeatherForecastAPP.Model
{
	public class CurrentWeather
	{
		[JsonPropertyName("coord")]
		public Coordinates Coord { get; set; }
		[JsonPropertyName("weather")]
		public Weather[] Weather { get; set; }
		[JsonPropertyName("base")]
		public string Base { get; set; }
		[JsonPropertyName("main")]
		public MainWeather Main { get; set; }
		[JsonPropertyName("visibility")]
		public long Visibility { get; set; }
		[JsonPropertyName("wind")]
		public Wind Wind { get; set; }
		[JsonPropertyName("clouds")]
		public Clouds Clouds { get; set; }
		[JsonPropertyName("dt")]
		public long Dt { get; set; }
		[JsonPropertyName("sys")]
		public CurrentWeatherSys Sys { get; set; }
		[JsonPropertyName("timezone")]
		public long Timezone { get; set; }
		[JsonPropertyName("id")]
		public long Id { get; set; }
		[JsonPropertyName("name")]
		public string Name { get; set; }
		[JsonPropertyName("cod")]
		public long Cod { get; set; }
        [JsonPropertyName("rain")]
        public Rain Rain { get; set; }
		public Snow Snow { get; set; }

		public CurrentWeather() { }
	}

	public class CurrentWeatherSys
	{
		[JsonPropertyName("type")]
		public long Type { get; set; }
		[JsonPropertyName("id")]
		public long Id { get; set; }
		[JsonPropertyName("country")]
		public string Country { get; set; }
		[JsonPropertyName("sunrise")]
		public long Sunrise { get; set; }
		[JsonPropertyName("sunset")]
		public long Sunset { get; set; }

		public CurrentWeatherSys() { }
	}
}
