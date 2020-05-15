using System;
using Newtonsoft.Json;

namespace JSONPlaceholder.Models
{
    public class Photo : Entity<String>
    {
        [JsonProperty("albumId")]
        public String AlbumId { get; set; }

        [JsonProperty("title")]
        public String Title { get; set; }

        [JsonProperty("url")]
        public String Url { get; set; }

        [JsonProperty("thumbnailUrl")]
        public String ThumbnailUrl { get; set; }
    }
}
