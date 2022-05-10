using System.Collections.Generic;
using Newtonsoft.Json;

namespace Fideo.Vimeo.Models
{
    
    /// Text tracks
    
    public class TextTracks
    {
        
        /// URI
        
        [JsonProperty(PropertyName = "uri")]
        public string Uri { get; set; }

        
        /// Options
        
        [JsonProperty(PropertyName = "options")]
        public List<string> Options { get; set; }

        
        /// Content
        
        [JsonProperty(PropertyName = "data")]
        public List<TextTrack> Data { get; set; }

        
        /// Total
        
        [JsonProperty(PropertyName = "total")]
        public string Total { get; set; }
    }
}