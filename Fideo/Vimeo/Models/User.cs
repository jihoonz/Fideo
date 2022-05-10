using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Fideo.Vimeo.Helpers;

namespace Fideo.Vimeo.Models
{
    public class User
    {
        private static readonly IDictionary<string, string> AccountTypeMappings = new Dictionary<string, string>
        {
            {"pro_unlimited", "ProUnlimited"}
        };

        
        /// Id
        
        public long? Id => ModelHelpers.ParseModelUriId(Uri);

        
        /// URI
        
        [JsonProperty(PropertyName = "uri")]
        public string Uri { get; set; }

        
        /// Name
        
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        
        /// Link
        
        [JsonProperty(PropertyName = "link")]
        public string Link { get; set; }

        
        /// Location
        
        [JsonProperty(PropertyName = "location")]
        public string Location { get; set; }

        
        /// Bio
        
        [JsonProperty(PropertyName = "bio")]
        public string Bio { get; set; }

        
        /// Created time
        
        [JsonProperty(PropertyName = "created_time")]
        public DateTime CreatedTime { get; set; }

        
        /// Account
        
        [JsonProperty(PropertyName = "account")]
        public string Account { get; set; }

        /// Content filter
        [JsonProperty(PropertyName = "content_filter")]
        public string[] ContentFilter { get; set; }


        /// Upload quota
        [JsonProperty(PropertyName = "upload_quota")]
        public UserUploadQuota UploadQuota { get; set; }
    }
}
