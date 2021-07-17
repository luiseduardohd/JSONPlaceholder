using System;
using System.ComponentModel.DataAnnotations.Schema;
using JSONPlaceholder.Util;
using Newtonsoft.Json;
using SQLite;

namespace JSONPlaceholder.Entities
{
    public class Photo : Entity<int>
    {
        [ForeignKey(nameof(Album))]
        [JsonProperty("albumId")]
        public int AlbumId { get; set; }

        [JsonProperty("title")]
        public String Title { get; set; }

        [JsonProperty("url")]
        public String Url { get; set; }

        [JsonProperty("thumbnailUrl")]
        public String ThumbnailUrl { get; set; }

    }
}
