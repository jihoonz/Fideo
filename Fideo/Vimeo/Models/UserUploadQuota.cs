using Newtonsoft.Json;

namespace Fideo.Vimeo.Models
{
    /// User upload quota
    /// </summary>
    public class UserUploadQuota
    {
        /// <summary>
        /// Space
        /// </summary>
        [JsonProperty(PropertyName = "space")]
        public Space Space { get; set; }

        /// <summary>
        /// Resets
        /// </summary>
        [JsonProperty(PropertyName = "resets")]
        public int Resets { get; set; }

        /// <summary>
        /// Quota
        /// </summary>
        [JsonProperty(PropertyName = "quota")]
        public UserQuota Quota { get; set; }
    }
}