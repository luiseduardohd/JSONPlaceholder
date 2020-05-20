using System;
using Newtonsoft.Json;

namespace JSONPlaceholder.Entities
{
    public class Todo : Entity<int>
    {
        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("title")]
        public String Title { get; set; }

        [JsonProperty("completed")]
        public bool Completed { get; set; }
    }
}
