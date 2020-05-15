using System;
using Newtonsoft.Json;


namespace JSONPlaceholder.Models
{
    public class Entity<T>
    {
        [JsonProperty("id")]
        public T Id { get; set; }
    }
}
