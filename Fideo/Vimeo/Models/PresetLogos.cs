using Newtonsoft.Json;

namespace Fideo.Vimeo.Models
{
    
    /// Preset logos
    
    public class PresetLogos
    {
        
        /// Vimeo
        
        [JsonProperty(PropertyName = "vimeo")]
        public bool Vimeo { get; set; }

        
        /// Custom
        
        [JsonProperty(PropertyName = "custom")]
        public bool Custom { get; set; }

        
        /// Sticky custom
        
        [JsonProperty(PropertyName = "sticky_custom")]
        public bool StickyCustom { get; set; }
    }
}
