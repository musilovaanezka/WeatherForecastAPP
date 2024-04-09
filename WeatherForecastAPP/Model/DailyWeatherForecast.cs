using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace WeatherForecastAPP.Model
{
    public class DailyWeatherForecast
    {
        [JsonPropertyName("cod")]
        public string Cod { get; set; }
        [JsonPropertyName("message")]
        public double Message { get; set; }
        [JsonPropertyName("cnt")]
        public long Cnt { get; set; }
        [JsonPropertyName("list")]
        public DailyWeatherForecastList[] List { get; set; }
        [JsonPropertyName("city")]
        public DailyWeatherForecastCity City { get; set; }

        public DailyWeatherForecast() { }
    }
    public class DailyWeatherForecastCity
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

        public DailyWeatherForecastCity() { }
    }

    public class DailyWeatherForecastList
    {
        [JsonPropertyName("dt")]
        public long Dt { get; set; }
        [JsonPropertyName("sunrise")]
        public long Sunrise { get; set; }
        [JsonPropertyName("sunset")]
        public long Sunset { get; set; }
        [JsonPropertyName("temp")]
        public DailyWeatherForecastTemp Temp { get; set; }
        [JsonPropertyName("feels_like")]
        public DailyWeatherForecastFeelsLike FeelsLike { get; set; }
        [JsonPropertyName("pressure")]
        public long Pressure { get; set; }
        [JsonPropertyName("humidity")]
        public long Humidity { get; set; }
        [JsonPropertyName("weather")]
        public Weather[] Weather { get; set; }
        [JsonPropertyName("speed")]
        public double speed { get; set; }
        [JsonPropertyName("deg")]
        public long Deg {  get; set; }
        [JsonPropertyName("gust")]
        public double Gust { get; set; }
        [JsonPropertyName("clouds")]
        public long Clouds { get; set; }
        [JsonPropertyName("pop")]
        public double Pop {  get; set; }
        [JsonPropertyName("rain")]
        public double? Rain {  get; set; }

        public DailyWeatherForecastList() { }
    }

    public class DailyWeatherForecastTemp
    {
        [JsonPropertyName("day")]
        public double Day { get; set; }
        [JsonPropertyName("min")]
        public double Min { get; set; }
        [JsonPropertyName("max")]
        public double Max { get; set; }
        [JsonPropertyName("night")]
        public double Night { get; set; }
        [JsonPropertyName("eve")]
        public double Eve { get; set; }
        [JsonPropertyName("morn")]
        public double Morn { get; set; }
        
        public DailyWeatherForecastTemp() { }
    }

    public class DailyWeatherForecastFeelsLike
    {
        [JsonPropertyName("day")]
        public double Day { get; set; }
        [JsonPropertyName("night")]
        public double Night { get; set; }
        [JsonPropertyName("eve")]
        public double Eve { get; set; }
        [JsonPropertyName("morn")]
        public double Morn { get; set; }
    }
}
