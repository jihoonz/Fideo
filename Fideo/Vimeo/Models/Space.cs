using Newtonsoft.Json;

namespace Fideo.Vimeo.Models
{
    
    /// Space
    
    public class Space
    {
        
        /// Max
        
        [JsonProperty(PropertyName = "max")]
        public long Max { get; set; }

        
        /// Free
        
        [JsonProperty(PropertyName = "free")]
        public long Free { get; set; }

        
        /// Used
        
        [JsonProperty(PropertyName = "used")]
        public long Used { get; set; }
    }
}
