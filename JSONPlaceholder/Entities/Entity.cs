using System;
using Newtonsoft.Json;
using SQLite;

namespace JSONPlaceholder.Entities
{
    //public class SqliteEntity<T> //: Entity, IEntity
    public class Entity<T> //: IEntity
    {
        [PrimaryKey]
        [JsonProperty("id")]
        public T Id { get; set; }
    }
}
