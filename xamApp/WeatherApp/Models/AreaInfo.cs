using System;
using Newtonsoft.Json;

namespace WeatherApp.Models
{
    public class AreaInfo
    {
        [JsonProperty("id")]
        private long Id { get; set; }

        [JsonProperty("sunrise")]
        public DateTime Sunrise { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("message")]
        private double Message { get; set; }

        [JsonProperty("sunset")]
        public DateTime Sunset { get; set; }

        [JsonProperty("type")]
        private long Type { get; set; }
    }
}
