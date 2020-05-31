using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Nito.AsyncEx;
using SQLite;

namespace JSONPlaceholder.Entities
{
    public class Album : Entity<int>
    {
        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("title")]
        public String Title { get; set; }

        /*
        [Ignore]
        [JsonIgnore]
        public AsyncLazy<List<Photo>> Photos { get; set; }
        */
    }
}
