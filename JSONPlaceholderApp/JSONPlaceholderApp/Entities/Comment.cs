using System;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace JSONPlaceholderApp.Entities
{
    public class Comment : Entity<int>
    {
        [ForeignKey(nameof(Post))]
        [JsonProperty("postId")]
        public int PostId { get; set; }

        [JsonProperty("name")]
        public String Name { get; set; }

        [JsonProperty("email")]
        public String Email { get; set; }

        [JsonProperty("body")]
        public String Body { get; set; }
    }
}
