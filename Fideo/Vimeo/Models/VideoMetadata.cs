using Newtonsoft.Json;

namespace Fideo.Vimeo.Models
{
    
    /// Video metadata
    
    public class VideoMetadata
    {
        
        /// Connections
        
        [JsonProperty(PropertyName = "connections")]
        public VideoConnections Connections { get; set; }
    }
}