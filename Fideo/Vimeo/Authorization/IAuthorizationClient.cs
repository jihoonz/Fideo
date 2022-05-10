using System.Collections.Generic;
using System.Threading.Tasks;
using Fideo.Vimeo.Models;

namespace Fideo.Vimeo.Authorization
{
    
    /// IAuthorizationClient
    /// Additional info https://developer.vimeo.com/api/authentication
    
    public interface IAuthorizationClient
    {
        
        /// GetAccessToken
        
        /// <param name="authorizationCode">AuthorizationCode</param>
        /// <param name="redirectUri">RedirectUri</param>
        /// <returns>Access token response</returns>
        /// [Obsolete("Use async API instead sync wrapper")]
        AccessTokenResponse GetAccessToken(string authorizationCode, string redirectUri);

        
        /// GetAccessTokenAsync
        
        /// <param name="authorizationCode">AuthorizationCode</param>
        /// <param name="redirectUri">RedirectUri</param>
        /// <returns>Access token response</returns>
        Task<AccessTokenResponse> GetAccessTokenAsync(string authorizationCode, string redirectUri);

        
        /// VerifyAccessToken
        
        /// <param name="accessToken">AccessToken</param>
        /// <returns>true if access token works, false otherwise</returns>
        /// [Obsolete("Use async API instead sync wrapper")]
        bool VerifyAccessToken(string accessToken);

        
        /// VerifyAccessToken
        
        /// <param name="accessToken">AccessToken</param>
        /// <returns>true if access token works, false otherwise</returns>
        /// [Obsolete("Use async API instead sync wrapper")]
        Task<bool> VerifyAccessTokenAsync(string accessToken);

        
        /// Return unauthenticated token
        
        /// <returns>Access token response</returns>
        Task<AccessTokenResponse> GetUnauthenticatedTokenAsync();

        
        /// GetAuthorizationEndpoint
        
        /// <param name="redirectUri">RedirectUri</param>
        /// <param name="scope">Scope</param>
        /// <param name="state">State</param>
        /// <returns>Authorization endpoint</returns>
        string GetAuthorizationEndpoint(string redirectUri, IEnumerable<string> scope, string state);
    }
}
