using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Nito.AsyncEx;
using SQLite;
using System.Linq;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace JSONPlaceholderApp.Entities
{
    public class Post : Entity<int>
    {
        public Post()
        {
        }

        [ForeignKey(nameof(User))]
        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("title")]
        public String Title { get; set; }

        [JsonProperty("body")]
        public String Body { get; set; }

    }
}
