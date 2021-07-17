using System;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace JSONPlaceholder.Entities
{
    public class Todo : Entity<int>
    {
        [ForeignKey(nameof(User))]
        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("title")]
        public String Title { get; set; }

        [JsonProperty("completed")]
        public bool Completed { get; set; }
    }
}
