using System.Text.Json.Serialization;

namespace WeatherForecastAPP.Model
{
	public class Coordinates
	{
		[JsonPropertyName("lat")]
		public double Lat { get; set; }
		[JsonPropertyName("lon")]
		public double Lon { get; set; }

		public Coordinates() { }
	}
}
