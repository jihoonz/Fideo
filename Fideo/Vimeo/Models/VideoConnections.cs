using Newtonsoft.Json;

namespace Fideo.Vimeo.Models
{
    
    /// Video connections
    
    public class VideoConnections
    {
        
        /// Comments
        
        [JsonProperty(PropertyName = "comments")]
        public VideoConnectionsEntry Comments { get; set; }

        
        /// Credits
        
        [JsonProperty(PropertyName = "credits")]
        public VideoConnectionsEntry Credits { get; set; }

        
        /// Likes
        
        [JsonProperty(PropertyName = "likes")]
        public VideoConnectionsEntry Likes { get; set; }

        
        /// Pictures
        
        [JsonProperty(PropertyName = "pictures")]
        public VideoConnectionsEntry Pictures { get; set; }

        
        /// Text tracks
        
        [JsonProperty(PropertyName = "texttracks")]
        public TextTracks Texttracks { get; set; }
    }
}