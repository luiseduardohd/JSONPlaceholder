using System;
using Newtonsoft.Json;

namespace JSONPlaceholder.Models
{
    public class Company : Entity<String>
    {
        [JsonProperty("name")]
        public String Name { get; set; }

        [JsonProperty("catchPhrase")]
        public String CatchPhrase { get; set; }

        [JsonProperty("bs")]
        public String bs { get; set; }
    }
}
