using System;
using Newtonsoft.Json;

namespace Fideo.Vimeo.Models
{
    
    /// Upload ticket quota
    
    public class UploadTicketQuota
    {
        
        /// SD
        
        [JsonProperty(PropertyName = "sd")]
        public bool Sd { get; set; }

        
        /// HD
        
        [JsonProperty(PropertyName = "hd")]
        public bool Hd { get; set; }

        
        /// Total space
        
        [JsonProperty(PropertyName = "total_space")]
        public long TotalSpace { get; set; }

        
        /// Space used
        
        [JsonProperty(PropertyName = "space_used")]
        public long SpaceUsed { get; set; }

        
        /// Free space
        
        [JsonProperty(PropertyName = "free_space")]
        public long FreeSpace { get; set; }

        
        /// Max file size
        
        [JsonProperty(PropertyName = "max_file_size")]
        public long MaxFileSize { get; set; }

        
        /// Resets
        
        [JsonProperty(PropertyName = "resets")]
        public DateTime Resets { get; set; }
    }
}