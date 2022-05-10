using Newtonsoft.Json;

namespace Fideo.Vimeo.Models
{
    /// <summary>
    /// Upload ticket
    /// </summary>
    public class TusResumableUploadTicket : Video
    {

        /// <summary>
        /// Upload status
        /// </summary>
        [JsonProperty(PropertyName = "upload")]
        public ResumableUploadStatus Upload { get; set; }
    }

    public class ResumableUploadStatus
    {
        /// <summary>
        /// Upload Approach
        /// </summary>
        [JsonProperty(PropertyName = "approach")]
        public string Approach { get; set; }

        /// <summary>
        /// Upload Status
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }


        /// <summary>
        /// Upload link
        /// </summary>
        [JsonProperty(PropertyName = "upload_link")]
        public string UploadLink { get; set; }

        /// <summary>
        /// Video Size in bytes
        /// </summary>
        [JsonProperty(PropertyName = "size")]
        public long Size { get; set; }

    }
}
