using System;
using Newtonsoft.Json;

namespace JSONPlaceholder.Models
{
    public class Todo : Entity<String>
    {
        [JsonProperty("userId")]
        public String UserId { get; set; }

        [JsonProperty("title")]
        public String Title { get; set; }

        [JsonProperty("completed")]
        public bool Completed { get; set; }
    }
}
