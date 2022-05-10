using Newtonsoft.Json;

namespace Fideo.Vimeo.Models
{
    
    /// Paging
    
    public class Paging
    {
        
        /// Next
        
        [JsonProperty(PropertyName = "next")]
        public string Next { get; set; }

        
        /// Previous
        
        [JsonProperty(PropertyName = "previous")]
        public string Previous { get; set; }

        
        /// First
        
        [JsonProperty(PropertyName = "first")]
        public string First { get; set; }

        
        /// Last
        
        [JsonProperty(PropertyName = "last")]
        public string Last { get; set; }
    }
}