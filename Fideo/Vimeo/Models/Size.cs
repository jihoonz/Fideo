using Newtonsoft.Json;

namespace Fideo.Vimeo.Models
{
    
    /// Size
    
    public class Size
    {
        
        /// The width of the image.
        
        [JsonProperty(PropertyName = "width")]
        public int Width { get; set; }

        
        /// The height of the image.
        
        [JsonProperty(PropertyName = "height")]
        public int Height { get; set; }

        
        /// The direct link to the image.
        
        [JsonProperty(PropertyName = "link")]
        public string Link { get; set; }

        
        /// The direct link to the image with a play button overlay.
        
        [JsonProperty(PropertyName = "link_with_play_button")]
        public string LinkWithPlayButton { get; set; }
    }
}
