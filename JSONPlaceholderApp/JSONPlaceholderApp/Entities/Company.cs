using System;
using Newtonsoft.Json;

namespace JSONPlaceholderApp.Entities
{
    public class Company : Entity<String>
    {
        [JsonProperty("name")]
        public String Name { get; set; }

        [JsonProperty("catchPhrase")]
        public String CatchPhrase { get; set; }

        [JsonProperty("bs")]
        public String Bs { get; set; }
    }
}
