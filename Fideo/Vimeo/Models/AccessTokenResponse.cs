using Newtonsoft.Json;

namespace Fideo.Vimeo.Models
{
    public class AccessTokenResponse
    {
        
        /// The token you use to make an API request
        
        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }

        
        /// The type of token (Vimeo only supports Bearer at the moment)
        
        [JsonProperty(PropertyName = "token_type")]
        public string TokenType { get; set; }

        
        /// The final scopes the token was granted. This list MAY be different from the scopes you requested. This will be the actual permissions the token has been granted.
        
        [JsonProperty(PropertyName = "scope")]
        public string Scope { get; set; }

        
        /// This is the full user response for the authenticated user.
        /// If you generated your token using the client credentials grant, this value is left out.
        
        [JsonProperty(PropertyName = "user")]
        public User User { get; set; }
    }
}
