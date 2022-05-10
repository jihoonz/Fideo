using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Fideo.Vimeo.Enums;
using Fideo.Vimeo.Helpers;

namespace Fideo.Vimeo.Models
{
    
    /// Video
    
    public class Video
    {
        private static readonly IDictionary<string, string> StatusMappings = new Dictionary<string, string>
        {
            {"uploading_error", "UploadError"}
        };

        
        /// Id
        
        public long? Id => ModelHelpers.ParseModelUriId(Uri);

        
        /// URI
        
        [JsonProperty(PropertyName = "uri")]
        public string Uri { get; set; }

        
        /// User
        
        [JsonProperty(PropertyName = "user")]
        public User User { get; set; }

        
        /// Name
        
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        
        /// Description
        
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        
        /// Link
        
        [JsonProperty(PropertyName = "link")]
        public string Link { get; set; }

        
        /// Review link
        
        [JsonProperty(PropertyName = "review_link")]
        public string ReviewLink { get; set; }

        
        /// Status
        
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }

        
        /// Type
        
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        
        /// Embed presets
        
        [JsonProperty(PropertyName = "embed_presets")]
        public EmbedPresets EmbedPresets { get; set; }

        
        /// Duration
        
        [JsonProperty(PropertyName = "duration")]
        public int Duration { get; set; }

        
        /// Width
        
        [JsonProperty(PropertyName = "width")]
        public int Width { get; set; }

        
        /// Height
        
        [JsonProperty(PropertyName = "height")]
        public int Height { get; set; }

        
        /// Created time
        
        [JsonProperty(PropertyName = "created_time")]
        public DateTime CreatedTime { get; set; }

        
        /// Modified time
        
        [JsonProperty(PropertyName = "modified_time")]
        public DateTime ModifiedTime { get; set; }

        
        /// Privacy
        
        [JsonProperty(PropertyName = "privacy")]
        public Privacy Privacy { get; set; }

        
        /// Pictures
        
        [JsonProperty(PropertyName = "pictures")]
        public Pictures Pictures { get; set; }

        
        /// Files
        
        [JsonProperty(PropertyName = "files")]
        public List<File> Files { get; set; }

        
        /// Metadata
        
        [JsonProperty(PropertyName = "metadata")]
        public VideoMetadata Metadata { get; set; }


        
        /// Mobile video link
        
        public string MobileVideoLink => GetFileQualityUrl(FileQualityEnum.Mobile, false);

        
        /// Mobile video secure link
        
        public string MobileVideoSecureLink => GetFileQualityUrl(FileQualityEnum.Mobile, true);

        
        /// Standard video link
        
        public string StandardVideoLink => GetFileQualityUrl(FileQualityEnum.Standard, false);

        
        /// Standard video secure link
        
        public string StandardVideoSecureLink => GetFileQualityUrl(FileQualityEnum.Standard, true);

        
        /// High definition video link
        
        public string HighDefinitionVideoLink => GetFileQualityUrl(FileQualityEnum.HighDefinition, false);

        
        /// High definition video secure link
        
        public string HighDefinitionVideoSecureLink => GetFileQualityUrl(FileQualityEnum.HighDefinition, true);

        
        /// Streaming video link
        
        public string StreamingVideoLink => GetFileQualityUrl(FileQualityEnum.Streaming, false);

        
        /// Streaming video secure link
        
        public string StreamingVideoSecureLink => GetFileQualityUrl(FileQualityEnum.Streaming, true);

        private string GetFileQualityUrl(FileQualityEnum quality, bool secureLink)
        {
            if (Files == null || Files.Count == 0)
            {
                return null;
            }

            var match = Files.FirstOrDefault(f => f.FileQuality == quality);
            if (match == null)
            {
                return null;
            }

            return secureLink ? match.LinkSecure : match.Link;
        }
    }
}
