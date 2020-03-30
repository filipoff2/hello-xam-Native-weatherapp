using Newtonsoft.Json;

namespace WeatherApp.Models
{
    public class Cloudiness
    {
        /// <summary>
        /// Percentage of cloudiness.
        /// </summary>
        /// <value>Integer in 0-100 range.</value>
        [JsonProperty("all")]
        public long Level { get; set; }
    }
}
