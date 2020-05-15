using System;
using Newtonsoft.Json;

namespace JSONPlaceholder.Models
{
    public class Comment : Entity<String>
    {
        [JsonProperty("postId")]
        public String PostId { get; set; }

        [JsonProperty("name")]
        public String Name { get; set; }

        [JsonProperty("email")]
        public String Email { get; set; }

        [JsonProperty("body")]
        public String Body { get; set; }
    }
}
