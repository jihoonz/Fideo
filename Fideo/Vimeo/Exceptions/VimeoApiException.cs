using System;

namespace Fideo.Vimeo.Exceptions
{
    public class VimeoApiException : Exception
    {
        /// <inheritdoc />
        public VimeoApiException()
        {
        }

        /// <inheritdoc />
        public VimeoApiException(string message)
            : base(message)
        {
        }

        /// <inheritdoc />
        public VimeoApiException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}