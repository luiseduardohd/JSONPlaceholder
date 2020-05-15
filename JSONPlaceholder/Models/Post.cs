using System;
using Newtonsoft.Json;

namespace JSONPlaceholder.Models
{
    public class Post : Entity<String>
    {
        [JsonProperty("userId")]
        public String UserId { get; set; }

        [JsonProperty("title")]
        public String Title { get; set; }

        [JsonProperty("body")]
        public String Body { get; set; }
    }
}
