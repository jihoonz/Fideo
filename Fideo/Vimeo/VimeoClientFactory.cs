using Fideo.Vimeo.Network;
using Fideo.Vimeo.Authorization;

namespace Fideo.Vimeo
{
    public class VimeoClientFactory : IVimeoClientFactory
    {
        #region Fields

        
        /// Api request factory
        
        protected IApiRequestFactory ApiRequestFactory;

        
        /// Auth client factory
        
        protected IAuthorizationClientFactory AuthClientFactory;

        #endregion

        #region Constructors

        
        /// Create new Vimeo client factory
        
        public VimeoClientFactory()
        {
            AuthClientFactory = new AuthorizationClientFactory();
            ApiRequestFactory = new ApiRequestFactory();
        }

        
        /// IOC Constructor for use with IVimeoClientFactory
        
        /// <param name="authClientFactory">The IAuthorizationClientFactory</param>
        /// <param name="apiRequestFactory">The IApiRequestFactory</param>
        public VimeoClientFactory(IAuthorizationClientFactory authClientFactory, IApiRequestFactory apiRequestFactory)
        {
            AuthClientFactory = authClientFactory;
            ApiRequestFactory = apiRequestFactory;
        }

        #endregion

        #region Public Functions

        /// <inheritdoc />
        public IVimeoClient GetVimeoClient(string clientId, string clientSecret)
        {
            return new VimeoClient(AuthClientFactory, ApiRequestFactory, clientId, clientSecret);
        }

        /// <inheritdoc />
        public IVimeoClient GetVimeoClient(string accessToken)
        {
            return new VimeoClient(AuthClientFactory, ApiRequestFactory, accessToken);
        }

        #endregion
    }
}
