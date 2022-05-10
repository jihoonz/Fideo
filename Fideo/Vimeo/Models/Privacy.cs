using Newtonsoft.Json;
using Fideo.Vimeo.Enums;
using Fideo.Vimeo.Helpers;

namespace Fideo.Vimeo.Models
{
    
    /// Privacy
    
    public class Privacy
    {
        
        /// View
        
        [JsonProperty(PropertyName = "view")]
        public string View { get; set; }

        
        /// Embed
        
        [JsonProperty(PropertyName = "embed")]
        public string Embed { get; set; }

        
        /// Download
        
        [JsonProperty(PropertyName = "download")]
        public bool Download { get; set; }

        
        /// Add
        
        [JsonProperty(PropertyName = "add")]
        public bool Add { get; set; }

        
        /// View privacy
        
        public VideoPrivacyEnum ViewPrivacy
        {
            get => ModelHelpers.GetEnumValue<VideoPrivacyEnum>(View);
            set => View = ModelHelpers.GetEnumString(value);
        }

        
        /// Embed privacy
        
        public VideoEmbedPrivacyEnum EmbedPrivacy
        {
            get => ModelHelpers.GetEnumValue<VideoEmbedPrivacyEnum>(Embed);
            set => Embed = ModelHelpers.GetEnumString(value);
        }
    }
}
