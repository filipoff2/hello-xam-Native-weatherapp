using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WeatherApp.Models
{
    public class DailyWeather
    {
		[JsonProperty("dt")]
		public DateTime Timestamp { get; set; }

		[JsonProperty("temp")]
		public TemperatureDetails Temperatures { get; set; }

		[JsonProperty("pressure")]
		public long Pressure { get; set; }

		[JsonProperty("humidity")]
		public long Humidity { get; set; }

		[JsonProperty("weather")]
		public Weather[] Weather { get; set; }

		[JsonProperty("speed")]
		public double Speed { get; set; }

		[JsonProperty("deg")]
		public long Deg { get; set; }

		[JsonProperty("clouds")]
		public long Clouds { get; set; }

		[JsonProperty("rain")]
		public double Rain { get; set; }
    }
}
