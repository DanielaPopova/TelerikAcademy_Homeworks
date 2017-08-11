using Newtonsoft.Json;

namespace ProcessingJSON.Models
{
    public class Video
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("yt:videoId")]
        public string Id { get; set; }

        [JsonProperty("link")]
        public Link Link { get; set; }       
    }
}
