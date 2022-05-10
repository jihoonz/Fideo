using System.Collections.Generic;
using Newtonsoft.Json;

namespace Fideo.Vimeo.Models
{
    
    /// Upload ticket
    
    public class UploadTicket
    {
        
        /// Ticket id
        
        [JsonProperty(PropertyName = "ticket_id")]
        public string TicketId { get; set; }

        
        /// URI
        
        [JsonProperty(PropertyName = "uri")]
        public string Uri { get; set; }

        
        /// Complete URI
        
        [JsonProperty(PropertyName = "complete_uri")]
        public string CompleteUri { get; set; }

        
        /// Upload URI
        
        [JsonProperty(PropertyName = "upload_uri")]
        public string UploadUri { get; set; }

        
        /// Upload URI secure
        
        [JsonProperty(PropertyName = "upload_uri_secure")]
        public string UploadUriSecure { get; set; }

        
        /// Upload link
        
        [JsonProperty(PropertyName = "upload_link")]
        public string UploadLink { get; set; }

        
        /// Upload link secure
        
        [JsonProperty(PropertyName = "upload_link_secure")]
        public string UploadLinkSecure { get; set; }

        
        /// Type
        
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        
        /// User
        
        [JsonProperty(PropertyName = "user")]
        public User User { get; set; }

        
        /// Video
        
        [JsonProperty(PropertyName = "video")]
        public Video Video { get; set; }

        
        /// Upload status
        
        [JsonProperty(PropertyName = "upload")]
        public UploadStatus Upload { get; set; }

        
        /// Transcode
        
        [JsonProperty(PropertyName = "transcode")]
        public List<Transcode> Transcode { get; set; }

        
        /// Quota
        
        [JsonProperty(PropertyName = "quota")]
        public UploadTicketQuota Quota { get; set; }
    }
}