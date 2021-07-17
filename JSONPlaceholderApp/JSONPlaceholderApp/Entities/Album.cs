using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using Nito.AsyncEx;
using SQLite;

namespace JSONPlaceholderApp.Entities
{
    public class Album : Entity<int>
    {
        [ForeignKey(nameof(User))]
        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("title")]
        public String Title { get; set; }

    }
}
