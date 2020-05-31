using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using Nito.AsyncEx;
using SQLite;

namespace JSONPlaceholder.Entities
{
    public class User : Entity<int>
    {
        public User()
        {
            /*
            this.Albums
            = new AsyncLazy<ObservableCollection<Album>>(
                    async () => {
                        return await App.jsonPlaceholder.GetAlbumsAsync(this);
                    }
                );
            this.Posts
            = new AsyncLazy<ObservableCollection<Post>>(
                    async () => {
                        return await App.jsonPlaceholder.GetPostsAsync(this);
                    }
                );
            this.Todos
            = new AsyncLazy<ObservableCollection<Todo>>(
                    async () => {
                        return await App.jsonPlaceholder.GetTodosAsync(this);
                    }
                );
            */
        }

        [JsonProperty("name")]
        public String Name { get; set; }

        [JsonProperty("username")]
        public String Username { get; set; }

        [JsonProperty("email")]
        public String Email { get; set; }

        [Ignore]
        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("phone")]
        public String Phone { get; set; }

        [Ignore]
        [JsonProperty("website")]
        public String Website { get; set; }

        [Ignore]
        [JsonProperty("company")]
        public Company Company { get; set; }



        /*
        [Ignore]
        [JsonIgnore]
        public AsyncLazy<ObservableCollection<Album>> Albums { get; set; }

        [Ignore]
        [JsonIgnore]
        public AsyncLazy<ObservableCollection<Post>> Posts { get; set; }

        [Ignore]
        [JsonIgnore]
        public AsyncLazy<ObservableCollection<Todo>> Todos { get; set; }
        */


        #region SQLiteUtil

        [JsonIgnore]
        public String AddressJSON
        {
            get
            {
                return JsonConvert.SerializeObject(Address);
            }
            set
            {
                this.Address = JsonConvert.DeserializeObject<Address>(value);
            }
        }

        [JsonIgnore]
        public String CompanyJSON
        {
            get
            {
                return JsonConvert.SerializeObject(Company);
            }
            set
            {
                this.Company = JsonConvert.DeserializeObject<Company>(value);
            }
        }

        #endregion
    }
}
