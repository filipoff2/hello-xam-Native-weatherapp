﻿using Newtonsoft.Json;

namespace WeatherApp.Models
{
    public class TemperatureDetails
    {
		[JsonProperty("day")]
		public double Day { get; set; }

		[JsonProperty("night")]
		public double Night { get; set; }

		[JsonProperty("min")]
		public double Min { get; set; }

		[JsonProperty("max")]
		public double Max { get; set; }

		[JsonProperty("eve")]
		public double Eve { get; set; }

		[JsonProperty("morn")]
		public double Morning { get; set; }
    }
}
