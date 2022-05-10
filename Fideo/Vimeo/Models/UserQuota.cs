using Newtonsoft.Json;

namespace Fideo.Vimeo.Models
{
    /// <summary>
    /// User quota
    /// </summary>
    public class UserQuota
    {
        /// <summary>
        /// HD
        /// </summary>
        [JsonProperty(PropertyName = "hd")]
        public bool Hd { get; set; }

        /// <summary>
        /// SD
        /// </summary>
        [JsonProperty(PropertyName = "sd")]
        public bool Sd { get; set; }
    }
}