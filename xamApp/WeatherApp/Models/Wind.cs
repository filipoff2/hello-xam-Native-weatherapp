using Newtonsoft.Json;

namespace WeatherApp.Models
{
    public class Wind
    {
        [JsonProperty("deg")]
        public long Deg { get; set; }

        [JsonProperty("speed")]
        public double Speed { get; set; }
    }
}
