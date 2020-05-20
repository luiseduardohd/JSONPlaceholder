using System;
using Newtonsoft.Json;

namespace JSONPlaceholder.Models
{
    public class Geolocation : Entity<String>
    {
        [JsonProperty("lat")]
        public String Latitude { get; set; }

        [JsonProperty("lng")]
        public String Longitude { get; set; }
    }
}
