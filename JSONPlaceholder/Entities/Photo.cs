﻿using System;
using Newtonsoft.Json;

namespace JSONPlaceholder.Entities
{
    public class Photo : Entity<int>
    {
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