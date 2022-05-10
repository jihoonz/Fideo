using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Fideo.Vimeo.Models
{
    
    /// Text track
    
    public class TextTrack
    {
        
        /// URI
        
        [JsonProperty(PropertyName = "uri")]
        public string Uri { get; set; }

        
        /// Active
        
        [JsonProperty(PropertyName = "active")]
        public bool Active { get; set; }

        
        /// Type
        
        [JsonProperty(PropertyName = "type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TextTrackType? Type { get; set; }

        
        /// Language
        
        [JsonProperty(PropertyName = "language")]
        public string Language { get; set; }

        
        /// Link
        
        [JsonProperty(PropertyName = "link")]
        public string Link { get; set; }

        
        /// Hls link
        
        [JsonProperty(PropertyName = "hls_link")]
        public string HlsLink { get; set; }

        
        /// Name
        
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }

    public enum TextTrackType
    {
        Captions,
        Chapters,
        Descriptions,
        Metadata,
        SubTitles
    }
}