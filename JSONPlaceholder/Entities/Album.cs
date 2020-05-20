using System;
using Newtonsoft.Json;

namespace JSONPlaceholder.Entities
{
    public class Album : Entity<int>
    {
        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("title")]
        public String Title { get; set; }
    }
}
