using Newtonsoft.Json;
using Fideo.Vimeo.Helpers;

namespace Fideo.Vimeo.Models
{
    public class EmbedPresets
    {
        // Id
        public long? Id => ModelHelpers.ParseModelUriId(Uri);
        
        // URI
        [JsonProperty(PropertyName = "uri")]
        public string Uri { get; set; }

        // Name
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        // Settings        
        [JsonProperty(PropertyName = "settings")]
        public PresetSettings Settings { get; set; }
    }
}
