using Newtonsoft.Json;

namespace Fideo.Vimeo.Models
{
    
    /// Preset settings
    
    public class PresetSettings
    {
        
        /// Logos
        
        [JsonProperty(PropertyName = "logos")]
        public PresetLogos Logos { get; set; }

        
        /// Outro
        
        [JsonProperty(PropertyName = "outro")]
        public string Outro { get; set; }

        
        /// Portrait
        
        [JsonProperty(PropertyName = "portrait")]
        public string Portrait { get; set; }

        
        /// Title
        
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        
        /// Byline
        
        [JsonProperty(PropertyName = "byline")]
        public string Byline { get; set; }

        
        /// Badge
        
        [JsonProperty(PropertyName = "badge")]
        public bool Badge { get; set; }

        
        /// Byline badge
        
        [JsonProperty(PropertyName = "byline_badge")]
        public bool BylineBadge { get; set; }

        
        /// Playbar
        
        [JsonProperty(PropertyName = "playbar")]
        public bool PlayBar { get; set; }

        
        /// Volume
        
        [JsonProperty(PropertyName = "volume")]
        public bool Volume { get; set; }

        
        /// Fullscreen button
        
        [JsonProperty(PropertyName = "fullscreen_button")]
        public bool FullscreenButton { get; set; }

        
        /// Scaling button
        
        [JsonProperty(PropertyName = "scaling_button")]
        public bool ScalingButton { get; set; }

        
        /// Autoplay
        
        [JsonProperty(PropertyName = "autoplay")]
        public bool AutoPlay { get; set; }

        
        /// Autopause
        
        [JsonProperty(PropertyName = "autopause")]
        public bool AutoPause { get; set; }

        
        /// Loop
        
        [JsonProperty(PropertyName = "loop")]
        public bool Loop { get; set; }

        
        /// Color
        
        [JsonProperty(PropertyName = "color")]
        public string Color { get; set; }

        
        /// Link
        
        [JsonProperty(PropertyName = "link")]
        public bool Link { get; set; }
    }
}
