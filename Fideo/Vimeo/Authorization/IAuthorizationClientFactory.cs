namespace Fideo.Vimeo.Authorization
{
    
    /// IAuthorizationClientFactory
    
    public interface IAuthorizationClientFactory
    {
        
        /// Return authorization client
        
        /// <param name="clientId">ClientId</param>
        /// <param name="clientSecret">ClientSecret</param>
        /// <returns>Authorization client</returns>
        IAuthorizationClient GetAuthorizationClient(string clientId, string clientSecret);
    }
}
