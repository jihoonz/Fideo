using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Fideo.Vimeo.Network;
using Fideo.Vimeo.Authorization;
using Fideo.Vimeo.Models;
using Fideo.Vimeo.Constants;
using Fideo.Vimeo.Exceptions;

namespace Fideo.Vimeo
{
    public partial class VimeoClient : IVimeoClient
    {
        #region Constants

        internal const int DefaultUploadChunkSize = 1048576; // 1MB

        
        /// Range regex
        
        private static readonly Regex RangeRegex = new Regex(@"bytes\s*=\s*(?<start>\d+)-(?<end>\d+)",
            RegexOptions.IgnoreCase);

        #endregion

        #region Fields

        
        /// Api request factory
        
        private readonly IApiRequestFactory _apiRequestFactory;

        
        /// Auth client factory
        
        private readonly IAuthorizationClientFactory _authClientFactory;

        #endregion

        #region Properties

        
        /// ClientId
        
        private string ClientId { get; }

        
        /// ClientSecret
        
        private string ClientSecret { get; }

        
        /// AccessToken
        
        private string AccessToken { get; }

        
        /// OAuth2Client
        
        private IAuthorizationClient OAuth2Client { get; set; }

        #endregion


        #region RateLimit

        public long RateLimit { get; private set; }

        /// <inheritdoc />
        public long RateLimitRemaining { get; private set; }

        /// <inheritdoc />
        public DateTime RateLimitReset { get; private set; }

        private void UpdateRateLimit(IApiResponse response)
        {
            if (response.Headers == null || !response.Headers.Contains("X-RateLimit-Limit"))
            {
                RateLimit = 0;
            }
            else
            {
                RateLimit = Convert.ToInt64(response.Headers.GetValues("X-RateLimit-Limit").First());
            }

            if (response.Headers == null || !response.Headers.Contains("X-RateLimit-Remaining"))
            {
                RateLimitRemaining = 0;
            }
            else
            {
                RateLimitRemaining = Convert.ToInt64(response.Headers.GetValues("X-RateLimit-Remaining").First());
            }

            if (response.Headers == null || !response.Headers.Contains("X-RateLimit-Reset"))
            {
                RateLimitReset = DateTime.UtcNow;
            }
            else
            {
                RateLimitReset = DateTime.ParseExact(response.Headers.GetValues("X-RateLimit-Reset").First(),
                    "yyyy-MM-ddTHH:mm:sszzz", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);
            }
        }
        #endregion

        #region Constructors

        private VimeoClient()
        {
            _authClientFactory = new AuthorizationClientFactory();
            _apiRequestFactory = new ApiRequestFactory();
            RateLimit = 0;
            RateLimitRemaining = 0;
            RateLimitReset = DateTime.UtcNow;
        }

        
        /// Multi-user application constructor, using user-level OAuth2
        
        /// <param name="clientId">ClientId</param>
        /// <param name="clientSecret">ClientSecret</param>
        public VimeoClient(string clientId, string clientSecret)
            : this()
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
            OAuth2Client = new AuthorizationClient(ClientId, ClientSecret);
        }

        
        /// Single-user application constructor, using account OAuth2 access token
        
        /// <param name="accessToken">Your Vimeo API Access Token</param>
        public VimeoClient(string accessToken)
            : this()
        {
            AccessToken = accessToken;
        }

        /// <inheritdoc />
        internal VimeoClient(IAuthorizationClientFactory authClientFactory, IApiRequestFactory apiRequestFactory,
            string clientId, string clientSecret)
            : this(clientId, clientSecret)
        {
            _authClientFactory = authClientFactory;
            _apiRequestFactory = apiRequestFactory;
        }

        /// <inheritdoc />
        internal VimeoClient(IAuthorizationClientFactory authClientFactory, IApiRequestFactory apiRequestFactory,
            string accessToken)
            : this(accessToken)
        {
            _authClientFactory = authClientFactory;
            _apiRequestFactory = apiRequestFactory;
        }

        #endregion

        #region Authorization

        /// <inheritdoc />
        public string GetOauthUrl(string redirectUri, IEnumerable<string> scope, string state)
        {
            PrepAuthorizationClient();
            return OAuth2Client.GetAuthorizationEndpoint(redirectUri, scope, state);
        }

        /// <inheritdoc />
        public async Task<AccessTokenResponse> GetAccessTokenAsync(string authorizationCode, string redirectUrl)
        {
            PrepAuthorizationClient();
            return await OAuth2Client.GetAccessTokenAsync(authorizationCode, redirectUrl).ConfigureAwait(false);
        }

        private void PrepAuthorizationClient()
        {
            if (OAuth2Client == null)
            {
                OAuth2Client = _authClientFactory.GetAuthorizationClient(ClientId, ClientSecret);
            }
        }

        #endregion

        #region Account

