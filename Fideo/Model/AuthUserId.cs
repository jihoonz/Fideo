using System.ComponentModel.DataAnnotations;

namespace Fideo.Model
{
    public class AuthUserId
    {
        [Required]
        public string VimeoUserId { get; set; }
    }
}
