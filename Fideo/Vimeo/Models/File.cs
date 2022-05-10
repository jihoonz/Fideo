using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Fideo.Vimeo.Enums;
using Fideo.Vimeo.Helpers;

namespace Fideo.Vimeo.Models
{
    
    /// File model
    
    public class File
    {
        private static readonly IDictionary<string, string> QualityMappings = new Dictionary<string, string>
        {
            {"mobile", "Mobile"},
            {"hd", "HighDefinition"},
            {"sd", "Standard"},
            {"hls", "Streaming"}
        };

        
        /// Quality
        
        [JsonProperty(PropertyName = "quality")]
        public string Quality { get; set; }

        
        /// Type
        
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        
        /// Width
        
        [JsonProperty(PropertyName = "width")]
        public int Width { get; set; }

        
        /// Height
        
        [JsonProperty(PropertyName = "height")]
        public int Height { get; set; }

        
        /// File size
        
        [JsonProperty(PropertyName = "size")]
        public long Size { get; set; }

        
        /// Expires
        
        [JsonProperty(PropertyName = "expires")]
        public DateTime? Expires { get; set; }

        
        /// Link
        
        [JsonProperty(PropertyName = "link")]
        public string Link { get; set; }

        
        /// LinkSecure
        
        [JsonProperty(PropertyName = "link_secure")]
        public string LinkSecure { get; set; }

        
        /// FileQuality
        
        public FileQualityEnum FileQuality
        {
            get => ModelHelpers.GetEnumValue<FileQualityEnum>(Quality, QualityMappings);
        }
    }
}
