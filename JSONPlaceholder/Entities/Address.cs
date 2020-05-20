using System;
using Newtonsoft.Json;

namespace JSONPlaceholder.Models
{
    public class Address : Entity<String>
    {
        [JsonProperty("street")]
        public String Street { get; set; }

        [JsonProperty("suite")]
        public String Suite { get; set; }

        [JsonProperty("city")]
        public String City { get; set; }

        [JsonProperty("zipcode")]
        public String Zipcode { get; set; }

        [JsonProperty("geo")]
        public Geolocation Geolocation { get; set; }
    }
}
