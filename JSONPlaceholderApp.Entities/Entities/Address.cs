using System;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using SQLite;

namespace JSONPlaceholderApp.Entities
{
    public class Address //: Entity<String>
    {
        [JsonProperty("street")]
        public String Street { get; set; }

        [JsonProperty("suite")]
        public String Suite { get; set; }

        [JsonProperty("city")]
        public String City { get; set; }

        [JsonProperty("zipcode")]
        public String Zipcode { get; set; }

        [Ignore]
        [JsonProperty("geo")]
        public Geolocation Geolocation { get; set; }

        //[System.Runtime.Serialization.Json.Net.JsonIgnore]
        [IgnoreDataMember]
        [JsonIgnore]
        public String GeolocationJSON
        {
            get
            {
                return JsonConvert.SerializeObject(Geolocation);
            }
            set
            {
                this.Geolocation = JsonConvert.DeserializeObject<Geolocation>(value);
            }
        }
    }
}
