using System;
using Newtonsoft.Json;

namespace JSONPlaceholderApp.Entities
{
    public class Geolocation : Entity<String>
    {
        [JsonProperty("lat")]
        public String Latitude { get; set; }

        [JsonProperty("lng")]
        public String Longitude { get; set; }
    }
}
