using System;
using System.Net;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace WeatherApp.Models
{
    public class Coordinate
    {
        [JsonProperty("lat")]
        public double Latitude { get; set; }

        [JsonProperty("lon")]
        public double Longitude { get; set; }
    }
}
