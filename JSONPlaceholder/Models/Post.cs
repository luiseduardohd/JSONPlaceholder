using System;
using Newtonsoft.Json;

namespace JSONPlaceholder.Models
{
    public class Post : Entity<int>
    {
        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("title")]
        public String Title { get; set; }

        [JsonProperty("body")]
        public String Body { get; set; }
    }
}
