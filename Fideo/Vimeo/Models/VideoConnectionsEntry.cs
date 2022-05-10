using System.Collections.Generic;
using Newtonsoft.Json;

namespace Fideo.Vimeo.Models
{
    
    /// Video connections entry
    
    public class VideoConnectionsEntry
    {
        
        /// URI
        
        [JsonProperty(PropertyName = "uri")]
        public string Uri { get; set; }

        
        /// Options
        
        [JsonProperty(PropertyName = "options")]
        public List<string> Options { get; set; }

        
        /// Total
        
        [JsonProperty(PropertyName = "total")]
        public int Total { get; set; }
    }
}