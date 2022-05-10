using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Fideo.Vimeo.Constants;

namespace Fideo.Vimeo.Network
{
    public class ApiRequest : IApiRequest
    {
#if NET45
        static ApiRequest()
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
        }
#endif

        #region Private Fields

        private readonly Dictionary<string, string> _queryString = new Dictionary<string, string>();
        private readonly Dictionary<string, string> _urlSegments = new Dictionary<string, string>();

        private static readonly JsonSerializerSettings DateFormatSettings = new JsonSerializerSettings
        {
            DateFormatString = "yyyy-MM-ddTHH:mm:sszzz",
            DateTimeZoneHandling = DateTimeZoneHandling.Utc
        };

        private string _path;

        #endregion

        #region Public Properties

        /// <inheritdoc />
        public string ApiVersion { get; set; }
        /// <inheritdoc />
        public string ResponseType { get; set; }
        /// <inheritdoc />
        public string Protocol { get; set; }

        /// <inheritdoc />
        public string Host { get; set; }

        /// <inheritdoc />
        public int Port { get; set; }

        /// <inheritdoc />
        public HttpMethod Method { get; set; }

        /// <inheritdoc />
        public string Path
        {
            get => _path;
            set
            {
                if (Uri.TryCreate(value, UriKind.Absolute, out var parsed) && parsed.Scheme != "file")
                {
                    Protocol = parsed.Scheme;
                    Host = parsed.Host;
                    _path = parsed.PathAndQuery;
                    Port = parsed.Port;
                }
                else
                {
                    _path = value;
                }
            }
        }

        /// <inheritdoc />
        public HttpContent Body { get; set; }

        /// <inheritdoc />
        public IDictionary<string, string> Query => _queryString;

        /// <inheritdoc />
        public List<string> Fields { get; } = new List<string>();

        /// <inheritdoc />
        public IDictionary<string, string> UrlSegments => _urlSegments;

        /// <inheritdoc />
        public byte[] BinaryContent { get; set; }

        /// <inheritdoc />
        public bool ExcludeAuthorizationHeader { get; set; }

        #endregion

        #region Private Properties

        
        /// Rest client
        
        private static readonly HttpClient Client = new HttpClient(new HttpClientHandler { AllowAutoRedirect = false });

        
        /// Client Id
        
        private string ClientId { get; }

        
        /// Client secret
        
        private string ClientSecret { get; }
        
        /// Access token
        
        private string AccessToken { get; }

        #endregion

        #region Constructors

        
        /// Create new request
        
        public ApiRequest()
        {
            Protocol = Request.DefaultProtocol;
            Host = Request.DefaultHostName;
            Port = Request.DefaultHttpsPort;
            Method = Request.DefaultMethod; 
            ResponseType = ResponseTypes.Wildcard;
            ApiVersion = ApiVersions.v3_2;
            ExcludeAuthorizationHeader = false;
        }

        /// <inheritdoc />
        public ApiRequest(string clientId, string clientSecret)
            : this()
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
        }

        /// <inheritdoc />
        public ApiRequest(string accessToken)
            : this()
        {
            AccessToken = accessToken;
        }

        #endregion

        #region Public Methods

        /// <inheritdoc />
        public async Task<IApiResponse> ExecuteRequestAsync()
        {
            var response = await Client.SendAsync(PrepareRequest()).ConfigureAwait(false);
            var text = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return new ApiResponse(response.StatusCode, response.Headers, text);
        }

        /// <inheritdoc />
        public async Task<IApiResponse<T>> ExecuteRequestAsync<T>() where T : new()
        {
            var request = PrepareRequest();
            var response = await Client.SendAsync(request).ConfigureAwait(false);
            var text = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return new ApiResponse<T>(response.StatusCode, response.Headers, text,
                JsonConvert.DeserializeObject<T>(text, DateFormatSettings));
        }

        #endregion

        #region Private Methods

        
        /// PrepareRequest
        
        /// <returns>Rest request</returns>
        private HttpRequestMessage PrepareRequest()
        {
            SetDefaults();
            var request = new HttpRequestMessage(Method, BuildUrl());
            if (!ExcludeAuthorizationHeader)
            {
                SetAuth(request);
            }
            SetHeaders(request);
            request.Content = Body;
            return request;
        }

        
        /// Set request headers
        
        /// <param name="request">Request</param>
        private void SetHeaders(HttpRequestMessage request)
        {
            request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse(BuildAcceptsHeader()));
            request.Headers.Accept.Add(MediaTypeWithQualityHeaderValue.Parse("application/json"));
        }

        
        /// Set authentication
        
        private void SetAuth(HttpRequestMessage request)
        {
            if (!string.IsNullOrWhiteSpace(AccessToken))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
            }
            if (string.IsNullOrWhiteSpace(ClientId) || string.IsNullOrWhiteSpace(ClientSecret))
                return;
            var token = $"{ClientId}:{ClientSecret}";
            var tokenBytes = Encoding.ASCII.GetBytes(token);
            var encoded = Convert.ToBase64String(tokenBytes);
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", encoded);
        }

        
        /// Set defaults
        
        private void SetDefaults()
        {
            Protocol = string.IsNullOrWhiteSpace(Protocol) ? Request.DefaultProtocol : Protocol;
            Host = string.IsNullOrWhiteSpace(Host) ? Request.DefaultHostName : Host;
            ResponseType = string.IsNullOrWhiteSpace(ResponseType) ? ResponseTypes.Wildcard : ResponseType;
            ApiVersion = string.IsNullOrWhiteSpace(ApiVersion) ? ApiVersions.v3_2 : ApiVersion;

            Protocol = Protocol.ToLower();
            Host = Host.ToLower();

            Port = Port > 0 ? Port : GetDefaultPort(Protocol);
        }

        
        /// Build accepts header
        
        /// <returns>Accepts header</returns>
        private string BuildAcceptsHeader()
        {
            return $"{ResponseType};{ApiVersion}";
        }

        
        /// Return default port
        
        /// <param name="protocol">Protocol</param>
        /// <returns>Port</returns>
        private static int GetDefaultPort(string protocol)
        {
            return protocol == Request.ProtocolHttps ? Request.DefaultHttpsPort : Request.DefaultHttpPort;
        }

        
        /// Retrun base URL
        
        /// <returns>Base URL</returns>
        private string GetBaseUrl()
        {
            var url = Protocol.ToLower() + "://";

            if (Host.EndsWith("/"))
            {
                Host = Host.Substring(0, Host.Length - 1);
            }
            url += Host;

            if (Port != GetDefaultPort(Protocol))
            {
                url += ":" + Port;
            }

            return url;
        }

        
        /// Build request URL
        
        /// <returns>Request URL</returns>
        private string BuildUrl()
        {
            var sb = new StringBuilder();
            sb.Append(GetBaseUrl());
            var path = Path;
            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (var urlSegment in UrlSegments)
            {
                path = path.Replace($"{{{urlSegment.Key}}}", urlSegment.Value);
            }
            sb.Append(path);
            if (Fields.Count > 0)
            {
                Query.Add("fields", string.Join(",", Fields));
            }
            if (Query.Keys.Count == 0)
                return sb.ToString();
            sb.Append("?");
            sb.Append(string.Join("&", Query.Select(q => $"{q.Key}={q.Value}")));
            return sb.ToString();
        }

        #endregion
    }
}
