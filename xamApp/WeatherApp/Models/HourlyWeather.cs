using System;
using Newtonsoft.Json;

namespace WeatherApp.Models
{
    public class HourlyWeather
    {
		[JsonProperty("city")]
		public CityShort City { get; set; }

	    [JsonProperty("list")]
	    public HourWeatherDetails[] HourWeatherDetailsList { get; set; }
    }
}
