using Newtonsoft.Json;

namespace WeatherApp.Models
{
    public class CityShort
    {
		[JsonProperty("name")]
		public string Name { get; set; }
		
        [JsonProperty("id")]
		private long Id { get; set; }

		[JsonProperty("country")]
		private string Country { get; set; }

		[JsonProperty("population")]
		private long Population { get; set; }
    }
}
