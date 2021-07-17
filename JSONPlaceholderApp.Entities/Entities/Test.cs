using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using SQLite;


namespace JSONPlaceholderApp.Entities
{
    public class Test : Entity<int>
    {

        [JsonProperty("name")]
        public String Name { get; set; }

    }
}
