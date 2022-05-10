using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Fideo.Vimeo.Models
{
    
    /// The type of picture
    
    public enum PictureType
    {
        
        /// The default image for the video.
        
        Default,
        
        /// An image that is appropriate for all ages.
        
        Caution,
        
        /// A custom image for the video.
        
        Custom
    }

    
    /// Picture
    
    public class Picture
    {
        
        /// Whether this picture is the active picture for its parent resource.
        
        [JsonProperty(PropertyName = "active")]
        public bool Active { get; set; }

        
        /// The picture's URI.
        
        [JsonProperty(PropertyName = "uri")]
        public string Uri { get; set; }

        
        /// An array containing reference information about all available image files.
        
        [JsonProperty(PropertyName = "sizes")]
        public List<Size> Sizes { get; set; }

        
        /// The upload URL for the picture. This field appears when you create the picture resource for the first time.
        
        [JsonProperty(PropertyName = "link")]
        public string Link { get; set; }

        
        /// The picture's resource key string.
        
        [JsonProperty(PropertyName = "resource_key")]
        public string ResourceKey { get; set; }

        
        /// The type of picture:
        
        [JsonConverter(typeof(StringEnumConverter), converterParameters: typeof(CamelCaseNamingStrategy))]
        [JsonProperty(PropertyName = "type")]
        public PictureType Type { get; set; }
    }
}