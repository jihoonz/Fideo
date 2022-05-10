using System.Collections.Generic;
using System.Net.Http;
using Fideo.Vimeo.Parameter;

namespace Fideo.Vimeo.Network
{
    public interface IApiRequestFactory
    {
        
        /// Return api request
        
        /// <returns>Api request</returns>
        IApiRequest GetApiRequest();

        
        /// Return api request by AccessToken
        
        /// <param name="accessToken">AccessToken</param>
        /// <returns>Api request</returns>
        IApiRequest GetApiRequest(string accessToken);

        
        /// Return api request by ClientId and ClientSecret
        
        /// <param name="clientId">ClientId</param>
        /// <param name="clientSecret">ClientSecret</param>
        /// <returns>Api request</returns>
        IApiRequest GetApiRequest(string clientId, string clientSecret);

        
        /// Performs basic error checking on parameters and then generates an IApiRequest bound with the provided values. Will throw exception if invalid parameters provided.
        
        /// <param name="accessToken">API AccessToken. Cannot be null or empty.</param>
        /// <param name="method">HttpMethod of the request.</param>
        /// <param name="endpoint">Url of the API endpoint being called. Can contain substitution segments - ex: /user/{userId}/.</param>
        /// <param name="urlSubstitutions">Dictionary containing url parameter keys and values. Continuing above example, key would be "userId", value would be "12345".</param>
        /// <param name="additionalParameters">IParameterProvider that returns any other parameters the API method accepts. Can be null for no parameters, or use ParameterDictionary if typed provider not available.</param>
        /// <returns>A ready to execute IApiRequest.</returns>
        IApiRequest AuthorizedRequest(string accessToken, HttpMethod method, string endpoint,
            IDictionary<string, string> urlSubstitutions = null, IParameterProvider additionalParameters = null);
    }
}
