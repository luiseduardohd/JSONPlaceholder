using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using SQLite;

namespace JSONPlaceholder.Entities
{
    public class Entity<T>
    {
        [Key]
        [PrimaryKey]
        [JsonProperty("id")]
        public T Id { get; set; }
    }
}
