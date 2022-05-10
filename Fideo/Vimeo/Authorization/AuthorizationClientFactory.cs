namespace Fideo.Vimeo.Authorization
{
    public class AuthorizationClientFactory : IAuthorizationClientFactory
    {
        /// <inheritdoc />
        public IAuthorizationClient GetAuthorizationClient(string clientId, string clientSecret)
        {
            return new AuthorizationClient(clientId, clientSecret);
        }
    }
}
