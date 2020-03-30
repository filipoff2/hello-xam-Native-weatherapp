using Newtonsoft.Json;

namespace WeatherApp.Models
{
    public class WeatherStatistics
    {
        [JsonProperty("pressure")]
        public long Pressure { get; set; }

        [JsonProperty("temp_max")]
        public double TempMax { get; set; }

        [JsonProperty("humidity")]
        public long Humidity { get; set; }

        [JsonProperty("temp")]
        public double Temp { get; set; }

        [JsonProperty("temp_min")]
        public double TempMin { get; set; }
    }
}
