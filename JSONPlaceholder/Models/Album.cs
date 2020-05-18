using System;
using Newtonsoft.Json;

namespace JSONPlaceholder.Models
{
    public class Album : Entity<int>
    {
        [JsonProperty("userId")]
        public String UserId { get; set; }

        [JsonProperty("title")]
        public String Title { get; set; }
    }
}
