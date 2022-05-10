using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fideo.Vimeo.Network
{
    public interface IApiRequest
    {
        
        /// Host
        
        string Host { get; set; }

        
        /// Method
        
        HttpMethod Method { get; set; }

        
        /// Path
        
        string Path { get; set; }

        
        /// Port
        
        int Port { get; set; }

        
        /// Protocol
        
        string Protocol { get; set; }

        
        /// Api version
        
        string ApiVersion { get; set; }

        
        /// Binary content
        
        byte[] BinaryContent { get; set; }

        
        /// Body
        
        HttpContent Body { get; set; }

        
        /// Response type
        
        string ResponseType { get; set; }

        
        /// Exclude authorization header
        
        bool ExcludeAuthorizationHeader { get; set; }

        
        /// 
        
        List<string> Fields { get; }

        
        ///
        
        IDictionary<string, string> Query { get; }

        
        ///
        
        IDictionary<string, string> UrlSegments { get; }

        
        /// Execute request asynchronously
        
        /// <returns>Rest reponse</returns>
        Task<IApiResponse> ExecuteRequestAsync();

        
        /// Execute request asynchronously
        
        /// <typeparam name="T">Type</typeparam>
        /// <returns>Rest reponse</returns>
        Task<IApiResponse<T>> ExecuteRequestAsync<T>() where T : new();
    }
}
