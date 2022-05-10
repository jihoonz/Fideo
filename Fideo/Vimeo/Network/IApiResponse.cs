using System;
using System.Net;
using System.Net.Http.Headers;

namespace Fideo.Vimeo.Network
{
    public interface IApiResponse
    {
        HttpStatusCode StatusCode { get; }

        /// HTTP response headers
        HttpResponseHeaders Headers { get; }

        
        /// Response text
        
        string Text { get; }
    }

    /// <inheritdoc />
    
    /// Interface of REST response with payload type
    
    public interface IApiResponse<out T> : IApiResponse
    {
        
        /// Response payload
        
        T Content { get; }
    }

    internal class ApiResponse : IApiResponse
    {
        public ApiResponse(HttpStatusCode statusCode, HttpResponseHeaders headers, string text)
        {
            StatusCode = statusCode;
            Headers = headers;
            Text = text;
        }

        public HttpStatusCode StatusCode { get; }
        public HttpResponseHeaders Headers { get; }
        public string Text { get; }
    }

    internal class ApiResponse<T> : IApiResponse<T>
    {
        public ApiResponse(HttpStatusCode statusCode, HttpResponseHeaders headers, string text, T content)
        {
            StatusCode = statusCode;
            Headers = headers;
            Content = content;
            Text = text;
        }

        public HttpStatusCode StatusCode { get; }
        public HttpResponseHeaders Headers { get; }
        public string Text { get; }
        public T Content { get; }
    }
}
