using System.ComponentModel.DataAnnotations;

namespace Fideo.Model
{
    public class VideoClipId
    {
        [Required]
        public string ClipId { get; set; }
    }
}
