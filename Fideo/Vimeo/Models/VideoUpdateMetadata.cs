using Fideo.Vimeo.Enums;

namespace Fideo.Vimeo.Models
{
    
    /// Video update metadata model
    
    public class VideoUpdateMetadata
    {
        
        /// The new title for the video
        
        public string Name { get; set; }

        
        /// The new description for the video
        
        public string Description { get; set; }

        
        /// The new privacy setting for the video.
        /// Content-type application/json is the only valid type for type "users",
        /// basic users can not set privacy to unlisted.
        
        public VideoPrivacyEnum? Privacy { get; set; }

        
        /// The videos new embed settings. Whitelist allows you to define all valid embed domains.
        ///  Check out our docs for adding and removing domains.
        
        public VideoEmbedPrivacyEnum? EmbedPrivacy { get; set; }

        
        /// Enable or disable the review page
        
        public bool? ReviewLinkEnabled { get; set; }

        
        /// When you set privacy to password, you must provide the password as an additional parameter
        
        public string Password { get; set; }

        
        /// The privacy for who can comment on the video.
        
        public VideoCommentsEnum? Comments { get; set; }

        
        /// Enable or disable the ability for anyone to add the video to an album, channel, or group.
        
        public bool? AllowAddToAlbumChannelGroup { get; set; }

        
        /// Enable or disable the ability for anyone to download video.
        
        public bool? AllowDownloadVideo { get; set; }
    }
}