using System;
using Newtonsoft.Json;

namespace WeatherApp.Models
{
    public class HourWeatherDetails
    {
		[JsonProperty("dt")]
		public DateTime Timestamp { get; set; }

		[JsonProperty("main")]
		public WeatherStatistics Statistics { get; set; }

		[JsonProperty("weather")]
		public Weather[] Weather { get; set; }

		[JsonProperty("clouds")]
		public Cloudiness Clouds { get; set; }

		[JsonProperty("wind")]
		public Wind Wind { get; set; }
    }
}
