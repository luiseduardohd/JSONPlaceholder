using System;
using Newtonsoft.Json;
using SQLite;

namespace JSONPlaceholder.Entities
{
    public class Entity<T>
    {
        [PrimaryKey]
        [JsonProperty("id")]
        public T Id { get; set; }
    }
}
