using System;
using Newtonsoft.Json;

namespace Fideo.Vimeo.Models
{
    public class Folder
    {
        
        /// User
        
        [JsonProperty(PropertyName = "user")]
        public User User { get; set; }

        
        /// Created time
        
        [JsonProperty(PropertyName = "created_time")]
        public DateTime CreatedTime { get; set; }

        
        /// Modified time
        
        [JsonProperty(PropertyName = "modified_time")]
        public DateTime ModifiedTime { get; set; }

        
        /// Name
        
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        
        /// Privacy
        
        [JsonProperty(PropertyName = "privacy")]
        public Privacy Privacy { get; set; }

        
        /// Status
        
        [JsonProperty(PropertyName = "resource_key")]
        public string ResourceKey { get; set; }

        
        /// URI
        
        [JsonProperty(PropertyName = "uri")]
        public string Uri { get; set; }

        
        /// URI
        
        [JsonProperty(PropertyName = "link")]
        public string Link { get; set; }
    }
}
