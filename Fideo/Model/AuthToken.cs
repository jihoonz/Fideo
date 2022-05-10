using System.ComponentModel.DataAnnotations;

namespace Fideo.Model
{
    public class AuthToken
    {
        [Required]
        public string AccessToken { get; set; }
    }
}
