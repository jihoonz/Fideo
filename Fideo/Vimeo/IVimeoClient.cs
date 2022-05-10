using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fideo.Vimeo.Models;

namespace Fideo.Vimeo
{
    
    /// Interface of Vimeo API
    
    public interface IVimeoClient
    {
        #region User authentication

        
        /// Exchange the code for an access token asynchronously
        
        /// <param name="authorizationCode">A string token you must exchange for your access token</param>
        /// <param name="redirectUrl">This field is required, and must match one of your application’s
        /// redirect URI’s</param>
        /// <returns></returns>
        Task<AccessTokenResponse> GetAccessTokenAsync(string authorizationCode, string redirectUrl);

        
        /// Return authorztion URL
        
        /// <param name="redirectUri"></param>
        /// <param name="scope">Defaults to "public" and "private"; this is a space-separated list of <a href="#supported-scopes">scopes</a> you want to access</param>
        /// <param name="state">A unique value which the client will return alongside access tokens</param>
        /// <returns>Authorization URL</returns>
        string GetOauthUrl(string redirectUri, IEnumerable<string> scope, string state);

        // User Information
        
        /// Get user information async
        
        /// <param name="userId">User Id</param>
        /// <returns>User information object</returns>
        Task<User> GetUserInformationAsync(long userId);

        #endregion

        #region Rate Limit

        
        /// Return rate limit
        
        long RateLimit { get; }

        
        /// Return remaning rate limit
        
        long RateLimitRemaining { get; }

        
        /// Return rate limit reset time
        
        DateTime RateLimitReset { get; }

        #endregion
    }
}