        /// <inheritdoc />
        public async Task<User> GetAccountInformationAsync()
        {
            var request = _apiRequestFactory.AuthorizedRequest(
                AccessToken,
                HttpMethod.Get,
                Endpoints.GetCurrentUserEndpoint(Endpoints.User)
            );

            return await ExecuteApiRequest<User>(request).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<User> GetUserInformationAsync(long userId)
        {
            var request = _apiRequestFactory.AuthorizedRequest(
                AccessToken,
                HttpMethod.Get,
                Endpoints.User,
                new Dictionary<string, string>
                {
                    {"userId", userId.ToString()}
                }
            );

            return await ExecuteApiRequest<User>(request).ConfigureAwait(false);
        }

        #endregion

        #region Utility

        
        /// Utility method for calling ExecuteApiRequest with the most common use case (returning
        /// null for NotFound responses).
        
        /// <typeparam name="T">Type of the expected response data.</typeparam>
        /// <param name="request"></param>
        /// <returns></returns>
        private async Task<T> ExecuteApiRequest<T>(IApiRequest request) where T : new()
        {
            return await ExecuteApiRequest(request, statusCode => default(T), HttpStatusCode.NotFound)
                .ConfigureAwait(false);
        }

        
        /// Utility method for performing API requests that retrieve data in a consistent manner.
        ///
        /// The given request will be performed, and if the response is an outright success then
        /// the response data will be unwrapped and returned.
        ///
        /// If the call is not an outright success, but the status code is among the other acceptable
        /// results (provided via validStatusCodes), the getValueForStatusCode method will be called
        /// to generate a return value. This allows the caller to return null or an empty list as
        /// desired.
        ///
        /// If neither of the above is possible, an exception will be thrown.
        
        /// <typeparam name="T">Type of the expected response data.</typeparam>
        /// <param name="request"></param>
        /// <param name="getValueForStatusCode"></param>
        /// <param name="validStatusCodes"></param>
        /// <returns></returns>
        private async Task<T> ExecuteApiRequest<T>(IApiRequest request, Func<HttpStatusCode, T> getValueForStatusCode,
            params HttpStatusCode[] validStatusCodes) where T : new()
        {
            try
            {
                var response = await request.ExecuteRequestAsync<T>().ConfigureAwait(false);
                UpdateRateLimit(response);

                // if request was successful, return immediately...
                if (IsSuccessStatusCode(response.StatusCode))
                {
                    return response.Content;
                }

                // if request is among other accepted status codes, return the corresponding value...
                if (validStatusCodes != null && validStatusCodes.Contains(response.StatusCode))
                {
                    return getValueForStatusCode(response.StatusCode);
                }

                // at this point, we've eliminated all acceptable responses, throw an exception...
                throw new VimeoApiException(string.Format("{1}{0}Code: {2}{0}Message: {3}",
                    Environment.NewLine,
                    "Error retrieving information from Vimeo API.",
                    response.StatusCode,
                    response.Text
                ));
            }
            catch (Exception ex)
            {
                if (ex is VimeoApiException)
                {
                    throw;
                }

                throw new VimeoApiException("Error retrieving information from Vimeo API.", ex);
            }
        }

        private async Task<bool> ExecuteApiRequest(IApiRequest request, params HttpStatusCode[] validStatusCodes)
        {
            try
            {
                var response = await request.ExecuteRequestAsync().ConfigureAwait(false);
                UpdateRateLimit(response);
                // if request was successful, return immediately...
                if (IsSuccessStatusCode(response.StatusCode))
                {
                    return true;
                }

                // if request is among other accepted status codes, return the corresponding value...
                if (validStatusCodes != null && validStatusCodes.Contains(response.StatusCode))
                {
                    return true;
                }

                // at this point, we've eliminated all acceptable responses, throw an exception...
                throw new VimeoApiException(string.Format("{1}{0}Code: {2}{0}Message: {3}",
                    Environment.NewLine,
                    "Error retrieving information from Vimeo API.",
                    response.StatusCode,
                    response.Text
                ));
            }
            catch (Exception ex)
            {
                if (ex is VimeoApiException)
                {
                    throw;
                }

                throw new VimeoApiException("Error retrieving information from Vimeo API.", ex);
            }
        }

        #endregion

        #region Helper Functions

        private void ThrowIfUnauthorized()
        {
            if (string.IsNullOrWhiteSpace(AccessToken))
            {
                throw new InvalidOperationException("Please authenticate via OAuth to obtain an access token.");
            }
        }

        private static void CheckStatusCodeError(IUploadRequest request, IApiResponse response, string message,
            params HttpStatusCode[] validStatusCodes)
        {
            if (!IsSuccessStatusCode(response.StatusCode) && validStatusCodes != null &&
                !validStatusCodes.Contains(response.StatusCode))
            {
                throw new VimeoUploadException(string.Format("{1}{0}Code: {2}{0}Message: {3}",
                        Environment.NewLine, message, response.StatusCode, response.Text),
                    request);
            }
        }

        private static void CheckStatusCodeError(IApiResponse response, string message,
            params HttpStatusCode[] validStatusCodes)
        {
            if (!IsSuccessStatusCode(response.StatusCode) && validStatusCodes != null &&
                !validStatusCodes.Contains(response.StatusCode))
            {
                throw new VimeoApiException(string.Format("{1}{0}Code: {2}{0}Message: {3}",
                    Environment.NewLine, message, response.StatusCode, response.Text));
            }
        }

        private static bool IsSuccessStatusCode(HttpStatusCode statusCode)
        {
            var code = (int)statusCode;
            return code >= 200 && code < 300;
        }

        #endregion
    }
}
