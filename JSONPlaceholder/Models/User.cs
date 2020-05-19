using System;
using Newtonsoft.Json;
using SQLite;

namespace JSONPlaceholder.Models
{
    public class User : Entity<int>
    {
        [JsonProperty("name")]
        public String Name { get; set; }

        [JsonProperty("username")]
        public String Username { get; set; }

        [JsonProperty("email")]
        public String Email { get; set; }

        [Ignore]
        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("phone")]
        public String Phone { get; set; }

        [JsonProperty("website")]
        public String Website { get; set; }

        [Ignore]
        [JsonProperty("company")]
        public Company Company { get; set; }
    }
}
