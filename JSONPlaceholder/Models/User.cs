using System;
using Newtonsoft.Json;

namespace JSONPlaceholder.Models
{
    public class User : Entity<String>
    {
        [JsonProperty("name")]
        public String Name { get; set; }

        [JsonProperty("username")]
        public String Username { get; set; }

        [JsonProperty("email")]
        public String Email { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("phone")]
        public String Phone { get; set; }

        [JsonProperty("website")]
        public String Website { get; set; }

        [JsonProperty("company")]
        public Company Company { get; set; }
    }
}
