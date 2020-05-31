using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Nito.AsyncEx;
using SQLite;
using System.Linq;
using System.Collections.ObjectModel;

namespace JSONPlaceholder.Entities
{
    public class Post : Entity<int>
    {
        public Post()
        {
            /*
            Comments 
            = new AsyncLazy<ObservableCollection<Comment>>(
                    async () => {
                        return await App.jsonPlaceholder.GetCommentsAsync(this);
                    }
                );
            */
        }

        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("title")]
        public String Title { get; set; }

        [JsonProperty("body")]
        public String Body { get; set; }

        /*
        [Ignore]
        [JsonIgnore]
        public AsyncLazy<ObservableCollection<Comment>> Comments { get; set; }
        */
    }
}
