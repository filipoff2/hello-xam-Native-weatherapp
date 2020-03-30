using System;
using Newtonsoft.Json;

namespace WeatherApp.Models
{
    public class CityLong: CityShort
    {
        [JsonProperty("coord")]
        public Coordinate Coord { get; set; }

        [JsonProperty("clouds")]
        public Cloudiness Clouds { get; set; }

        [JsonProperty("base")]
        private string Base { get; set; }

        [JsonProperty("cod")]
        private long Cod { get; set; }

        [JsonProperty("dt")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("main")]
        public WeatherStatistics Statistics { get; set; }

        [JsonProperty("visibility")]
        public long Visibility { get; set; }

        [JsonProperty("sys")]
        public AreaInfo Sys { get; set; }

        [JsonProperty("weather")]
        public Weather[] Weather { get; set; }

        [JsonProperty("wind")]
        public Wind Wind { get; set; }
    }
}
