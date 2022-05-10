using Newtonsoft.Json;

namespace Fideo.Vimeo.Models
{
    
    /// Domain for embedding a video
    
    public class DomainForEmbedding
    {
        
        /// Domain name
        
        [JsonProperty(PropertyName = "domain")]
        public string Domain { get; set; }

        
        /// Whether HD quality is allowed
        
        [JsonProperty(PropertyName = "allow_hd")]
        public bool AllowHighDefinition { get; set; }

        
        /// URI of this resource
        
        [JsonProperty(PropertyName = "uri")]
        public string Uri { get; set; }
    }
}
