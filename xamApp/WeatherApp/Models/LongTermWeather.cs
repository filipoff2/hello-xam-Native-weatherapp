using System.Collections.Generic;
using Newtonsoft.Json;

namespace WeatherApp.Models
{
    public class LongTermWeather
    {
		[JsonProperty("city")]
		public CityShort City { get; set; }

        [JsonProperty("list")]
        public List<DailyWeather> DailyWeatherList { get; set; }

		[JsonProperty("cod")]
		private long Cod { get; set; }

		[JsonProperty("message")]
		private double Message { get; set; }

		[JsonProperty("cnt")]
		public long DailyWeatherCount { get; set; }
    }
}
