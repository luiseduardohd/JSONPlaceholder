using System;
using JSONPlaceholder.Util;
using Newtonsoft.Json;
using SQLite;

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

        /* 
        #region SQLiteUtil
        [Ignore]
        [JsonIgnore]
        public byte[] ImageByteArray { get; set; }

        [Ignore]
        [JsonIgnore]
        public String ImageBase64
        {
            get
            {
                return ImageByteArray.ToBase64();
            }
            set
            {
                this.ImageByteArray = value.ToByteArray();
            }
        }

        #endregion
        */
    }
}
