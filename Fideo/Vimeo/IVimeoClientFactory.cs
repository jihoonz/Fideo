namespace Fideo.Vimeo
{
    public interface IVimeoClientFactory
    {
        
        /// Return client by access token
        
        /// <param name="accessToken"></param>
        /// <returns>VimeoClient</returns>
        IVimeoClient GetVimeoClient(string accessToken);

        
        /// Return client based on ClientId and SecretId
        
        /// <param name="clientId">ClientId</param>
        /// <param name="clientSecret">SecretId</param>
        /// <returns>VimeoClient</returns>
        IVimeoClient GetVimeoClient(string clientId, string clientSecret);
    }
}
