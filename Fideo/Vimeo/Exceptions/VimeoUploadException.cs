using System;
using Fideo.Vimeo.Network;

namespace Fideo.Vimeo.Exceptions
{ 
    internal class VimeoUploadException : VimeoApiException
    {
        public VimeoUploadException()
        {
        }

        public VimeoUploadException(IUploadRequest request)
        {
            Request = request;
        }

        public VimeoUploadException(string message)
            : base(message)
        {
        }

        public VimeoUploadException(string message, IUploadRequest request)
            : base(message)
        {
            Request = request;
        }

        public VimeoUploadException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public VimeoUploadException(string message, IUploadRequest request, Exception innerException)
            : base(message, innerException)
        {
            Request = request;
        }

        public IUploadRequest Request { get; set; }
    }
}