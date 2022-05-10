using System.Collections.Generic;
using Newtonsoft.Json;

namespace Fideo.Vimeo.Models
{
    
    /// User pictures
    
    public class Pictures
    {
        
        /// URI
        
        [JsonProperty(PropertyName = "uri")]
        public string Uri { get; set; }

        
        /// Active
        
        [JsonProperty(PropertyName = "active")]
        public bool Active { get; set; }

        
        /// Type
        
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        
        /// Sizes
        
        [JsonProperty(PropertyName = "sizes")]
        public List<Size> Sizes { get; set; }

        
        /// Resources key
        
        [JsonProperty(PropertyName = "resource_key")]
        public string ResourceKey { get; set; }
    }
}
