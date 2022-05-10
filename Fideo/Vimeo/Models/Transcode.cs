using Newtonsoft.Json;

namespace Fideo.Vimeo.Models
{
    
    /// Transcode
    
    public class Transcode
    {
        
        /// State
        
        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }

        
        /// Progress
        
        [JsonProperty(PropertyName = "progress")]
        public int Progress { get; set; }

        
        /// Message
        
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }
    }
}